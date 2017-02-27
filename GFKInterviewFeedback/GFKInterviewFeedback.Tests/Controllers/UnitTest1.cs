using Microsoft.VisualStudio.TestTools.UnitTesting;
using GFKInterviewFeedback.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using System.Data.Common;
using GFKInterviewFeedback.Models;

namespace GFKInterviewFeedback.Controllers.Tests
{
    


    [TestClass]
    public class TestsInitialize
    {
        


        [TestClass()]
        public class UnitTest1
        {
           

          /// <summary>
/// Test moethod for FeedBack GET method
/// </summary>

            [TestMethod()]
            public void FeedBackTest()
            {

                //Arrange
                SurveyController controller = new SurveyController();
                //Act
                var result = controller.FeedBack() as ViewResult;
                //Assert
                Assert.IsNotNull(result);

            }

            /// <summary>
            /// Test moethod for FeedBack Post method
            /// </summary>
            [TestMethod()]
            public void FeedBackSaveDataTest()
            {

                try {
                    //Arrange
                    SurveyController controller = new SurveyController();

                    //Act 

                    SurveyData objSurveyData = new SurveyData();
                   
                    ViewResult result;


                    var listCompanyLocation = new List<CompanyLocationData>
            {
                 new CompanyLocationData{Id = 1, Name = "Easy to access by public transport.", Checked = true},
                 new CompanyLocationData{Id = 2, Name = "Easy to access by car.", Checked = true},
                 new CompanyLocationData{Id = 3, Name = "In a pleasant area.", Checked = false},
                 new CompanyLocationData{Id = 4, Name = "None of the above.", Checked = false},

            };
                    var listInterviewerDesc = new List<InterviewerDescData>
            {
                 new InterviewerDescData{Id = 1, Name = "Enthusiastic.", Checked = true},
                 new InterviewerDescData{Id = 2, Name = "Polite.", Checked = false},
                 new InterviewerDescData{Id = 3, Name = "Organized.", Checked = false},
                 new InterviewerDescData{Id = 4, Name = "Could not tell.", Checked = false},

            };
                    objSurveyData.InterviewChallenge = SurveyData.InterviewchallengeOptions.Difficult;
                    objSurveyData.InterviewerDesc = listInterviewerDesc;
                    objSurveyData.JobOpportunity = SurveyData.JobOpportunityOptions.Other;
                    objSurveyData.OfficeImpression = SurveyData.OfficeImpressionOptions.Sloppy;
                    objSurveyData.CompanyLocation = listCompanyLocation;

                    DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
                    using (var context = new SurveyDBContext(connection))
                    {
                        result = controller.FeedBack(objSurveyData) as ViewResult;
                    }

                    Assert.AreEqual("Thanks", result.ViewName);

                   
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.ToString());
                }



             
                

            }
        }



        }
}