using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

using HolyAngels.Web.Areas.Manage.Helpers;
using System.Text;
using System.Web.Mvc;
using HolyAngels.Web.Domains;
using System.Web.Security;
using HolyAngels.Web.Areas.Manage.Models;
using System.Collections.Specialized;

namespace HolyAngels.Web.Helpers
{
    public static class FacebookHelper
    {
        /// <summary>
        /// Gets the Facebook Application Identifier
        /// </summary>
        /// <remarks>TODO: Pull from application configuration</remarks>
        public static string APP_ID
        {
            get
            {                
                return "121402298021026";
            }
        }

        /// <summary>
        /// Gets the Facebook Application Secret
        /// </summary>
        /// <remarks>TODO: Pull from application configuration</remarks>
        public static string APP_SECRET
        {
            get
            {
                return "48b0be8fefdab11edf892edc640c3139";
            }
        }

        /// <summary>
        /// Gets the Facebook Open Graph API URL
        /// </summary>
        /// <remarks>TODO: Pull from application configuration</remarks>
        public static string OPEN_GRAPH_URL
        {
            get
            {
                return "https://graph.facebook.com";
            }
        }

        /// <summary>
        /// Deauthorize the facebook user on our application (signout)
        /// </summary>
        public static void Deauthorize()
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
                LogHelper.LogFatalError("FacebookHelper.Deauthorize", ex);
                throw ex;
            }
        }

        /// <summary>
        /// Gets a user model using the Facebook Oauth code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static UserModel GetUserModel(string code, out Status status)
        {
            string accessToken = GetAccessToken(code);
            var model = GetMe(accessToken);

            status = Status.Success;
            if (model == null)
            {
                model = new UserModel();

                model.SubTitle = "Authorization";
                model.PageTitle = "Holy Angels Site Authorization Page";

                status = Status.FacebookAccessFailed;
            }

            return model;
        }

        /// <summary>
        /// Authorize the current user on the site. Authenication occurs via Facebook app (signin)
        /// </summary>
        /// <param name="model">User model</param>
        /// <param name="status">status of authorizing the user</param>
        /// <param name="code">Facebook Oauth code used to retrieve a Facebook access token</param>
        /// <returns></returns>
        /// <remarks>Requires the code to be set on the model. This is used to retrieve a Facebook access token</remarks>
        public static bool Authorize(this UserModel model, string code, out Status status)
        {
            try
            {
                using (var db = new DbContextHelper())
                {
                    // TODO: Validate the access token

                    var user = ManageUserModelHelper.GetUser(db, idKey: model.IdKey, email: model.Email, screenName: model.ScreenName, facebookId: model.FacebookId);
                    if (user == null)
                    {
                        return model.Register(out status);
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
                LogHelper.LogFatalError("FacebookHelper.Authorize", ex);
                status = Status.SystemException;
            }

            return false;
        }

        /// <summary>
        /// Registers a new user on our application using the information
        /// </summary>
        /// <param name="model">User with the Facebook access token set to a valid value.</param>
        /// <param name="status">Status of registring this user</param>
        /// <returns></returns>
        /// <remarks>Users is not on our system yet. The model's Facebook access token must be set in order to register the user on our application.</remarks>
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
                LogHelper.LogFatalError("FacebookHelper.Register", ex);
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

        /// <summary>
        /// Gets the Facebook Open Graph API Oauth return code
        /// </summary>
        /// <remarks>TODO: Pull from application configuration</remarks>
        public static string OAUTH_CODE
        {
            get
            {
                return "code";
            }
        }
        
        /// <summary>
        /// Get the web request for the specified URL
        /// </summary>
        /// <param name="url">Web address you are requesting</param>
        /// <returns>Raw response data from the web request</returns>
        public static string GetWebRequest(string url)
        {
            string data = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                
                try
                {
                    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                    {
                        data = stream.ReadToEnd();
                        stream.Close();
                    }
                }

                finally
                {
                    if (response != null)
                        response.Close();
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("FacebookHelper:GetWebRequest Failed", ex);
            }

            return data;
        }
        
        /// <summary>
        /// Gets the user access token
        /// </summary>
        /// <param name="code">Facebook code return from Login Dialog Oauth</param>
        /// <returns></returns>
        public static string GetAccessToken(string code)
        {
            string accessToken = null;

            try
            {
                LogHelper.LogDebugging("FacebookHelper.GetAccessToken");

                string returnUrl = string.Format("{0}/user/login", CommonHelper.HostUrl());
                string url = string.Format("{0}/oauth/access_token?client_id={1}" +
                                           "&redirect_uri={2}&client_secret={3}&code={4}", 
                                           OPEN_GRAPH_URL, APP_ID, returnUrl, APP_SECRET, code);

                string data = GetWebRequest(url);

                var qstring = data.ParseQueryString();
                accessToken = qstring["access_token"];
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("FacebookHelper.GetAccessToken", ex);
            }

            return accessToken;
        }
        
        /// <summary>
        /// Get the Facebook information for the access token
        /// </summary>
        /// <param name="accessToken"></param>
        public static UserModel GetMe(string accessToken)
        {
            UserModel model = null;
            try
            {
                LogHelper.LogDebugging("FacebookHelper.GetMe");
                string url = string.Format("{0}/me/?access_token={1}", CommonHelper.HostUrl(), accessToken);
                string data = GetWebRequest(url);

                Dictionary<string, object> user = CommonHelper.ParseJSON(data);
                user.Add("access_token", accessToken);

                model = UserModel.Create(user);
            }
            catch (Exception ex)
            {
                LogHelper.LogFatalError("Facebook.GetMe", ex);
            }
            
            return model;
        }

        public static void PostToWall(string accessToken, string message)
        {
            var msgEncoded = message.HtmlEncode();

            string url = string.Format("{0}/me/feed?access_token={1}&message={2}", 
                    OPEN_GRAPH_URL, accessToken, msgEncoded);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sreader = new StreamReader(response.GetResponseStream()))
            {
                var data = sreader.ReadToEnd();
            }

        }

        public static void PostPray(string accessToken, string message)
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendFormat("access_token={0}\n\r", accessToken);
            buffer.AppendFormat("message", "");
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/me/holyangelschurch:pray");
            Stream stream = request.GetRequestStream();
        }
    }
}