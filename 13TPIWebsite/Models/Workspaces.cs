using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalDatabase.Models
{
    public class Workspaces
    {
        public int WorkspacesID { get; set; }
        [Required(ErrorMessage = "Workspace Name is Required")]
        [Display(Name = "Workspace Name")]
        public string WorkspacesName { get; set; }
        public int Phone { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Street field is Required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "The Suburb field is Required")]
        public string Suburb { get; set; }
        [Required(ErrorMessage = "The City field is Required")]
        public string City { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        public Department departments { get; set; }
    }
}
