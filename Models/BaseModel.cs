using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            FirstName = "";
            LastName = "";
            ScreenName = "";
            Roles = new List<RoleModel>();
        }
        
        public int Id { get; set; }
        public Guid IdKey { get; set; }
        public Guid UserIdKey { get; set; }

        [Display(Name = "Role")]
        public List<RoleModel> Roles { get; set; }

        /// <summary>
        /// First name for user (Facebook = first_name)
        /// </summary>
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name for user (Facebook = last_name)
        /// </summary>
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// User name for user (Facebook = username)
        /// </summary>
        [Display(Name = "Screen Name")]
        public virtual string ScreenName { get; set; }
    }
}