using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

using MvcContrib.Pagination;
using MvcContrib.Sorting;
using MvcContrib.UI.Grid;

namespace HolyAngels.Web.Areas.Manage.Models
{
    public class PaginationModel<T> : BaseModel where T : BaseModel
    {
        /// <summary>
        /// Initializes  the pagination model class
        /// </summary>
        /// <param name="column">Sort column</param>
        /// <param name="direction">Sort direction</param>
        public PaginationModel(string column, MvcContrib.Sorting.SortDirection direction)
        {
            Data = new List<T>() as IPagination<T>;
            SortOptions = new GridSortOptions
            {
                Column = column,
                Direction = direction,
            };
        }

        public override string MetaKeywords { get; set; }
        public override string MetaDescription { get; set; }
        public override string MetaSubject { get; set; }
        public override string PageTitle { get; set; }
        public override string SubTitle { get; set; }

        public GridSortOptions SortOptions { get; set; }

        public IPagination<T> Data { get; set; }
    }
}