using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolyAngels.Web.Models;
using HolyAngels.Web.Domains;
using HolyAngels.Web.Areas.Manage.Helpers;
using HolyAngels.Web.Areas.Manage.Models;

namespace HolyAngels.Web.Helpers
{
    public static class EventCalendarModelHelper
    {
        public static List<EventModel> GetEvents(DateTime start, DateTime end)
        {
            List<EventModel> events = new List<EventModel>();
            try
            {
                start = start.StartOfMonth();
                end = end.EndOfMonth();

                using (var db = new DbContextHelper())
                {
                    events = (from e in db.Events
                              where e.Start >= start && e.End <= end && e.Approved == true
                              orderby e.Start
                              select new EventModel
                              {
                                  Id = e.Id,
                                  IdKey = e.IdKey,
                                  Title = e.Title,
                                  Location = e.Location,
                                  Speakers = e.Speakers,
                                  Description = e.Description,
                                  Start = e.Start,
                                  End = e.End,
                              }).ToList();

                    return events;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("EventCalendarModelHelper.GetEvents(start, end)", ex);
                throw ex;
            }
        }        
    }
}