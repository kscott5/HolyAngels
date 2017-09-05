using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public class RoleModel 
    {        
        public int Id { get; set; }

        [Display(Name="Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Name { get; set; }

        [Display(Name="Description")]
        public string Description { get; set; }
    }
}