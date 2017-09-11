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

        public static PageModel<T> GetPageModel<T>(PageModel model, T data) {
            return new PageModel<T>(model, data);
        }
        public string Id {get; set;}
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaSubject { get; set; }
        public string PageTitle { get; set; }
        public string SubTitle { get; set; }        
        public string Name {get; set; }
        public string SiteName {get;set;}
        public string SiteSlogan {get; set;}
        public bool QuoteEnabled {get; set;}
        public IList<string> AccessSettings {get; set;}
        public QuoteModel Quote {get; set;}
    }

    public class PageModel<T> : PageModel {
        public PageModel(PageModel model, T data) : base() {
            this.Data = data;
            this.Id = model.Id;
            this.MetaKeywords = model.MetaKeywords;
            this.MetaDescription = model.MetaDescription;
            this.MetaSubject = model.MetaSubject;
            this.PageTitle = model.PageTitle;
            this.SubTitle = model.SubTitle;
            this.Name = model.Name;
            this.SiteName = model.SiteName;
            this.SiteSlogan = model.SiteSlogan;
            this.QuoteEnabled = model.QuoteEnabled;
            this.AccessSettings = model.AccessSettings;
            this.Quote = model.Quote;
        }

        public T Data {get;}
    }
}