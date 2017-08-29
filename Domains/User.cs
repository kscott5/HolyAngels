using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolyAngels.Domains
{
    [Flags]
    public enum UserStatus : int
    {
        Unknown = -1,
        Active = 0,
        Inactive = 1,
        Online = 2,
        Offline = 3,
        PasswordReset = 4,
    };

    public class User : BaseDomain 
    {
        /// <summary>
        /// (Facebook me.id)
        /// </summary>
        public virtual int FacebookId { get; set; }

        /// <summary>
        /// (Facebook me.link = public face url for user)
        /// </summary>
        public virtual string Link { get; set; }

        /// <summary>
        /// (Facebook me.first_name)
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// (Facebook me.last_name)
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// (Facebook me.username)
        /// </summary>
        public virtual string ScreenName { get; set; }

        /// <summary>
        /// (Facebook Open Graph OAuth token)
        /// </summary>
        public virtual string AccessToken { get; set; }

        /// <summary>
        /// (Facebook me.email)
        /// </summary>
        public virtual string Email { get; set; }

        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zipcode { get; set; }
        public virtual string Phone { get; set; }
        public virtual int PhoneType { get; set; }
        
        public virtual int UserStatus { get; set; }
        [NotMapped]
        public UserStatus UserStatusEnum
        {
            get
            {
                HolyAngels.Domains.UserStatus userStatus;
                if (!Enum.TryParse<HolyAngels.Domains.UserStatus>(UserStatus.ToString(), out userStatus))
                    userStatus = HolyAngels.Domains.UserStatus.Unknown;
                return userStatus;
            }
            set
            {
                UserStatus = (int)value;
            }
        }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Ministry> Ministries { get; set;}

        public virtual DateTime? LastAccessed { get; set; }
    }
}