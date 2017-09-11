using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

using HolyAngels.Models;

namespace HolyAngels.Services {
    public class DataService {
        protected IMongoDatabase ClientDB {get; private set;}
        
        protected IConfigurationSection Configuration {get; private set; }

        protected ILogger Logger {get; private set;}

        private string SiteName {get; set;}
        private string SiteSlogan {get; set;}

        public DataService(IConfiguration configuration, ILoggerFactory factory, string name = "Base") {
            this.Logger = factory.CreateLogger(string.Format("{0}-DataService", name));

            this.SiteName = configuration["SiteName"];
            this.SiteSlogan = configuration["SiteSlogan"];

            this.Configuration = configuration.GetSection("DataService");

            var url = this.Configuration["Url"]?? "mongodb://localhost:6001/holyangels";            
            var client = new MongoClient(url);

            var dbName = this.Configuration["DatabaseName"]?? "holyangels";
            this.ClientDB = client.GetDatabase(dbName);
        }

        /// <summary>
        /// Manually map the models to MongoDB to avoid
        /// using specific class and member attributes.
        /// Useful for separation of concerns or layering.
        /// </summary>        
        public static void RegisterClassMaps() {
            BsonClassMap.RegisterClassMap<PageModel>(map => {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<RoleModel>(map => {
                map.AutoMap();
                map.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<CategoryModel>(map => {
                map.AutoMap();
                map.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
                map.SetIsRootClass(true);
            });            
            BsonClassMap.RegisterClassMap<MinistryCategoryModel>();                        

            BsonClassMap.RegisterClassMap<MinistryModel>(map => {
                map.AutoMap();
                map.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });            
        
            BsonClassMap.RegisterClassMap<QuoteModel>(map => {
                map.AutoMap();
                map.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });            
        }

        /// <summary>
        ///
        /// </summary>
        public PageModel GetPage(string name = "Home") {
            var query = this.ClientDB
                .GetCollection<PageModel>("pagemodel").AsQueryable();
            
            var results = (from q in query
                select q).ToList();

            // Cache opportunity
            var result = results.Find((page) => {
                return page.Name.Equals(name, StringComparison.OrdinalIgnoreCase);
            });

            result.SiteName = this.SiteName;
            result.SiteSlogan = this.SiteSlogan;

            if(result.QuoteEnabled) {
                result.Quote = this.GetQuotes()?[0];
            }
            return result;
        }

        public PageModel<IReadOnlyList<MinistryModel>> GetPageMinistries() {
            var model = this.GetPage("ministries");

            var query = this.ClientDB
                .GetCollection<MinistryModel>("ministrymodel").AsQueryable();
            
            var data = (from q in query
                select q).ToList();

            return PageModel.GetPageModel<IReadOnlyList<MinistryModel>>(model, data);
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<QuoteModel> GetQuotes() {
            var query = this.ClientDB
                .GetCollection<QuoteModel>("quotemodel").AsQueryable();
            
            var results = (from q in query
                select q).ToList();

            return results;
        }

        public IReadOnlyList<RoleModel> GetRoles() {
            var query = this.ClientDB
                .GetCollection<RoleModel>("rolemodel").AsQueryable();
            
            var results = (from q in query
                select q).ToList();

            return results;
        }

        public void AddQuote(QuoteModel document) {            
            var query = this.ClientDB
                .GetCollection<QuoteModel>("quotemodel");
            
            query.InsertOne(document);
        }
    }
}
