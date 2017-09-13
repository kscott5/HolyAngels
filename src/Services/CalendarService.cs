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

            var dateFilter = new DateTime(
                date?.Year?? DateTime.Now.Year,
                date?.Month?? DateTime.Now.Month,
                1
            );
            
            var collection = this.ClientDB.GetCollection<EventModel>("eventmodel")
                .Find(p => p.TimeStamps["StartDate"] >= dateFilter);

            return collection.ToList();            
        }

    }
}