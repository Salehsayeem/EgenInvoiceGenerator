using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Egen.Models
{
    public class Companies
    {
        public Companies()
        {
            Invoices = new HashSet<Invoices>();
        }
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Attention { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<Invoices> Invoices { get; set; }
    }
}