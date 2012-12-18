using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolyAngels.Web.Areas.Manage.Models;
using HolyAngels.Web.Areas.Manage.Helpers;

namespace HolyAngels.Web.Helpers
{
    public static class ModelBinderHelper
    {
        /// <summary>
        /// Binder for list of system models
        /// </summary>
        /// <remarks>
        /// Currently rebinds the selected values to the following system models:
        /// RoleModel
        /// MinistryModel
        /// </remarks>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public static object BindModels(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext");

            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (result == null)
                return null;

            switch (bindingContext.ModelName)
            {
                case "Roles":
                    return BindRoleModels(result);
                case "Ministries":
                    return BindMinistryModels(result);
                case "StartTime":
                case "EndTime":
                    return BindStartEndTime(result);
                default:
                    throw new NotSupportedException(string.Format(
                        "ModelBinderHelper.BindModels does not support binding data to Model.{0}", 
                        bindingContext.ModelName));
            }
        }

        private static string BindStartEndTime(ValueProviderResult result)
        {
            var rawValue = result.RawValue as string;
            if (string.IsNullOrEmpty(rawValue))
            {
                return null;
            }

            // Is time valid?
            Convert.ToDateTime(string.Format("1/1/2012 {0}", rawValue));

            return rawValue.Trim();
        }

        /// <summary>
        /// Creates the list of models selected by the system users
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static List<RoleModel> BindRoleModels(ValueProviderResult result)
        {
            var rawValue = result.RawValue as string[];
            if (rawValue == null || rawValue.Length == 0)
            {
                return null;
            }

            List<RoleModel> models = ManageRoleModelHelper.GetRoleModels(rawValue);
            return models;
        }

        /// <summary>
        /// Creates the list of ministries selected by the system users
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static List<MinistryModel> BindMinistryModels(ValueProviderResult result)
        {
            var rawValue = result.RawValue as string[];
            if (rawValue == null || rawValue.Length == 0)
            {
                return null;
            }

            List<MinistryModel> models = ManageMinistryModelHelper.GetMinistryModels(rawValue);
            return models;
        }

    }
}