using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GFKInterviewFeedback.Models
{
    
    public class CompanyLocationData
    {
        
            public int Id
            {
                get;
                set;
            }
        
        public string Name
            {
                get;
                set;
            }


            public bool Checked
            {
                get;
                set;
            }
        
    }
    //public class  CompanyLocationDataList
    //{
    //    [Required(ErrorMessage = "Please select at least one option ")]
    //    [Display(Name = "2.) How do you find the company’s location?")]
    //    public List<CompanyLocationData> companyLocationData { get; set; }
    //}
}