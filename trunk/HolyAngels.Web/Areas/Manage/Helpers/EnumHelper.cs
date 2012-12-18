using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolyAngels.Web.Areas.Manage.Helpers
{
    public enum Status : int
    {
        Success = 1,
        Failure = 2,
        DuplicateEmail = 3,
        DuplicateScreenName = 4,
        DataNotFound = 5,
        InvalidLoginPassword = 6,
        SystemException = 7,
        RoleRequired = 8,
        MinistryRequired = 9,
        FacebookAccessFailed = 10,
    }

    /// <summary>
    /// Extension method for return messages for enums
    /// </summary>
    public static class EnumHelper
    {
        public static string Message(this Status status, string message = "")
        {
            switch (status)
            {
                case Status.DuplicateEmail: 
                    return (!string.IsNullOrEmpty(message))? message: "Email address already exists.";
                
                case Status.DuplicateScreenName: 
                    return (!string.IsNullOrEmpty(message))? message: "Screen name already exists.";
                
                case Status.Failure:
                    return (!string.IsNullOrEmpty(message)) ? message : "Could not processing your request as this time.";
                
                case Status.DataNotFound:
                    return (!string.IsNullOrEmpty(message)) ? message : "Could not locate the system information.";

                case Status.InvalidLoginPassword:
                    return (!string.IsNullOrEmpty(message)) ? message : "Invalid email/password.";

                case Status.RoleRequired:
                    return (!string.IsNullOrEmpty(message)) ? message : "Role required.";

                case Status.MinistryRequired:
                    return (!string.IsNullOrEmpty(message)) ? message : "Ministry required.";

                case Status.SystemException:
                    return (!string.IsNullOrEmpty(message)) ? message : "An unexpected error occurred.";

                case Status.FacebookAccessFailed:
                    return (!string.IsNullOrEmpty(message)) ? message : "Invalid Facebook account.";

                case Status.Success:
                default:
                    return (!string.IsNullOrEmpty(message)) ? message : "Successfull processed your request.";
            }
        }
    }
}