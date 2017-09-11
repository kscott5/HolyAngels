using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public class QuoteModel 
    {
        public QuoteModel() : base()
        {
            Description = "";
            Source = "";
        }

        
        public string Id { get; set; }      

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "*")]
        public string Source { get; set; }

        public bool Approved { get; set; }

    }
}