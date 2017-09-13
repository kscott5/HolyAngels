using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using MongoDB.Driver;
using MongoDB.Driver.Linq;

using HolyAngels.Models;

namespace HolyAngels.Services {
    public class QuoteService : DataService {
        public QuoteService(IConfiguration configuration, ILoggerFactory factory) : 
            base(configuration, factory, "Quote") {
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<QuoteModel> GetQuotes() {
            var query = this.ClientDB
                .GetCollection<QuoteModel>("quotemodel").AsQueryable();
            
            var results = (from q in query
                select q).ToList();

            return results;
        }

        public QuoteModel GetQuoteOfDay() {
            return this.GetQuotes()[0];
        }

        public void AddQuote(QuoteModel document) {            
            var query = this.ClientDB
                .GetCollection<QuoteModel>("quotemodel");
            
            query.InsertOne(document);
        }
    }
}
