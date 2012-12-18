using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HolyAngels.Web.Domains;

namespace HolyAngels.Web.Areas.Manage.Models
{
    [Obsolete("Remove from source code")]
    public class RegisterModel : UserModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(Constants.Regular_Expression_For_Password, ErrorMessage = Constants.Error_Message_For_Regular_Expression_Password)]
        public override string Password { get; set; }

        [Compare("Password", ErrorMessage = "*")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}