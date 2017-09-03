using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public class QuoteModel : BaseModel
    {
        public QuoteModel() : base()
        {
            Description = "";
            Source = "";
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "*")]
        [Display(Name = "Source")]
        public string Source { get; set; }

        [Display(Name = "Approved")]
        public bool Approved { get; set; }

    }
}