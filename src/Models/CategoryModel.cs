using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public abstract class CategoryModel : BaseDataModel
    {
        public int Id {get; set;}
        
        public abstract int Type {get; set;}

        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class MinistryCategoryModel : CategoryModel
    {
        public MinistryCategoryModel()
        {
            this.Type = 1;
        }
    
        public override int Type {get; private set;}
    }
}