using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalDatabase.Models
{
    public class Job
    {       
       
        public int JobID { get; set; }

        [Required(ErrorMessage = "Job Title is Required")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Salary Range is Required")]
        [Display(Name ="Salary Range (Per Hour)")]
        public string SalaryRange { get; set; }
        public ICollection<Staff> Staff { get; set; }
    }
}
