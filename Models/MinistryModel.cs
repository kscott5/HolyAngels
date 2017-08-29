using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public class MinistryModel : BaseModel
    {
        public MinistryModel() : base()
        {
            PageTitle = "Holy Angels Ministries";
            SubTitle = "Ministries";
            Users = new List<UserModel>();
            MultiSelectUserList = new List<UserModel>();
        }

        public override string MetaKeywords { get; set; }
        public override string MetaDescription { get; set; }
        public override string MetaSubject { get; set; }
        public override string PageTitle { get; set; }
        public override string SubTitle { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Users")]
        public List<UserModel> Users { get; set; }

        [Display(Name = "Users")]
        public List<UserModel> MultiSelectUserList { get; set; }
    }
}