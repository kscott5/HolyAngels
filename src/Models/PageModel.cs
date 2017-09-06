using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public class PageModel 
    {
        public PageModel() 
        {
            Name = "Generic";        
            PageTitle = "Holy Angels Generic PageTile";
            SubTitle = "Holy Angels Generic Subtitle";
            MetaKeywords = "Holy Angel Church Men Coalition";
            MetaDescription = "Holy Angel Home Page for the Church";
            MetaSubject = "Holy Angel Church";
            AccessSettings = new List<string>();
        }
        
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaSubject { get; set; }
        public string PageTitle { get; set; }
        public string SubTitle { get; set; }        
        public string Name {get; set; }
        public IList<string> AccessSettings {get; set;}
    }
}