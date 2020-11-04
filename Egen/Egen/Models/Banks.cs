using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Egen.Models
{
    public partial class Banks
    {
        public Banks()
        {
            Invoices = new HashSet<Invoices>();
        }
        [Key]
        public int BankId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Iban { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string RoutingType { get; set; }
        public string RoutingNumber { get; set; }
        public string BankCountry { get; set; }
        public string BankBranch { get; set; }
        public int? ConsultantId { get; set; }

        public virtual Consultants Consultant { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}