using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using System.Collections.Specialized;

namespace HolyAngels.Models
{    
    public class UserModel : BaseModel
    {
        public UserModel()
        {
            UserStatus = UserStatus.Offline;
            Roles = new List<RoleModel>();
            Ministries = new List<MinistryModel>();

            MultiSelectRoleList = new List<RoleModel>();
            MultiSelectMinistryList = new List<MinistryModel>();
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

        [Display(Name = "Roles")]
        public List<RoleModel> MultiSelectRoleList { get; set; }

        [Display(Name = "Ministries")]
        public List<MinistryModel> MultiSelectMinistryList { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zipcode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual string Phone { get; set; }

        /// <summary>
        /// Identifier provided by Facebook 
        /// </summary>
        public int FacebookId { get; set; }

        /// <summary>
        /// Facebook access token used by Graph API
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Facebook public access url for this person
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Creates a new model
        /// </summary>
        /// <param name="data">Name value collection of information used to create new model</param>
        /// <returns>Actual model if successful else null</returns>
        /// <remarks> Keys required are as follow:
        /// id
        /// access_token
        /// username
        /// email
        /// first_name
        /// last_name
        /// birthday
        /// </remarks>
        public static UserModel Create(Dictionary<string, object> data)
        {
            try
            {
                var model = new UserModel
                {
                    FacebookId = int.Parse(data["id"].ToString()),
                    AccessToken = data["access_token"].ToString(),
                    Email = data["email"].ToString(),
                    ScreenName = data["username"].ToString(),
                    FirstName = data["first_name"].ToString(),
                    LastName = data["last_name"].ToString(),
                    //Birthday = DateTime.Parse(data["birthday"].ToString()),
                };

                return model;
            }
            catch
            {
                return null;
            }
        }
    }
}