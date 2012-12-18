using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;

using HolyAngels.Web.Areas.Manage.Models;

namespace HolyAngels.Web.Models
{
    public class HomeModel : BaseModel
    {
        public HomeModel() : this("Home")
        {
        }

        public HomeModel(string pageTitle)
        {
            SubTitle = "Holy Angel Home";
            PageTitle = pageTitle;
            MetaKeywords = "Holy Angel Church Men Coalition";
            MetaDescription = "Holy Angel Home Page for the Church";
            MetaSubject = "Holy Angel Church";
        }
        
        public override string MetaKeywords { get; set; }
        public override string MetaDescription { get; set; }
        public override string MetaSubject { get; set; }
        public override string PageTitle { get; set; }
        public override string SubTitle { get; set; }

        public QuoteModel Quote { get; set; }
    }
}