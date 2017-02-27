using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GFKInterviewFeedback.Models;

namespace GFKInterviewFeedback.Controllers
{
    public class SurveyController : Controller
    {
        /// <summary>
        /// Get method FeedBack , bind the checkboxlist data to checkboxes
        /// </summary>
        /// <returns>ActionResult</returns>

        public ActionResult FeedBack()
        {
            try
            {
                var listCompanyLocation = new List<CompanyLocationData>
            {
                 new CompanyLocationData{Id = 1, Name = "Easy to access by public transport.", Checked = false},
                 new CompanyLocationData{Id = 2, Name = "Easy to access by car.", Checked = false},
                 new CompanyLocationData{Id = 3, Name = "In a pleasant area.", Checked = false},
                 new CompanyLocationData{Id = 4, Name = "None of the above.", Checked = false},

            };
                var listInterviewerDesc = new List<InterviewerDescData>
            {
                 new InterviewerDescData{Id = 1, Name = "Enthusiastic.", Checked = false},
                 new InterviewerDescData{Id = 2, Name = "Polite.", Checked = false},
                 new InterviewerDescData{Id = 3, Name = "Organized.", Checked = false},
                 new InterviewerDescData{Id = 4, Name = "Could not tell.", Checked = false},

            };
                SurveyData objSurveyData = new SurveyData();
                objSurveyData.CompanyLocation = listCompanyLocation;
                objSurveyData.InterviewerDesc = listInterviewerDesc;
                return View(objSurveyData);
            }
            catch(Exception ex)
            {
                string message = string.Format("<b>Message:</b> {0}<br /><br />", ex.Message);
                message += string.Format("<b>StackTrace:</b> {0}<br /><br />", ex.StackTrace.Replace(Environment.NewLine, string.Empty));
                message += string.Format("<b>Source:</b> {0}<br /><br />", ex.Source.Replace(Environment.NewLine, string.Empty));
                message += string.Format("<b>TargetSite:</b> {0}", ex.TargetSite.ToString().Replace(Environment.NewLine, string.Empty));
                ModelState.AddModelError(string.Empty, message);
                return View(message.ToString());
            }
        }

        /// <summary>
        /// Post method called after submit the feedback form
        /// </summary>
        /// <param name="objSurveyData"> contents all the submitted feedback data</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult FeedBack(SurveyData objSurveyData)
        {
            try
            {
                if (ModelState != null)
                {
                    
                if (ModelState.IsValid)
                {
                    using (SurveyDBContext db = new SurveyDBContext())
                    {
                         
                        db.surveyData.Add(objSurveyData);
                        db.SaveChanges();  //saving the data in data base
                    }

                    ModelState.Clear();

                    return View("Thanks");
                }
                else
                {
                    return View("Error");
                }
            }
                else
                {
                    return View("Error");
                }
            }
            catch(Exception ex)
            {
                string message = string.Format("<b>Message:</b> {0}<br /><br />", ex.Message);
                message += string.Format("<b>StackTrace:</b> {0}<br /><br />", ex.StackTrace.Replace(Environment.NewLine, string.Empty));
                message += string.Format("<b>Source:</b> {0}<br /><br />", ex.Source.Replace(Environment.NewLine, string.Empty));
                message += string.Format("<b>TargetSite:</b> {0}", ex.TargetSite.ToString().Replace(Environment.NewLine, string.Empty));
                //ModelState.AddModelError(string.Empty, message);
                return View(message.ToString());
            }
            
        }

        


    }
}