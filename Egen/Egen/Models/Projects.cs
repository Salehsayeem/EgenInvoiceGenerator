using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Egen.Models
{
    public class Projects
    {

        public Projects()
        {
            Consultants = new HashSet<Consultants>();
            Invoices = new HashSet<Invoices>();
        }
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Consultants> Consultants { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}