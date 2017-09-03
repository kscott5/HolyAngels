using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public class MinistryModel : BaseModel
    {
        public MinistryModel() : base()
        {
            Users = new List<UserModel>();
            MultiSelectUserList = new List<UserModel>();
        }

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