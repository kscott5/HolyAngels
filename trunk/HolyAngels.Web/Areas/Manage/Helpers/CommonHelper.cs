using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.Configuration;
using System.Net.Mail;
using System.Collections.Specialized;
using HolyAngels.Web.Domains;
using System.IO;
using System.Web.Mvc;
using System.Linq.Expressions;

using Microsoft.Security.Application;
using System.Web.Script.Serialization;
using System.Configuration;

namespace HolyAngels.Web.Areas.Manage.Helpers
{
    /// <summary>
    /// Defines helper class for common application operations
    /// </summary>
    public static class CommonHelper
    {
        /// <summary>
        /// Returns the query string information from the data 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static NameValueCollection ParseQueryString(this string data)
        {
            return HttpUtility.ParseQueryString( data );
        }

        /// <summary>
        /// Html encode the string data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HtmlEncode(this string data)
        {
            return HttpUtility.HtmlEncode(data);
        }

        /// <summary>
        /// Html decode the string data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HtmlDecode(this string data)
        {
            return HttpUtility.HtmlDecode(data);
        }
        
        /// <summary>
        /// Gets the HttpResponse from current HttpContext
        /// </summary>
        public static HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }

        /// <summary>
        /// Gets the HttpRequest for current HttpContext
        /// </summary>
        public static HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }

        /// <summary>
        /// Gets the authentication object from the web.config(system.web/authentiation) section 
        /// </summary>
        public static AuthenticationSection AuthenticationSection
        {
            get
            {
                return WebConfigurationManager.GetSection("system.web/authentication") as AuthenticationSection;
            }
        }

        /// <summary>
        /// Gets the web applicatioin configuration information
        /// </summary>
        public static Configuration WebConfiguration
        {
            get
            {
                return WebConfigurationManager.OpenWebConfiguration("~");
            }
        }

        /// <summary>
        /// Gets the form name from web.config(system.web/authentiation/forms) section 
        /// </summary>
        public static string FormName
        {
            get { return AuthenticationSection.Forms.Name; }
        }

        /// <summary>
        /// Gets the authentication mode from web.config(system.web/authentiation/mode) section 
        /// </summary>
        public static AuthenticationMode AuthenticiationMode
        {
            get
            {
                return AuthenticationSection.Mode;
            }
        }

        /// <summary>
        /// Gets the form timeout from web.config(system.web/authentiation/forms) section 
        /// </summary>
        public static double Timeout
        {
            get { return AuthenticationSection.Forms.Timeout.TotalMinutes; }
        }

        /// <summary>
        /// Gets the form path from web.config(system.web/authentiation/forms) section 
        /// </summary>
        public static string FormPath
        {
            get { return AuthenticationSection.Forms.Path; }
        }

        /// <summary>
        /// Sanitizes the data for bad html and scripts.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Sanitize(this string input)
        {
            input = Sanitizer.GetSafeHtml(input);
            return input;
        }

        /// <summary>
        /// Changes the time to 12:00:00 AM
        /// </summary>
        /// <param name="datetime">Current date time</param>
        /// <returns>new date time value</returns>
        public static DateTime StartOfDay(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, datetime.Day, 0, 0, 0);
        }

        /// <summary>
        /// Returns the first day of the month to mm/01/yyyy 12:00:00 AM
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime StartOfMonth(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, 1, 0, 0, 0);
        }

        /// <summary>
        /// Returns the last day of the month to mm/31/yyyy 11:59:59 PM
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime datetime)
        {
            int days = DateTime.DaysInMonth(datetime.Year, datetime.Month);
            return new DateTime(datetime.Year, datetime.Month, days, 23, 59, 59);
        }

        /// <summary>
        /// Changes the time to 11:59:59 PM
        /// </summary>
        /// <param name="datetime">Current date time</param>
        /// <returns>new date time value</returns>
        public static DateTime EndOfDay(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, datetime.Day, 23, 59, 59);
        }

        /// <summary>
        /// Method used to encrypt a string of text
        /// </summary>
        /// <param name="text">Value to encrypt</param>
        /// <returns>Encrypted text</returns>
        public static string Encrypt(string text)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(text, "MD5");
        }

        /// <summary>
        /// Method extracted from System.Web.Mvc.AuthorizeAttribute
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static List<string> SplitString(string original, char delimiter = ',')
        {
            if (string.IsNullOrEmpty(original))
            {
                List<string> data = new List<string>();
                data.Add("");
            
                return data;
            }
            
            // TODO: Determine what the following keywords are for?
            // let
            // where
            //select
            IEnumerable<string> source =
                from piece in original.Split(new char[]
				{
					delimiter
				})
                let trimmed = piece.Trim()
                where !string.IsNullOrEmpty(trimmed)
                select trimmed;
            return source as List<string>;
        }
        
        /// <summary>
        /// Replaces the tokenized information with actual values
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public static string ParseTokenizedData(string fileName, NameValueCollection keyValues)
        {
            StringBuilder data = new StringBuilder(ReadFile(fileName));
            foreach (var key in keyValues.AllKeys)
            {
                data = data.Replace(key, keyValues[key]);
            }

            return data.ToString();
        }

        /// <summary>
        /// Read a file for the system
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadFile(string fileName)
        {
            using (var stream = File.OpenText(fileName))
            {
                return stream.ReadToEnd();
            }            
        }

        /// <summary>
        /// Send the system user an email
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="isBodyHtml"></param>
        public static void SendMail(string to, string from, string subject, string body, bool isBodyHtml)
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            message.IsBodyHtml = isBodyHtml;
            message.BodyEncoding = ASCIIEncoding.UTF8;

            SendMail(message);
        }

        /// <summary>
        /// Sends system message
        /// </summary>
        /// <param name="message"></param>
        public static void SendMail(MailMessage message)
        {
            SmtpClient client = new SmtpClient();
            client.Send(message);            
        }

        /// <summary>
        /// Parse the JSON data into a dictionary
        /// </summary>
        /// <param name="json">JSON data to parse</param>
        /// <returns>Key value pair Dictionary</returns>
        public static Dictionary<string, object> ParseJSON(string json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var data = jss.DeserializeObject(json) as Dictionary<string, object>;
            
            if (data == null) 
                data = new Dictionary<string, object>();

            return data;
        }

        /// <summary>
        /// Constructs the host URL from current environment
        /// </summary>
        /// <returns></returns>
        public static string HostUrl()
        {
            var request = HttpContext.Current.Request;

            var hostUrl = string.Format("{0}://{1}",
                request.Url.Scheme,
                request.Url.Authority);

            LogHelper.LogDebugging("HostUrl: {0}", hostUrl);

            return hostUrl;
        }
    }
}