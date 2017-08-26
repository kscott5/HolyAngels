using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace HolyAngels.Web.Domains
{
    public class Event : BaseDomain
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Location { get; set; }
        public virtual string Speakers { get; set; }

        public virtual ICollection<Ministry> Ministries { get; set; }

        public virtual DateTime Start { get; set; }
        public virtual DateTime End { get; set; }
        public virtual bool Approved { get; set; }
    }
}