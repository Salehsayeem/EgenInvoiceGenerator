using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Egen.Models
{
    public class Consultants
    {
        public Consultants()
        {
            Banks = new HashSet<Banks>();
            Invoices = new HashSet<Invoices>();
        }
        [Key]
        public int ConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public string ConsultantDesignation { get; set; }
        public int ProjectId { get; set; }
        public bool? IsActive { get; set; }
        public Projects Project { get; set; }
        public virtual ICollection<Banks> Banks { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}