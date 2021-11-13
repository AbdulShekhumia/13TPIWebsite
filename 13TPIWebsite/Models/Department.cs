using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalDatabase.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Display(Name="Department")]
        public string DepartmentName { get; set; }

        public Staff staff { get; set; }
        public ICollection<Workspaces> workspaces { get; set; }
    }
}
