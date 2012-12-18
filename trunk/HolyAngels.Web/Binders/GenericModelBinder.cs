using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcContrib;
using MvcContrib.Binders;
using HolyAngels.Web.Areas.Manage.Helpers;
using HolyAngels.Web.Areas.Manage.Models;
using HolyAngels.Web.Helpers;

namespace HolyAngels.Web.Binders
{
    /// <summary>
    /// Generic model binder
    /// </summary>
    public class GenericModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return ModelBinderHelper.BindModels(controllerContext, bindingContext);
        }
    }
}