using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Common;

namespace GFKInterviewFeedback.Models
{
   
    public class SurveyDBContext : DbContext
    {

        public SurveyDBContext()
        : base("name=SurveyDBContext")
    {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public SurveyDBContext(string connectionString)
        : base(connectionString)
    {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public SurveyDBContext(DbConnection connection)
        : base(connection, true)
    {
            this.Configuration.LazyLoadingEnabled = false;
        }
        /// <summary>
        /// Survey data property
        /// </summary>
        public DbSet<SurveyData> surveyData { get; set; }

        
    }
}