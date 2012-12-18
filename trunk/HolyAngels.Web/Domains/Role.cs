using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HolyAngels.Web.Domains
{
    /// <summary>
    /// Defines a base class for application models
    /// </summary>
    public class Role : BaseDomain
    {
        public static readonly int BASIC_ID = 1;
        public static readonly int ADMINISTRATOR_ID = 2;
        public static readonly int MINISTRY = 3;
        public static readonly int CONTENT_PUBLISHER_ID = 4;
        public static readonly int CONTENT_APPROVER_ID = 5;

        /// <summary>
        /// Gets or sets the name for the item
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or set the description for the item
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the users assigned to the item
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}