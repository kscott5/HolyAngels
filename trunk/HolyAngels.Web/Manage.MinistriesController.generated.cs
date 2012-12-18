// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace HolyAngels.Web.Areas.Manage.Controllers {
    public partial class MinistriesController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public MinistriesController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected MinistriesController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Index() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Index);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Edit() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public MinistriesController Actions { get { return MVC.Manage.Ministries; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Manage";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Ministries";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string Add = "Add";
            public readonly string Edit = "Edit";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Add = "~/Areas/Manage/Views/Ministries/Add.cshtml";
            public readonly string Edit = "~/Areas/Manage/Views/Ministries/Edit.cshtml";
            public readonly string Index = "~/Areas/Manage/Views/Ministries/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_MinistriesController: HolyAngels.Web.Areas.Manage.Controllers.MinistriesController {
        public T4MVC_MinistriesController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index(MvcContrib.UI.Grid.GridSortOptions sort, int page) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            callInfo.RouteValueDictionary.Add("sort", sort);
            callInfo.RouteValueDictionary.Add("page", page);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Add() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Add);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Add(HolyAngels.Web.Areas.Manage.Models.MinistryModel model) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Add);
            callInfo.RouteValueDictionary.Add("model", model);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(string idKey) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
            callInfo.RouteValueDictionary.Add("idKey", idKey);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(HolyAngels.Web.Areas.Manage.Models.MinistryModel model) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
            callInfo.RouteValueDictionary.Add("model", model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
