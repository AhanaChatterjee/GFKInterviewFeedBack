using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using GFKInterviewFeedback.Models.Utility;

namespace GFKInterviewFeedback.Models
{
    /// <summary>
    /// Extension method to ParseEnum
    /// </summary>
    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
    public class SurveyData
    {
        /// <summary>
        /// Enum declaration for dropdownlists
        /// </summary>
        public enum JobOpportunityOptions
        {
            StackOverflow = 1,
            Indeed = 2,
            Other = 3
        }


        public enum OfficeImpressionOptions
        {
            Tidy = 1,
            Sloppy = 2,
            [Display(Name = "Did not notice")]
            Did_not_notice = 3

        }
        public enum InterviewchallengeOptions
        {
            [Display(Name = "Very difficult")]
            Very_difficult = 1,
            Difficult = 2,
            Moderate = 3,
            Easy = 4
        }


        /// <summary>
        /// Property declaration
        /// </summary>

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SurveyId { get; set; }


        [Column("JobOpportunity")]
        public string JobOpportunityString
        {
            get { return JobOpportunity.ToString(); }
            private set { JobOpportunity = value.ParseEnum<JobOpportunityOptions>(); }
        }

        [NotMapped]
        [Required(ErrorMessage = "Please select one of the options")]
        [Display(Name = "1.) How did you find out about this job opportunity?")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select a correct value")]
        public JobOpportunityOptions JobOpportunity { get; set; }

        [Required(ErrorMessage = "Please select at least one option ")]
        [Display(Name = "2.) How do you find the company’s location?")]

       [AtleastOneAttributeCompany(ErrorMessage ="Please select atleast one option")]
        public List<CompanyLocationData> CompanyLocation { get ; set; }

        [Column("OfficeImpression")]
        public string OfficeImpressionString
        {
            get { return OfficeImpression.ToString(); }
            private set { OfficeImpression = value.ParseEnum<OfficeImpressionOptions>(); }
        }
        [NotMapped]
        [Required(ErrorMessage = "Please select one of the options")]
        [Display(Name = "3.)What was your impression of the office where you had the interview?")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select a correct value")]
        public OfficeImpressionOptions OfficeImpression { get; set; }

        [Column("InterviewChallenge")]
        public string InterviewchallengeString
        {
            get { return InterviewChallenge.ToString(); }
            private set { InterviewChallenge = value.ParseEnum<InterviewchallengeOptions>(); }
        }
        [NotMapped]
        [Required(ErrorMessage = "Please select one of the options")]
        [Display(Name = "4.) How technically challenging was the interview?")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select a correct value")]
        public InterviewchallengeOptions InterviewChallenge { get; set; }

        [Required(ErrorMessage = "Please select at least one option ")]
        [Display(Name = "5.) How can you describe the manager that interviewed you?")]
        [AtleastOneAttributeInterview(ErrorMessage = "Please select atleast one option")]
        public List<InterviewerDescData> InterviewerDesc { get; set; }

       

    }
}