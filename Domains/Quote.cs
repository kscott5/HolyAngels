using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolyAngels.Web.Domains
{
    public class Quote : BaseDomain
    {
        public virtual string Description { get; set; }
        public virtual string Source { get; set; }
        public virtual bool Approved { get; set; }
    }
}