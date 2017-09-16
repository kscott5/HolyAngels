using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using System.Collections.Specialized;

namespace HolyAngels.Models
{    
    public class UserModel
    {
        public UserModel()
        {
            UserStatus = UserStatus.Offline;
            Roles = new List<string>();
        }

        public string Id {get; set;}
        
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
        public string ScreenName { get; set; }
        public UserStatus UserStatus { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? LastAcecssed { get; set; }

        [Display(Name = "Role")]
        public List<string> Roles { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

    }
}