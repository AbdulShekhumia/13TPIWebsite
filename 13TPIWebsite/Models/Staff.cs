using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalDatabase.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Range(18, 100)]
        public int Age { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        [Required(ErrorMessage = "The Position field is Required")]
        [Display(Name = "Position")]
        public string StaffRole { get; set; }

        public ICollection<Department> Departments { get; set; }

        public Job jobs { get; set; }
    }
}
