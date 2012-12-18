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
namespace HolyAngels.Web.Controllers {
    public partial class MinistryController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public MinistryController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected MinistryController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult DisplayMinistry() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.DisplayMinistry);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public MinistryController Actions { get { return MVC.Ministry; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Ministry";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string DisplayMinistry = "DisplayMinistry";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string DisplayMinistry = "~/Views/Ministry/DisplayMinistry.cshtml";
            public readonly string Index = "~/Views/Ministry/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_MinistryController: HolyAngels.Web.Controllers.MinistryController {
        public T4MVC_MinistryController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult DisplayMinistry(string ministryName) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.DisplayMinistry);
            callInfo.RouteValueDictionary.Add("ministryName", ministryName);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
