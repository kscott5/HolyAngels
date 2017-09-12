using System;
using System.Collections.Generic;
using System.Linq;

namespace HolyAngels
{
    public class Constants
    {
        /// <summary>
        /// Regular Expression for password (Stack Overflow - Thx)
        /// </summary>
        public static const string Regular_Expression_For_Password = @"((?=.*[^a-zA-Z])(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,})";
        public static const string Error_Message_For_Regular_Expression_Password = @"Must be at least 6 characters long and include 1 lower, upper and number";        
    }
}