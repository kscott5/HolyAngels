using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{    
    public abstract class BaseUserModel : BaseModel
    {
        public BaseUserModel()
        {
            UserStatus = UserStatus.Offline;
            Roles = new List<RoleModel>();
            Ministries = new List<MinistryModel>();            
        }

        public UserStatus UserStatus { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? LastAcecssed { get; set; }

        public override string MetaKeywords { get; set; }
        public override string MetaDescription { get; set; }
        public override string MetaSubject { get; set; }
        public override string PageTitle { get; set; }
        public override string SubTitle { get; set; }

        [Display(Name = "Ministry")]
        public List<MinistryModel> Ministries { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zipcode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual string Phone { get; set; }
    }
}