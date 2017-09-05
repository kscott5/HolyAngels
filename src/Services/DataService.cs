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

        public DataService(IConfigurationRoot configuration, ILoggerFactory factory, string name = "Base") {
            this.Logger = factory.CreateLogger(string.Format("{0}-DataService", name));
            this.Configuration = configuration.GetSection("DataService");

            var url = this.Configuration["Url"]?? "mongodb://localhost:6001/holyangels";            
            var client = new MongoClient(url);

            var dbName = this.Configuration["DatabaseName"]?? "holyangels";
            this.ClientDB = client.GetDatabase(dbName);
        }

        public static void RegisterClassMaps() {
            BsonClassMap.RegisterClassMap<RoleModel>(map => {
                map.AutoMap();
                map.MapIdMember(c => c.Id);
            });

            BsonClassMap.RegisterClassMap<CatagoryModel>(map => {
                map.AutoMap();
                map.MapIdMember(c => c.Id);
            });            

            BsonClassMap.RegisterClassMap<MinistryModel>(map => {
                map.AutoMap();
                map.MapIdMember(c => c.Id);
            });            
        
            BsonClassMap.RegisterClassMap<QuoteModel>(map => {
                map.AutoMap();
                map.MapIdMember(c => c.Id);
            });            
        }

        /// <summary>
        ///
        /// </summary>
        public PageModel GetPageMetaData(string pageName = "home") {
            var query = this.ClientDB
                .GetCollection<PageModel>("pages").AsQueryable();

            var results = from q in query
                select q;

            return results.First();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<QuoteModel> GetQuotes() {
            var query = this.ClientDB
                .GetCollection<QuoteModel>("quotes").AsQueryable();
            
            var results = from q in query
                select q;
                
            return results.ToList();
        }

        public IReadOnlyList<RoleModel> GetRoles() {
                throw new NotImplementedException();
        }

        public Boolean AddQuote(QuoteModel document) {            
            throw new NotImplementedException();
        }
    }
}