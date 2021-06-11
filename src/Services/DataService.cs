using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

using HolyAngels.Models;

namespace HolyAngels.Services {
    public abstract class DataService {
        protected IMongoDatabase ClientDB {get; private set;}
        
        protected IConfigurationSection Configuration {get; private set; }

        protected ILogger Logger {get; private set;}

        public DataService(IConfiguration configuration, ILoggerFactory factory, string name = "Base") {
            this.Logger = factory.CreateLogger($"{name}-DataService");

            this.Configuration = configuration.GetSection("DataService");

            var url = this.Configuration["Url"]?? "mongodb://localhost:27017/holyangels"; 
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

            BsonClassMap.RegisterClassMap<EventModel>(map => {
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
    }
}
