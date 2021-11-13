using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalDatabase.Models
{
    public class Workspaces
    {
        public int WorkspacesID { get; set; }
        public string WorkspacesName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }

        public Department departments { get; set; }
    }
}
