namespace GFKInterviewFeedback
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;
    public partial class SurveyDBContext : DbContext
    {
        public DbSet<SurveyData> surveyData { get; set; }
        public SurveyDBContext()
            : base("name=SurveyDBContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
