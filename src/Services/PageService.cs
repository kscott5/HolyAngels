using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using MongoDB.Driver;
using MongoDB.Driver.Linq;

using HolyAngels.Models;

namespace HolyAngels.Services {
    public class PageService : DataService {
        private string SiteName {get; set;}
        private string SiteSlogan {get; set;}

        public PageService(IConfiguration configuration, ILoggerFactory factory) : 
            base(configuration, factory, "Page") {
            this.SiteName = configuration["SiteName"];
            this.SiteSlogan = configuration["SiteSlogan"];
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
    }
}
