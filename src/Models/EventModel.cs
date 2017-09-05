using System;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using HolyAngels.Attributes;

namespace HolyAngels.Models
{
    public class EventModel : BaseDataModel
    {
        public EventModel() : base()
        {
            Ministries = new List<MinistryModel>();
            MultiSelectMinistryList = new List<MinistryModel>();
        }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Title { get; set; }

        [Display(Name = "Location")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Location { get; set; }

        [Display(Name = "Speakers")]
        public string Speakers { get; set; }

        /// <summary>
        /// Gets or sets the start date
        /// </summary>
        /// <remarks>Used for adding/editing events</remarks>
        [Display(Name = "Start Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "mm/dd/yyyy")]
        public string StartDate { get; set; }
        
        /// <summary>
        /// Gets or sets the start time
        /// </summary>
        /// <remarks>Used for adding/editing events</remarks>
        [Display(Name = "Start Time")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = false, DataFormatString = "hh:mm AMPM")]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end date
        /// </summary>
        /// <remarks>Used for adding/editing events</remarks>
        [Display(Name = "End Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = false, DataFormatString = "mm/dd/yyyy")]
        [CompareDate("StartDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets the end time
        /// </summary>
        /// <remarks>Used for adding/editing events</remarks>
        [Display(Name = "End Time")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "hh:mm AMPM")]
        [CompareTime("StartTime")]        
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or sets the complete start date/time
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the complete end date/time
        /// </summary>
        public DateTime End { get; set; }

        [Display(Name = "Ministries")]
        public List<MinistryModel> Ministries { get; set; }

        [Display(Name = "Ministries")]
        public List<MinistryModel> MultiSelectMinistryList { get; set; }

        [Display(Name = "Approved")]
        public bool Approved { get; set; }

/*
        /// <summary>
        /// Gets the available times for events
        /// </summary>
        /// <remarks>Determine if we should put in database</remarks>
        public SelectList Times
        {
            get
            {                
                List<SelectListItem> items = new List<SelectListItem>();
                
                // AM times
                AddTimesToList(items, 12, "AM");
                for (int i = 1; i < 12; i++)
                {
                    AddTimesToList(items, i, "AM");
                }

                // PM times
                for (int i = 1; i < 12; i++)
                {
                    AddTimesToList(items, i, "PM");
                }
                AddTimesToList(items, 12, "PM");

                return new SelectList(items, "Value", "Text");
            }
        }

        private static void AddTimesToList(List<SelectListItem> items, int i, string ampm)
        {
            string t1 = string.Format("{0:00}:00 {1}", i, ampm);
            items.Add(new SelectListItem { Text = t1, Value = t1 });

            string t2 = string.Format("{0:00}:15 {1}", i, ampm);
            items.Add(new SelectListItem { Text = t2, Value = t2 });

            string t3 = string.Format("{0:00}:30 {1}", i, ampm);
            items.Add(new SelectListItem { Text = t3, Value = t3 });

            string t4 = string.Format("{0:00}:45 {1}", i, ampm);
            items.Add(new SelectListItem { Text = t4, Value = t4 });
        }
*/
    }
}