using System;
using System.Collections.Generic;
using System.Linq;

namespace HolyAngels.Domains
{
    public class Constants
    {
        /// <summary>
        /// Regular Expression for password (Stack Overflow - Thx)
        /// </summary>
        public const string Regular_Expression_For_Password = @"((?=.*[^a-zA-Z])(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,})";
        public const string Error_Message_For_Regular_Expression_Password = @"Must be at least 6 characters long and include 1 lower, upper and number";
        /// <summary>
        /// Constants for users
        /// </summary>
        public const string Sort_Column_FirstName = "FirstName";
        public const string Sort_Column_LastName = "LastName";
        public const string Sort_Column_ScreenName = "ScreenName";
        public const string Sort_Column_Email = "Email";

        /// <summary>
        /// Constants for quotes
        /// </summary>
        public const string Sort_Column_Source = "Source";
        public const string Sort_Column_Description = "Description";

        public const string Sort_Column_Name = "Name";

        /// <summary>
        /// Constants for events and articles
        /// </summary>
        public const string Sort_Column_Title = "Title";
        public const string Sort_Column_Location = "Location";
        public const string Sort_Column_Start = "Start";

        /// <summary>
        /// Constants for articles
        /// </summary>
        public const string Sort_Column_Summary = "Summary";
        public const string Sort_Column_Approved = "Approved";
    }
}