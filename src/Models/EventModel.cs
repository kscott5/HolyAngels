using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using HolyAngels.Attributes;

namespace HolyAngels.Models
{
    public class EventModel
    {
        public EventModel(){
            this.Timestamps = new Dictionary<string, DateTime?>();
            this.Timestamps.Add("StartDate", null);
            this.Timestamps.Add("StartTime", null);
            this.Timestamps.Add("EndDate", null);
            this.Timestamps.Add("EndTime", null);
        }

        public string Id {get; set;}       
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Speakers { get; set; }

        public Dictionary<string, DateTime?> Timestamps {get; set;}
   }
}