using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class MinistryCategoryModel : CategoryModel
    {
        public MinistryCategoryModel() {} 
    }
}