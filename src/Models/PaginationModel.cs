using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HolyAngels.Models
{
    public class PaginationModel<T> : PageModel  where T : class
    {
        /// <summary>
        /// Initializes  the pagination model class
        /// </summary>
        /// <param name="column">Sort column</param>
        public PaginationModel(string column = null, List<T> data = null)
        {
            Data = data?? new List<T>();
            SortColumn = column?? string.Empty;
        }

        public string SortColumn {get; set;}

        public List<T> Data { get; private set; }
    }
}