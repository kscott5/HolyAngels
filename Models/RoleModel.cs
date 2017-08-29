using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public class RoleModel : BaseModel
    {
        public override string MetaKeywords { get; set; }
        public override string MetaDescription { get; set; }
        public override string MetaSubject { get; set; }
        public override string PageTitle { get; set; }
        public override string SubTitle { get; set; }

        [Display(Name="Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Name { get; set; }

        [Display(Name="Description")]
        public string Description { get; set; }
    }
}