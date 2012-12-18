using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolyAngels.Web.Domains
{
    public class CommonDataHub : BaseDomain
    {
        public virtual string CountryName { get; set; }
        public virtual string SubdivisionStateName { get; set; }
        public virtual string PrimaryLevelName { get; set; }
        public virtual int SubdivisionCDHID { get; set; }
        public virtual int CountryCDHID { get; set; }
        public virtual string CountryISOChar2Code { get; set; }
        public virtual string CountryISOChar3Code { get; set; }
    }
}