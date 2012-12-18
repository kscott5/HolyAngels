using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Web.Configuration;
using System.Configuration;

using HolyAngels.Web.Domains;
using HolyAngels.Web.Filters;
using HolyAngels.Web.Areas.Manage.Models;
using HolyAngels.Web.Areas.Manage.Helpers;
using System.Security.Principal;
using System.Data.SqlClient;

namespace HolyAngels.Web.Helpers
{
    public static class UserModelHelper
    {
        /// <summary>
        /// Authorize the users access from application (Logout)
        /// </summary>
        public static void Authorize()
        {
            try
            {
                var ticket = ManageUserModelHelper.GetFormsAuthenticationTicket();
                if (ticket != null)
                {
                    var idKey = ticket.IdKey();
                    if (idKey != Guid.Empty)
                    {
                        using (var db = new DbContextHelper())
                        {
                            User user = ManageUserModelHelper.GetUser(db, idKey);
                            if (user != null)
                            {
                                user.UserStatusEnum = UserStatus.Offline;
                                db.SaveChanges();
                            }
                        } //end using
                    } //end if
                } //end if
                FormsAuthentication.SignOut();
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("UserModelHelper.Authorize", ex);
                throw ex;
            }            
        }

        /// <summary>
        /// Authorize the current user on the site. Authenication occurs via Facebook app
        /// </summary>
        /// <param name="model"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static bool Authorize(this UserModel model, out Status status)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    var user = ManageUserModelHelper.GetUser(db, model.IdKey, model.Email);
                    if (user == null)
                    {
                        status = Status.InvalidLoginPassword;
                        return false;
                    }

                    user.AccessToken = model.AccessToken;
                    user.LastAccessed = DateTime.Now;
                    user.UserStatusEnum = UserStatus.Online;
                    db.SaveChanges();

                    // Save the user basic information
                    model.Id = user.Id;
                    model.IdKey = user.IdKey;
                    model.ScreenName = user.ScreenName;
                    model.FirstName = user.FirstName;
                    model.LastName = user.LastName;
                    model.UserStatus = user.UserStatusEnum;
                    model.Roles = user.Roles.ToList().GetRoleModelsFromRoles();

                    model.CreateAuthorizationTicket();

                    status = Status.Success;
                    return true;
                }
            }

            catch (Exception ex)
            {
                LogHelper.LogFatalError("UserModelHelper.Authorize", ex);
                status = Status.SystemException;
            }

            return false;
        }

        public static bool Register(this UserModel model, out Status status)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    if (model.EmailExists())
                    {
                        status = Status.DuplicateEmail;
                        return false;
                    }

                    var user = db.Users.Create();
                    user.Roles = new List<Role>();
                    
                    // TODO: Get Facebook app role for current user
                    //       If administrator or developer grant full access
                    if (false)
                    {
                        user.Roles.Add(ManageRoleModelHelper.GetRole(Role.ADMINISTRATOR_ID, db));
                        user.Roles.Add(ManageRoleModelHelper.GetRole(Role.CONTENT_APPROVER_ID, db));
                        user.Roles.Add(ManageRoleModelHelper.GetRole(Role.CONTENT_PUBLISHER_ID, db));
                        user.Roles.Add(ManageRoleModelHelper.GetRole(Role.MINISTRY, db));
                    }
                    else
                    {
                        user.Roles.Add(ManageRoleModelHelper.GetRole(Role.BASIC_ID, db));
                    }

                    user.IdKey = Guid.NewGuid();
                    user.FacebookId = model.FacebookId;
                    user.Link = model.Link;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.ScreenName = model.ScreenName;
                    user.AccessToken = model.AccessToken;
                    user.UserStatusEnum = UserStatus.Active;
                    user.Created = DateTime.Now;
                    user.LastAccessed = DateTime.Now;
                    user.Email = model.Email;
                    user.ScreenName = model.Email;
                    
                    user = db.Users.Add(user);
                    db.SaveChanges();

                    model.Id = user.Id;
                    model.IdKey = user.IdKey;
                    model.UserIdKey = user.IdKey;
                    
                    List<Role> roles = user.Roles as List<Role>;
                    model.Roles = roles.GetRoleModelsFromRoles();

                    model.CreateAuthorizationTicket();

                    status = Status.Success;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("UserModelHelper.Register", ex);
                status = Status.SystemException;
            }
            return false;
        }

        private static UserModel GetModelFromUser(User user)
        {
            try
            {
                return ManageUserModelHelper.GetModelFromUser(user);
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("UserModelHelper.GetModelFromUser", ex);
                throw ex;
            }
        }
    }
}