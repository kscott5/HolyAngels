using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using HolyAngels.Attributes;

namespace HolyAngels.Models
{
    public class EventModel
    {
        public EventModel() {
            this.Speakers = new List<string>();
            
            this.TimeStamps = new Dictionary<string, DateTime?>();
            this.TimeStamps.Add("StartDate", null);
            this.TimeStamps.Add("StartTime", null);
            this.TimeStamps.Add("EndDate", null);
            this.TimeStamps.Add("EndTime", null);
        }

        public string Id {get; set;}       
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<string> Speakers { get; set; }

        public Dictionary<string, DateTime?> TimeStamps {get; set;}
   }
}