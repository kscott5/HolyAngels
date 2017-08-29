﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolyAngels.Domains
{
    public abstract class Category : BaseDomain
    {
        /// <summary>
        /// Discriminator column not required
        /// </summary>
        //public virtual int TypeId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }

    public class MinistryCategory : Category
    {
        public virtual ICollection<Ministry> Ministries { get; set; }
    }
}