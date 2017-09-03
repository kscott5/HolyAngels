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

        //public GridSortOptions SortOptions { get; set; }

        //public IPagination<T> Data { get; set; }
    }
}