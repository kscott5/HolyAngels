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

using HolyAngels.AdminPanel.Models;

namespace HolyAngels.AdminPanel.Services {
    public abstract class AdminDataService {
        protected IMongoDatabase ClientDB {get; private set;}
        
        protected IConfigurationSection Configuration {get; private set; }

        protected ILogger Logger {get; private set;}

        public AdminDataService(IConfiguration configuration, ILoggerFactory factory, string name = "Base") {
            this.Logger = factory.CreateLogger(string.Format("{0}-DataService", name));

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
            BsonClassMap.RegisterClassMap<RoleModel>(map => {
                map.AutoMap();
                map.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<UserModel>(map => {
                map.AutoMap();
                map.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });
        }
    }
}
