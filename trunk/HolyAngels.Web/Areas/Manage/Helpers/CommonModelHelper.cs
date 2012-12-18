using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcContrib.Sorting;

using HolyAngels.Web.Areas.Manage.Models;

namespace HolyAngels.Web.Areas.Manage.Helpers
{
    public static class CommonModelHelper
    {
        /// <summary>
        /// Gets a paginated model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static PaginationModel<T> GetPaginatedModel<T>(string column, SortDirection direction) where T : BaseModel
        {
            return new PaginationModel<T>(column, direction);
        }            
    }
}