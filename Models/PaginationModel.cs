using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public class PaginationModel<T> : BaseModel where T : BaseModel
    {
        /// <summary>
        /// Initializes  the pagination model class
        /// </summary>
        /// <param name="column">Sort column</param>
        /// <param name="direction">Sort direction</param>
        public PaginationModel(string column, /*MvcContrib.Sorting.SortDirection*/ object direction)
        {
          //  Data = new List<T>() as IPagination<T>;
            /*SortOptions = new GridSortOptions
            {
                Column = column,
                Direction = direction,
            };*/
        }

        public override string MetaKeywords { get; set; }
        public override string MetaDescription { get; set; }
        public override string MetaSubject { get; set; }
        public override string PageTitle { get; set; }
        public override string SubTitle { get; set; }

        //public GridSortOptions SortOptions { get; set; }

        //public IPagination<T> Data { get; set; }
    }
}