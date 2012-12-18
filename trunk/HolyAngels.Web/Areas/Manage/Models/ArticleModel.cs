﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HolyAngels.Web.Attributes;

namespace HolyAngels.Web.Areas.Manage.Models
{
    public class ArticleModel : BaseModel
    {
        public ArticleModel() : base()
        {
            SubTitle = "Holy Angels Article(s)";
            PageTitle = "Articles";
            Ministries = new List<MinistryModel>();
            MultiSelectMinistryList = new MultiSelectList(new List<MinistryModel>());
        }

        public override string MetaKeywords { get; set; }
        public override string MetaDescription { get; set; }
        public override string MetaSubject { get; set; }
        public override string PageTitle { get; set; }
        public override string SubTitle { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [Display(Name = "Title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Title { get; set; }

        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Approved")]
        public bool Approved { get; set; }

        [Display(Name = "Keywords")]
        public string Keywords { get; set; }

        [Display(Name = "Start Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [DataType(DataType.Date)]
        public string StartDate { get; set; }
        
        [Display(Name = "End Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [CompareDate("StartDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets the complete start date/time
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the complete end date/time
        /// </summary>
        public DateTime End { get; set; }

        [Display(Name = "Ministries")]
        public List<MinistryModel> Ministries { get; set; }

        [Display(Name = "Ministries")]
        public MultiSelectList MultiSelectMinistryList { get; set; }
    }
}