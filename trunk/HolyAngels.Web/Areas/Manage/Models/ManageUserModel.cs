using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolyAngels.Web.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HolyAngels.Web.Areas.Manage.Models
{
    [Obsolete("Use the UserModel. Remove from source code")]
    public class ManageUserModel : UserModel
    {
        public ManageUserModel()
            : base()
        {
            MultiSelectRoleList = new MultiSelectList(new List<RoleModel>());
            MultiSelectMinistryList = new MultiSelectList(new List<MinistryModel>());
        }

        [Display(Name = "Roles")]
        public MultiSelectList MultiSelectRoleList { get; set; }

        [Display(Name = "Ministries")]
        public MultiSelectList MultiSelectMinistryList { get; set; }
    }
}