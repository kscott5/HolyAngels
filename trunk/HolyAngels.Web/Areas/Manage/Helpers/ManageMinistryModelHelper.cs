using System;
using System.Collections.Generic;
using System.Linq;

using HolyAngels.Web.Areas.Manage.Models;
using HolyAngels.Web.Domains;
using HolyAngels.Web.Helpers;
using System.Web.Mvc;

using MvcContrib.Pagination;
using MvcContrib.Sorting;
using MvcContrib.UI.Grid;

namespace HolyAngels.Web.Areas.Manage.Helpers
{
    public static class ManageMinistryModelHelper
    {
        public static void GetPaginatedMinistryCategories(this PaginationModel<MinistryCategoryModel> model, int pageNumber = 1)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var data = (from m in db.MinistryCategories
                                orderby m.Name
                                select new MinistryCategoryModel
                                {
                                    Id = m.Id,
                                    IdKey = m.IdKey,
                                    
                                    Name = m.Name,
                                    Description = m.Description,
                                })
                                .OrderBy(model.SortOptions.Column, model.SortOptions.Direction)
                                .ToList();

                    model.Data = new CustomPagination<MinistryCategoryModel>(data, pageNumber, 20, data.Count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageMinistryModelHelper.GetPaginatedMinistries", ex);
                throw ex;
            }
        }

        /// <summary>
        /// Creates a paginated entity model used for the MinistriesController.Index view
        /// </summary>
        /// <param name="model">Pagination model for ministries</param>
        /// <param name="pageNumber">The page number to return</param>
        /// <returns></returns>
        public static void GetPaginatedMinistries(this PaginationModel<MinistryModel> model, int pageNumber = 1)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var data = (from m in db.Ministries
                                  orderby m.Name
                                  select new MinistryModel
                                  {
                                      Id = m.Id,
                                      IdKey = m.IdKey,
                                      Name = m.Name,
                                      Description = m.Description,
                                  })
                                .OrderBy(model.SortOptions.Column, model.SortOptions.Direction)
                                .ToList();

                    model.Data = new CustomPagination<MinistryModel>(data, pageNumber, 20, data.Count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageMinistryModelHelper.GetPaginatedMinistries", ex);
                throw ex;
            }
        }


        public static bool Add(this MinistryModel model, out Status status)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var entity = db.Ministries.Create();
                    entity.IdKey = Guid.NewGuid();
                    entity.Name = model.Name;
                    entity.Description = model.Description.Sanitize();
                    entity.Created = DateTime.Now;

                    entity = db.Ministries.Add(entity);
                    db.SaveChanges();

                    model.Id = entity.Id;
                    model.IdKey = entity.IdKey;

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("Manage.MinistryModelHelper.Add", ex);
                status = Status.SystemException;
            }

            return false;
        }

        public static bool Update(this MinistryModel model, out Status status)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var entity = (from m in db.Ministries
                                    where m.IdKey == model.IdKey
                                    select m).FirstOrDefault();

                    if (entity == null)
                    {
                        status = Status.DataNotFound;
                        return false;
                    }

                    entity.Name = model.Name;
                    entity.Description = model.Description.Sanitize();
                    entity.Modified = DateTime.Now;

                    db.SaveChanges();

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageMinistryModelHelper.Update", ex);
                status = Status.SystemException;
            }

            return false;
        }

        public static Ministry GetMinistry(Guid idKey)
        {
            
            try
            {
                using(var db = new DbContextHelper())
                {
                    var entity = (from m in db.Ministries.Include("Articles").Include("Events").Include("Users")
                              where m.IdKey == idKey
                              select m).FirstOrDefault();

                    return entity;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageMinistryModelHelper.Get", ex);
                throw ex;
            }
        }
        public static List<MinistryModel> GetMinstryModelsFromMinistries(this List<Ministry> list)
        {
            List<MinistryModel> models = new List<MinistryModel>();
            if (list == null)
                return models;

            foreach (var item in list)
            {
                models.Add(new MinistryModel
                {
                    Id = item.Id,
                    IdKey = item.IdKey,
                    Name = item.Name,
                    Description = item.Description
                });
            }

            return models;
        }


        public static List<Ministry> GetMinistriesFromModel(this List<MinistryModel> models)
        {
            List<Ministry> ministries = new List<Ministry>();
            if (models == null)
                return ministries;

            foreach (var model in models)
            {
                ministries.Add(new Ministry
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description
                });
            }

            return ministries;
        }

        /// <summary>
        /// Creates a paginated entity model used by the MinistriesController.Index method
        /// </summary>
        /// <param name="sort">Sort options</param>
        /// <param name="pageNumber">The page number to return</param>
        /// <returns></returns>
        public static PaginationModel<MinistryModel> GetMinistryModelForMinistries(GridSortOptions sort, int pageNumber = 1)
        {
            var column = (sort.Column == null) ? Constants.Sort_Column_Name : sort.Column;
            var direction = sort.Direction;

            var model = CommonModelHelper.GetPaginatedModel<MinistryModel>(column, direction);
            model.GetPaginatedMinistries(pageNumber);

            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels System Ministries";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        /// <summary>
        /// Creates a entity model used by the MinistriesController.Add method
        /// </summary>
        /// <returns></returns>
        public static MinistryModel GetMinistryModelForAdd()
        {
            var model = new MinistryModel();
            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels System Ministry";
            model.SubTitle = "Add New Ministry";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        /// <summary>
        /// Creates a entity model used by the MinistriesController.Edit method
        /// </summary>
        /// <returns></returns>
        public static MinistryModel GetMinistryModelForEdit(string id)
        {
            Guid idKey = (Guid.TryParse(id, out idKey)) ? idKey : Guid.Empty;

            var ministry = GetMinistry(idKey);
            if (ministry == null)
                return null;

            var model = ministry.GetMinistryModel();
            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels System Ministry";
            model.SubTitle = "Edit Ministry";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        public static MinistryModel GetMinistryModel(this Ministry ministry)
        {
            var model = new MinistryModel
            {
                Id = ministry.Id,
                IdKey = ministry.IdKey,
                Name = ministry.Name,
                Description = ministry.Description
            };

            return model;
        }

        public static List<MinistryModel> GetAllMinistries()
        {
            List<MinistryModel> models = new List<MinistryModel>();
            try
            {
                using (var db = new DbContextHelper())
                {
                    models = (from m in db.Ministries
                              orderby m.Name
                              select new MinistryModel
                              {
                                  Id = m.Id,
                                  IdKey = m.IdKey,
                                  Name = m.Name,
                                  Description = m.Description,
                              }).ToList();

                    return models;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageMinistryModelHelper.GetAllMinistries", ex);
                throw ex;
            }
        }

        public static List<MinistryModel> GetMinistryModels(string[] idKeys)
        {
            List<MinistryModel> models = new List<MinistryModel>();
            foreach (var idKey in idKeys)
            {
                models.Add(GetMinistryModel(idKey));
            }

            return models;
        }

        public static MinistryModel GetMinistryModel(string guid)
        {
            try
            {
                Guid idKey = Guid.Empty;
                if (!Guid.TryParse(guid, out idKey))
                    idKey = Guid.Empty;

                using (var db = new DbContextHelper())
                {
                    var model = (from m in db.Ministries
                                 where m.IdKey == idKey
                                 orderby m.Id descending
                                 select new MinistryModel
                                 {
                                     Id = m.Id,
                                     IdKey = m.IdKey,
                                     Name = m.Name,
                                     Description = m.Description,
                                 }).FirstOrDefault();

                    return model;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageMinistryModelHelper.GetMinistryModel", ex);
                throw ex;
            }
        }

        public static MultiSelectList GetMultiSelectedMinistries(List<MinistryModel> selectedModels = null)
        {
            List<MinistryModel> ministries = GetAllMinistries();

            MultiSelectList list = null;
            if (selectedModels != null && selectedModels.Count > 0)
                list = new MultiSelectList(ministries, "IdKey", "Name", selectedModels.Select(r => r.IdKey.ToString()).ToList());
            else
                list = new MultiSelectList(ministries, "IdKey", "Name");

            return list;
        }

        public static List<Ministry> GetMinistriesFromModel(this List<MinistryModel> models, DbContextHelper db)
        {
            List<Ministry> ministries = new List<Ministry>();

            try
            {
                var idKeys = models.Select(m => m.IdKey).ToList();
                ministries = (from m in db.Ministries
                         where idKeys.Contains(m.IdKey)
                         select m).ToList();

                return ministries;
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageMinistryModelHelper.GetMinistriesFromModel", ex);
                throw ex;
            }
        }
    }
}