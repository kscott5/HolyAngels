using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HolyAngels.Web.Domains
{
    [Table("Ministries")]
    public class Ministry : BaseDomain
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<MinistryCategory> Categories { get; set; }
    }
}