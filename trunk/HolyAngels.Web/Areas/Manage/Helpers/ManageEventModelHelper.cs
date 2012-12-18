using System;
using System.Collections.Generic;
using System.Linq;
using HolyAngels.Web.Domains;
using HolyAngels.Web.Areas.Manage.Models;
using HolyAngels.Web.Helpers;

using MvcContrib.Pagination;
using MvcContrib.Sorting;
using MvcContrib.UI.Grid;

namespace HolyAngels.Web.Areas.Manage.Helpers
{
    public static class ManageEventModelHelper
    {
        /// <summary>
        /// Creates a paginated entity model used for the EventsController.Index view
        /// </summary>
        /// <param name="model">Paginated model of events</param>
        /// <param name="pageNumber">The page number to return</param>
        /// <returns></returns>
        public static void GetPaginatedEvents(this PaginationModel<EventModel> model, int pageNumber = 1)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var endDate = DateTime.Now.EndOfDay();
                    var data = (from e in db.Events 
                                where e.End > endDate select e)
                                .OrderBy(model.SortOptions.Column, model.SortOptions.Direction)
                                .ToList();

                    List<EventModel> models = new List<EventModel>();
                    foreach (var e in data)
                    {
                        models.Add(new EventModel
                                  {
                                      Id = e.Id,
                                      IdKey = e.IdKey,
                                      Title = e.Title,
                                      Description = e.Description,
                                      Start = e.Start,
                                      End = e.End,
                                      StartDate = e.Start.ToShortDateString(),
                                      EndDate = e.End.ToShortDateString(),
                                      StartTime = e.Start.ToString("hh:mm tt"),
                                      EndTime = e.End.ToString("hh:mm tt"),
                                      Speakers = e.Speakers,
                                      Location = e.Location,
                                      Approved = e.Approved,
                                  });
                    }

                    model.Data = new CustomPagination<EventModel>(models, pageNumber, 20, models.Count);
                }                
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageEventModelHelper.GetPaginatedEvents", ex);
                throw ex;
            }
        }


        public static bool Add(this EventModel model, out Status status)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var entity = db.Events.Create();
                    entity.IdKey = Guid.NewGuid();
                    entity.Title = model.Title;
                    entity.Description = model.Description.Sanitize();
                    entity.Start = Convert.ToDateTime(string.Format("{0} {1}", model.StartDate, model.StartTime));
                    entity.End = Convert.ToDateTime(string.Format("{0} {1}", model.EndDate, model.EndTime));
                    entity.Speakers = model.Speakers;
                    entity.Location = model.Location;
                    entity.Created = DateTime.Now;
                    entity.Approved = model.Approved;
                    
                    var ministries = model.Ministries.GetMinistriesFromModel(db);
                    if (ministries.Count > 0)
                    {
                        entity.Ministries = new List<Ministry>();
                        foreach (var ministry in ministries)
                            ministries.Add(ministry);
                    }

                    entity = db.Events.Add(entity);
                    db.SaveChanges();

                    model.Id = entity.Id;
                    model.IdKey = entity.IdKey;

                    model = GetEventModelForAdd();

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageEventModelHelper.Add", ex);
                status = Status.SystemException;
            }

            return false;
        }

        public static bool Update(this EventModel model, out Status status)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var entity = (from m in db.Events
                                  where m.IdKey == model.IdKey
                                  select m).FirstOrDefault();

                    if (entity == null)
                    {
                        status = Status.DataNotFound;
                        return false;
                    }

                    entity.Title = model.Title;
                    entity.Description = model.Description.Sanitize();
                    entity.Start = Convert.ToDateTime(string.Format("{0} {1}", model.StartDate, model.StartTime));
                    entity.End = Convert.ToDateTime(string.Format("{0} {1}", model.EndDate, model.EndTime));
                    entity.Speakers = model.Speakers;
                    entity.Location = model.Location;
                    entity.Modified = DateTime.Now;
                    entity.Approved = model.Approved;

                    if (entity.Ministries == null) entity.Ministries = new List<Ministry>();
                    var ministries = model.Ministries.GetMinistriesFromModel(db);
                    if (ministries.Count > 0)
                    {
                        entity.Ministries.Clear();
                        foreach (var ministry in ministries)
                            ministries.Add(ministry);
                    }

                    db.SaveChanges();

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageEventModelHelper.Update", ex);
                status = Status.SystemException;
            }

            return false;
        }

        public static bool Delete(Guid idKey, out Status status)
        {
            try
            {
                
                using (var db = new DbContextHelper())
                {
                    var entity = (from m in db.Events
                                  where m.IdKey == idKey
                                  select m).FirstOrDefault();

                    if (entity == null)
                    {
                        status = Status.DataNotFound;
                        return false;
                    }

                    entity = db.Events.Remove(entity);
                    db.SaveChanges();

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageEventModelHelper.Delete", ex);
                status = Status.SystemException;
            }

            return false;
        }

        public static Event GetEvent(Guid idKey)
        {

            try
            {
                using (var db = new DbContextHelper())
                {
                    var entity = (from m in db.Events
                                  where m.IdKey == idKey
                                  select m).FirstOrDefault();

                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageEventModelHelper.Get", ex);
                throw ex;
            }
        }
        
        /// <summary>
        /// Creates a paginated entity model used by the EventsController.Index method
        /// </summary>
        /// <param name="sort">Sort options</param>
        /// <param name="pageNumber">The page number to return</param>
        /// <returns></returns>
        public static PaginationModel<EventModel> GetEventModelForEvents(GridSortOptions sort, int pageNumber = 1)
        {
            var column = (sort.Column == null) ? Constants.Sort_Column_Title : sort.Column;
            var direction = sort.Direction;

            var model = CommonModelHelper.GetPaginatedModel<EventModel>(column, direction);
            model.GetPaginatedEvents(pageNumber);

            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels System Events";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        /// <summary>
        /// Creates a entity model used by the EventsController.Add method
        /// </summary>
        /// <returns></returns>
        public static EventModel GetEventModelForAdd()
        {
            var model = new EventModel();
            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels System Event";
            model.SubTitle = "Add New Event";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        /// <summary>
        /// Creates a entity model used by the EventsController.Edit method
        /// </summary>
        /// <returns></returns>
        public static EventModel GetEventModelForEdit(string id)
        {
            Guid idKey = (Guid.TryParse(id, out idKey)) ? idKey : Guid.Empty;

            var entity = GetEvent(idKey);
            if (entity == null)
                return null;

            var model = entity.GetEventModel();
            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels System Event";
            model.SubTitle = "Edit Event";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        public static EventModel GetEventModel(this Event entity)
        {
            var model = new EventModel
            {
                Id = entity.Id,
                IdKey = entity.IdKey,
                Title = entity.Title,
                Description = entity.Description,
                Start = entity.Start,
                End = entity.End,
                StartDate = entity.Start.ToShortDateString(),
                EndDate = entity.End.ToShortDateString(),
                StartTime = entity.Start.ToString("hh:mm tt"),
                EndTime = entity.End.ToString("hh:mm tt"),
                Speakers = entity.Speakers,
                Location = entity.Location,
                Approved = entity.Approved,
            };

            return model;
        }

        public static List<EventModel> GetEventModels(this List<Event> entities)
        {
            List<EventModel> models = new List<EventModel>();
            foreach (var entity in entities)
            {
                models.Add(new EventModel
                {
                    Id = entity.Id,
                    IdKey = entity.IdKey,
                    Title = entity.Title,
                    Description = entity.Description,
                    Start = entity.Start,
                    End = entity.End,
                    StartDate = entity.Start.ToShortDateString(),
                    EndDate = entity.End.ToShortDateString(),
                    StartTime = entity.Start.ToString("hh:mm tt"),
                    EndTime = entity.End.ToString("hh:mm tt"),
                    Speakers = entity.Speakers,
                    Location = entity.Location,
                    Approved = entity.Approved,
                });
            }

            return models;
        }
    }
}