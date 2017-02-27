using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GFKInterviewFeedback.Models.Utility
{
    
        public class AtleastOneAttributeCompany : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                {
                    if (value != null)
                    {
                        
                        var objCompanyLoc = value as IEnumerable;

                        foreach (var item in objCompanyLoc)
                        {
                            CompanyLocationData objCompanyLocdata = (CompanyLocationData)item;
                            if (objCompanyLocdata.Checked)
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
