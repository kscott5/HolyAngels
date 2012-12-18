using System;
using System.Collections.Generic;
using System.Linq;

using HolyAngels.Web.Domains;
using HolyAngels.Web.Helpers;

using HolyAngels.Web.Areas.Manage.Models;
using System.Configuration;

using MvcContrib.Pagination;
using MvcContrib.Sorting;
using MvcContrib.UI.Grid;
using System.Web.Security;
using System.Web;
using System.Web.Configuration;
using HolyAngels.Web.Filters;
using System.Collections.Specialized;

namespace HolyAngels.Web.Areas.Manage.Helpers
{
    public static class ManageUserModelHelper 
    {
        private static readonly string ID_KEY = "ID_KEY";
        private static readonly string ACCESS_TOKEN = "ACCESS_TOKEN";
        private static readonly string ROLES = "ROLES";

        /// <summary>
        /// Creates or updates the authoziation currentTicket information for current user
        /// </summary>
        /// <param name="model"></param>
        public static void CreateAuthorizationTicket(this UserModel model)
        {
            var name = (!string.IsNullOrEmpty(model.FirstName)) ? model.FirstName
                : (!string.IsNullOrEmpty(model.ScreenName)) ? model.ScreenName : model.Email;

            var userData = string.Format("IdKeyGuid={0}&AccessToken={1}&Roles={2}", model.IdKey, model.AccessToken, model.Roles.ListToString());

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, name, DateTime.Now,
            DateTime.Now.AddMinutes(CommonHelper.Timeout), true, userData, CommonHelper.FormPath);

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            HttpCookie cookie = new HttpCookie(CommonHelper.FormName, encryptedTicket);
            CommonHelper.Response.Cookies.Remove(CommonHelper.FormName);
            CommonHelper.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Gets the system identification key from FormsAuthenticationTicket
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static Guid IdKey(this FormsAuthenticationTicket ticket)
        {
            return new Guid(ticket.GetUserData()[ID_KEY]);
        }

        /// <summary>
        /// Gets the Facebook access token from FormsAuthenticationTicket
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static string AccessToken(this FormsAuthenticationTicket ticket)
        {
            return ticket.GetUserData()[ACCESS_TOKEN];
        }

        /// <summary>
        /// Gets the system identification key from FormsAuthenticationTicket
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static List<string> Roles(this FormsAuthenticationTicket ticket)
        {
            NameValueCollection userData = ticket.GetUserData();
            List<string> roles = CommonHelper.SplitString(userData[ROLES]);

            return roles;
        }

        /// <summary>
        /// Gets the user data from the FormsAuthenticationTicket
        /// </summary>
        /// <param name="ticket">Forms Authenticiation Ticket</param>
        /// <returns>Name value collection of data</returns>
        private static NameValueCollection GetUserData(this FormsAuthenticationTicket ticket)
        {
            NameValueCollection collection = new NameValueCollection();
            
            try
            {
                var userData = HttpUtility.ParseQueryString(ticket.UserData);
                collection.Set(ID_KEY, userData[ID_KEY]);
                collection.Set(ROLES, userData[ROLES]);
                collection.Set(ACCESS_TOKEN, userData[ACCESS_TOKEN]);
            }
            catch
            {
                collection.Set(ID_KEY, Guid.Empty.ToString());
                collection.Set(ROLES, "");
                collection.Set(ACCESS_TOKEN, "");
            }

            return collection;
        }

        public static FormsAuthenticationTicket GetFormsAuthenticationTicket()
        {            
            try
            {
                HttpCookie cookie = CommonHelper.Request.Cookies[CommonHelper.FormName];
                if (cookie == null || cookie.Value == null)
                    return null;

                return FormsAuthentication.Decrypt(cookie.Value);
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("UserModelHelper.GetFormsAuthenticationTicket", ex);              
            }

            return null;
        }

        /// <summary>
        /// Extension
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static bool AuthorizeCore(this FormsAuthorizeAttribute attribute)
        {
            try
            {
                var ticket = GetFormsAuthenticationTicket();
                if (ticket == null)
                    return false;
                
                var authRoles = CommonHelper.SplitString(attribute.Roles);
                return authRoles.Any(new Func<string, bool>(ticket.IsInRole));
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("UserModelHelper.AuthorizeCore", ex);
                throw ex;
            }
        }

        /// <summary>
        /// Determines if the role is contained with the ticket
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        private static bool IsInRole(this FormsAuthenticationTicket ticket, string role)
        {
            NameValueCollection userData = ticket.GetUserData();
            var ticketRoles = CommonHelper.SplitString(userData[ROLES]);
            return ticketRoles.Contains(role);
        }

        /// <summary>
        /// Determines if the email address exists in the system
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool EmailExists(this UserModel model)
        {
            bool result = false;
            try
            {
                using (var db = new DbContextHelper())
                {
                    result = db.Users
                        .Where(u => u.Email.Equals(model.Email) && u.IdKey != model.IdKey)
                            .Select(u => true)
                            .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("UserModelHelper.EmailExists", ex);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Determines if the screen name exists in the system
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool ScreenNameExists(this UserModel model)
        {
            bool result = false;
            try
            {
                using (var db = new DbContextHelper())
                {
                    result = db.Users
                        .Where(u => u.ScreenName.Equals(model.ScreenName) && u.IdKey != model.IdKey)
                            .Select(u => true)
                            .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("UserModelHelper.ScreenNameExists", ex);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Gets a paginated listed of system users
        /// </summary>
        /// <param name="model">Paginated model for managed users</param>
        /// <param name="pageNumber">the page number to return</param>
        /// <returns></returns>
        public static void GetPaginatedUsers(this PaginationModel<UserModel> model, int pageNumber = 1)
        {
            try
            {
                using(var db = new DbContextHelper())
                {
                    var data = (from u in db.Users
                                select new UserModel
                                {
                                    Id = u.Id,
                                    IdKey = u.IdKey,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    ScreenName = u.ScreenName,
                                    Email = u.Email,
                                    UserStatus = (UserStatus)u.UserStatus,
                                })
                                .OrderBy(model.SortOptions.Column, model.SortOptions.Direction)
                                .ToList();

                    model.Data = new CustomPagination<UserModel>(data, pageNumber, 20, data.Count);                                 
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("UserModelHelper.GetPaginatedUsers", ex);
                throw ex;
            }
        }

        /// <summary>
        /// Creates model for the Manage.UserController.Index action
        /// </summary>
        /// <returns></returns>
        public static PaginationModel<UserModel> GetUserModelForUsers(GridSortOptions sort, int pageNumber = 1)
        {
            var column = (sort.Column == null) ? Constants.Sort_Column_LastName : sort.Column;
            var direction = sort.Direction;

            var model = CommonModelHelper.GetPaginatedModel<UserModel>(column, direction);
            model.GetPaginatedUsers(pageNumber);

            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels System Users";
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        /// <summary>
        /// Creates model for the Manage.UserController.Add action
        /// </summary>
        /// <returns></returns>
        public static UserModel GetUserModelForAdd()
        {
            var model = new UserModel();
            model.UpdateUserModelForAdd();
            return model;
        }

        /// <summary>
        /// Updates the model for the Manage.UserController.Add post action
        /// </summary>
        /// <returns></returns>
        public static void UpdateUserModelForAdd(this UserModel model)
        {
            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels Add New System User";
            model.SubTitle = "New System User";
            model.UserIdKey = userIdKey;

            model.MultiSelectRoleList = ManageRoleModelHelper.GetMultiSelectedRoles();
            model.MultiSelectMinistryList = ManageMinistryModelHelper.GetMultiSelectedMinistries();

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";
        }

        /// <summary>
        /// Creates model for the Manage.UserController.Edit action
        /// </summary>
        /// <param name="idKey"></param>
        /// <returns></returns>
        public static UserModel GetUserModelForEdit(string idKey)
        {
            Guid id = (Guid.TryParse(idKey, out id)) ? id : Guid.Empty;
            var model = ManageUserModelHelper.Get(id);

            Guid userIdKey = ManageUserModelHelper.GetFormsAuthenticationTicket().IdKey();

            model.PageTitle = "Holy Angels Profile Page";
            model.SubTitle = (userIdKey == id) ? "My Profile" : "Edit User Profile";
            model.IdKey = id;
            model.UserIdKey = userIdKey;

            model.MetaDescription = "";
            model.MetaKeywords = "";
            model.MetaSubject = "";

            return model;
        }

        /// <summary>
        /// Gets the user from the application database
        /// </summary>
        /// <param name="db">Database context helper (required)</param>
        /// <param name="idKey">System generated identification key (required)</param>
        /// <param name="email">Email address (Facebook me.email)</param>
        /// <param name="screenName">Screen name (Facebook me.username)</param>
        /// <param name="accessToken">Access Token (Facebook Login Dialog and Open Graph API OAuth)</param>
        /// <param name="facebookId">Numeric identification code (Facebook me.id)</param>
        /// <returns></returns>
        public static User GetUser(DbContextHelper db, Guid idKey, string email = "", string screenName ="", string accessToken = "", int facebookId = -1)
        {
            User user = null;
            try
            {
                // Note: order is important on the Include clause
                // If token is set the user status will be for example ResetPassword, etc
                user = (from u in db.Users.Include("Ministries").Include(ROLES)
                        where u.IdKey == idKey || u.Email.Equals(email) || u.ScreenName.Equals(screenName) || u.AccessToken.Equals(accessToken)
                        select u).FirstOrDefault();
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("UserModelHelper.GetUser", ex);
                throw ex;
            }

            return user;
        }

        /// <summary>
        /// Gets the application user
        /// </summary>
        /// <param name="idKey">System generated identification key</param>
        /// <returns></returns>
        public static UserModel Get(Guid idKey)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var user = GetUser(db, idKey);
                    return GetModelFromUser(user);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("UserModelHelper.Get", ex);
                throw ex;
            }
        }

        private static User CreateNewUserFromModel(UserModel model, DbContextHelper db)
        {
            if (model == null)
                return null;

            User user = db.Users.Create();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.ScreenName = model.ScreenName;
            user.Email = model.Email;
            user.UserStatusEnum = model.UserStatus;
            user.LastAccessed = model.LastAcecssed;
            user.Created = model.Created;
            user.IdKey = model.IdKey;

            var roles = ManageRoleModelHelper.GetRolesFromModel(model.Roles, db);
            if (roles.Count > 0)
            {
                user.Roles = new List<Role>();
                foreach (var role in roles)
                    user.Roles.Add(role);
            }

            var ministries = ManageMinistryModelHelper.GetMinistriesFromModel(model.Ministries, db);
            if (ministries.Count > 0)
            {
                user.Ministries = new List<Ministry>();
                foreach (var ministry in ministries)
                    user.Ministries.Add(ministry);
            }

            return user;
        }

        public static UserModel GetModelFromUser(User user)
        {
            if (user == null)
                return null;

            var roles = user.Roles.ToList().GetRoleModelsFromRoles();
            var ministries = user.Ministries.ToList().GetMinstryModelsFromMinistries();
            return new UserModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ScreenName = user.ScreenName,
                Email = user.Email,
                Link = user.Link,
                AccessToken= user.AccessToken,
                FacebookId = user.FacebookId,
                UserStatus = user.UserStatusEnum,
                LastAcecssed = user.LastAccessed,
                Created = user.Created,
                Id = user.Id,
                IdKey = user.IdKey,
                Roles = roles,
                MultiSelectRoleList = ManageRoleModelHelper.GetMultiSelectedRoles(roles),
                Ministries = ministries,
                MultiSelectMinistryList = ManageMinistryModelHelper.GetMultiSelectedMinistries(ministries),
            };
        }

        public static User GetUserFromModel(UserModel model, DbContextHelper db)
        {
            if (model == null)
                return null;

            User user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                ScreenName = model.ScreenName,
                Email = model.Email,
                Link = model.Link,
                AccessToken = model.AccessToken,
                FacebookId = model.FacebookId,                
                UserStatusEnum = model.UserStatus,
                LastAccessed = model.LastAcecssed,
                Created = model.Created,
                Id = model.Id,
                Roles = ManageRoleModelHelper.GetRolesFromModel(model.Roles, db)
            };

            return user;
        }

        public static bool Add(this UserModel model, out Status status)
        {
            try
            {
                if (model.Roles.Count == 0)
                {
                    status = Status.RoleRequired;
                    return false;
                }

                if (model.EmailExists())
                {
                    status = Status.DuplicateEmail;
                    return false;
                }

                if (model.ScreenNameExists())
                {
                    status = Status.DuplicateScreenName;
                    return false;
                }
                
                using (var db = new DbContextHelper())
                {
                    var user = CreateNewUserFromModel(model, db);                    
                    user.UserStatusEnum = UserStatus.Inactive;
                    user.Created = DateTime.Now;
                    user.LastAccessed = DateTime.Now;
                    user.ScreenName = user.ScreenName ?? user.Email;                    
                    
                    user = db.Users.Add(user);
                    db.SaveChanges();

                    model = GetUserModelForAdd();

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("Manage.UserModelHelper.Add", ex);
                throw ex;
            }
        }

        public static bool Update(this UserModel model, out Status status)
        {
            try
            {                
                if (model.EmailExists())
                {
                    status = Status.DuplicateEmail;
                    return false;
                }

                if (model.ScreenNameExists())
                {
                    status = Status.DuplicateScreenName;
                    return false;
                }
                
                using (var db = new DbContextHelper())
                {
                    User entity = GetUser(db, model.IdKey);

                    if (entity == null)
                    {
                        status = Status.DataNotFound;
                        return false;
                    }

                    entity.FirstName = model.FirstName;
                    entity.LastName = model.LastName;
                    entity.ScreenName = model.ScreenName;
                    entity.Modified = DateTime.Now;

                    entity.AccessToken = model.AccessToken;
                    entity.FacebookId = model.FacebookId;
                    entity.Link = model.Link;

                    var currentTicket = GetFormsAuthenticationTicket();
                    if (currentTicket.IsInRole("Administrator"))
                    {
                        if (model.Roles.Count == 0)
                        {
                            status = Status.RoleRequired;
                            return false;
                        }


                        // Update the entity user/item relationship
                        entity.Roles.Clear();
                        var roles = model.Roles.GetRolesFromModel(db);
                        foreach (var item in roles)
                        {
                            entity.Roles.Add(item);
                        }

                        entity.Ministries.Clear();
                        // Update the entity user/ministry relationship
                        if (model.Ministries != null && model.Ministries.Count > 0)
                        {
                            var ministries = model.Ministries.GetMinistriesFromModel(db);
                            foreach (var item in ministries)
                            {
                                entity.Ministries.Add(item);
                            }
                        }
                    } //end IsInRole check

                    db.SaveChanges();
                    
                    try // Re-issue authorization currentTicket
                    { 
                        // Get current user id
                        Guid userIdKey = currentTicket.IdKey();

                        // Match?
                        if (userIdKey == entity.IdKey)
                            model.CreateAuthorizationTicket();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.LogFatalError("UserModelHelper.Update", ex);
                    }

                    model = GetUserModelForEdit(entity.IdKey.ToString());

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("Manage.UserModelHelper.Edit", ex);
                status = Status.SystemException;
            }

            return false;
        }        
    }
}