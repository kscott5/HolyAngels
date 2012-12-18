using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HolyAngels.Web.Areas.Manage.Models
{
    public class RoleModel : BaseModel
    {
        public override string MetaKeywords { get; set; }
        public override string MetaDescription { get; set; }
        public override string MetaSubject { get; set; }
        public override string PageTitle { get; set; }
        public override string SubTitle { get; set; }

        [DisplayName("Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
    }
}