using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using MongoDB.Driver;

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

        public HomeModel GetPageMetaData(string pageName = "home") {
            this.ClientDB.GetCollection<HomeModel>("PageMetaData", null);

            throw new NotImplementedException();
        }
    }
}
