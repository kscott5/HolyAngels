﻿using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public abstract class CategoryModel : BaseModel
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }

    public class MinistryCategoryModel : CategoryModel
    {
        public MinistryCategoryModel()
        {
            Ministries = new List<MinistryModel>();
        }

        public override string MetaKeywords { get; set; }
        public override string MetaDescription { get; set; }
        public override string MetaSubject { get; set; }
        public override string PageTitle { get; set; }
        public override string SubTitle { get; set; }

        List<MinistryModel> Ministries { get; set; }
    }
}