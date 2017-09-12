using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

using HolyAngels.Models;

namespace HolyAngels.Services
{
    public class CalendarService : DataService
    {
        public CalendarService(IConfiguration configuration, ILoggerFactory factory) : 
            base(configuration, factory, "Calendar") {
        }

        /// <summary>
        /// Retreives monthly calendar events from data store
        /// </summary>    
        public IReadOnlyList<EventModel> GetMonthlyEvents(DateTime? date) {
            // Cache and Asychronous call?
            var query = this.ClientDB
                .GetCollection<EventModel>("eventmodel").AsQueryable();
            
            var month = date?.Month?? DateTime.Now.Month;
            var year = date?.Year?? DateTime.Now.Year;

            // At a minimum, order by day of month 
            var results = (from q in query
                where q.Timestamps["StartDate"].HasValue  &&
                      q.Timestamps["StartDate"].Value.Month == month &&
                      q.Timestamps["StartDate"].Value.Year == year
                orderby q.Timestamps["StartDate"].Value.Day ascending
                select q).ToList();

            return results;
        }

    }
}