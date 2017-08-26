using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolyAngels.Web.Domains
{
    public abstract class BaseDomain
    {
        public BaseDomain()
        {
            Created = DateTime.Now;
        }

        [Key]
        [Column("Id")]
        public virtual int Id { get; set; }
        public virtual Guid IdKey { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime? Modified { get; set; }
    }
}