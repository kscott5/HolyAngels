using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Web.Mvc;

using HolyAngels.Web.Domains;
using HolyAngels.Web.Areas.Manage.Models;

namespace HolyAngels.Web.Areas.Manage.Helpers
{
    /// <summary>
    /// Defines class for managing application models
    /// </summary>
    public static class ManageRoleModelHelper
    {        
        public static RoleModel GetRoleModel(this Role role)
        {
            return new RoleModel { Id = role.Id,
                Description = role.Description,
                Name = role.Name,
            };                
        }

        public static Role GetRole(int id, DbContextHelper db)
        {
            try
            {
                var role = (from r in db.Roles
                            where r.Id == id || r.Id == Role.BASIC_ID
                            orderby r.Id descending
                            select r).FirstOrDefault();

                return role;
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageRoleModelHelper.GetRole", ex);
                throw ex;
            }
        }

        public static List<RoleModel> GetRoleModels(string[] ids)
        {
            List<RoleModel> models = new List<RoleModel>();
            foreach (var id in ids)
            {
                models.Add(GetRoleModel(id));
            }

            return models;
        }

        /// <summary>
        /// Gets a list of select models
        /// </summary>
        /// <param name="items"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<Role> GetRoles(this List<SelectListItem> items, DbContextHelper db)
        {
            List<Role> roles = new List<Role>();

            try
            {
                var idKeys = items.Where(i => i.Selected == true).Select(i => new Guid(i.Value)).ToList();
                roles = (from r in db.Roles
                         where idKeys.Contains(r.IdKey)
                         select r).ToList();

                // Always return at least basic item
                if (roles.Count == 0)
                    roles.Add(GetRole(Role.BASIC_ID, db));

                return roles;
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageRoleModelHelper.GetRoles", ex);
                throw ex;
            }
        }

        public static RoleModel GetRoleModel(string guid)
        {
            try
            {
                Guid idKey = Guid.Empty;
                if (!Guid.TryParse(guid, out idKey))
                    idKey = Guid.Empty;

                using (var db = new DbContextHelper())
                {
                    var model = (from r in db.Roles
                                 where r.IdKey == idKey || r.Id == Role.BASIC_ID //include basic 
                                 orderby r.Id descending
                                 select new RoleModel
                                 {
                                     Id = r.Id,
                                     IdKey = r.IdKey,
                                     Name = r.Name,
                                     Description = r.Description,
                                 }).FirstOrDefault();

                    return model;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageRoleModelHelper.GetRoleModel", ex);
                throw ex;
            }
        }


        public static List<Role> GetRolesFromModel(this List<RoleModel> models, DbContextHelper db)
        {
            List<Role> roles = new List<Role>();

            try
            {
                var idKeys = models.Select(m => m.IdKey).ToList();
                roles = (from r in db.Roles
                         where idKeys.Contains(r.IdKey)
                         select r).ToList();

                // Always return at least basic item
                if (roles.Count == 0)
                    roles.Add(GetRole(Role.BASIC_ID, db));

                return roles;
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("ManageRoleModelHelper.GetRolesFromModel", ex);
                throw ex;
            }
        }

        public static List<RoleModel> GetRoleModelsFromRoles(this List<Role> roles)
        {
            List<RoleModel> models = new List<RoleModel>();
            if (roles == null)
                return models;

            foreach (var role in roles)
            {
                models.Add(new RoleModel
                {
                    Id = role.Id,
                    IdKey = role.IdKey,
                    Name = role.Name,
                    Description = role.Description
                });
            }

            return models;
        }

        /// <summary>
        /// Converts the list of item models to string value
        /// </summary>
        /// <param name="models">List of item models</param>
        /// <returns></returns>
        public static string ListToString(this List<RoleModel> roles)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var role in roles)
            {
                if (builder.Length > 0)
                    builder.Append(",");

                builder.Append(role.Name);
            }

            return builder.ToString();
        }

        public static MultiSelectList GetMultiSelectedRoles(List<RoleModel> selectedModels = null)
        {
            List<RoleModel> roles = GetAllRoles();

            MultiSelectList list = null;            
            if(selectedModels != null && selectedModels.Count > 0)
                list = new MultiSelectList(roles, "IdKey", "Name", selectedModels.Select(r => r.IdKey.ToString()).ToList());
            else
                list = new MultiSelectList(roles, "IdKey", "Name");

            return list;
        }

        public static List<RoleModel> GetAllRoles()
        {
            List<RoleModel> roles = new List<RoleModel>();
            try
            {
                using(var db = new DbContextHelper())
                {
                    roles = (from r in db.Roles
                             orderby r.Name
                             select new RoleModel
                             {
                                 Id = r.Id,
                                 IdKey = r.IdKey,
                                 Name = r.Name,
                                 Description = r.Description
                             }).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("Manage.RoleModelHelper.GetAllMinistries", ex);
            }
            return roles;
        }
    }
}