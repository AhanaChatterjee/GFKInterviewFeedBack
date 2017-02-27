using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GFKInterviewFeedback.Models.Utility
{
    public class AtleastOneAttributeInterview: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            {
                if (value != null)
                {
                    
                    var objInterviewDesc = value as IEnumerable;

                    foreach (var item in objInterviewDesc)
                    {
                        InterviewerDescData objInterviewerDescData = (InterviewerDescData)item;
                        if (objInterviewerDescData.Checked)
                        {
                            return ValidationResult.Success;
                        }

                    }

                }
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}