using System.Web.Mvc;

using MvcContrib;
using HolyAngels.Web.Areas.Manage.Helpers;
using HolyAngels.Web.Areas.Manage.Models;

using HolyAngels.Web.Filters;
using MvcContrib.UI.Grid;

namespace HolyAngels.Web.Areas.Manage.Controllers
{
    [HandleError(View = "Error")]
    [ValidateInput(false)]
    public partial class UsersController : Controller
    {
        [HttpGet]
        [FormsAuthorize(Roles = "Administrator")]
        public virtual ActionResult Index(GridSortOptions sort, int page = 1)
        {
            var model = ManageUserModelHelper.GetUserModelForUsers(sort, page);
            return View(model);
        }

        [FormsAuthorize(Roles = "Administrator")]
        public virtual ActionResult Add()
        {
            var model = ManageUserModelHelper.GetUserModelForAdd();
            return View(model);
        }

        [HttpPost]
        [FormsAuthorize(Roles = "Administrator")]
        public virtual ActionResult Add(UserModel model)
        {
            if (ModelState.IsValid)
            {
                Status status;
                if (model.Add(out status))
                    ModelState.AddModelError("Error", "Successfully created new system user!");
                else
                    ModelState.AddModelError("Error", status.Message());
            }
            else
            {
                ModelState.AddModelError("Error", "Please update the required fields!");
            }

            model.UpdateUserModelForAdd();

            return View(model);
        }

        [HttpGet]
        [FormsAuthorize(Roles = "Basic, Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Edit(string idKey)
        {
            var model = ManageUserModelHelper.GetUserModelForEdit(idKey);
            if (model == null)
                return this.RedirectToAction<UsersController>(a => a.Index());
            return View(model);
        }

        [HttpPost]
        [FormsAuthorize(Roles = "Basic, Administrator, Ministry, Content Publisher, Content Approver")]
        public virtual ActionResult Edit(UserModel model)
        {            
            if (ModelState.IsValid)
            {
                Status status;
                if (model.Update(out status))
                    ModelState.AddModelError("Error", "User information updated successfully!");
                else
                    ModelState.AddModelError("Error", status.Message());
            }
            else
            {
                ModelState.AddModelError("Error", "Please update the required fields!");
            }

            model = ManageUserModelHelper.GetUserModelForEdit(model.IdKey.ToString());
            return View(model);
        }
    }
}
