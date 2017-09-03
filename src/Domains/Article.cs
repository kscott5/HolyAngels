using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolyAngels.Domains
{
    public class Article : BaseDomain
    {
        public virtual string Title { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string Description { get; set; }
        public virtual string Summary { get; set; }
        public virtual string Keywords { get; set; }
        public virtual string Author { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual DateTime End { get; set; }
        public virtual bool Approved { get; set; }
        public virtual ICollection<Ministry> Ministries { get; set; }
    }
}