using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public class PageModel 
    {
        public PageModel() 
        {
            AccessSettings = new List<string>();
        }
        
        public string Id {get; set;}
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaSubject { get; set; }
        public string PageTitle { get; set; }
        public string SubTitle { get; set; }        
        public string Name {get; set; }
        public IList<string> AccessSettings {get; set;}
    }
}