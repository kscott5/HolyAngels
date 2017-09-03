using System;

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

        List<MinistryModel> Ministries { get; set; }
    }
}