using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using MongoDB.Driver;
using MongoDB.Driver.Linq;

using HolyAngels.Models;
using HolyAngels.Services;

namespace HolyAngels.Services
{
    public class MemberService : AdminDataService
    {
        public MemberService(IConfiguration configuration, ILoggerFactory factory) :
            base(configuration, factory, "AdminPanel.Member") {                
        }


    }
}