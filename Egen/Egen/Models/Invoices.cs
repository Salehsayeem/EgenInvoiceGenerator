using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Egen.Models
{
   // public partial class Invoices
    public  class Invoices
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime? Date { get; set; }
        public string InvoiceNo { get; set; }
        public int? BankId { get; set; }
        public int? ProjectId { get; set; }
        public int? ConsultantId { get; set; }
        public int? CompanyId { get; set; }
        public bool IsUsd { get; set; }
        public decimal? Total { get; set; }
        public decimal? Advance { get; set; }
        public decimal? Due { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Remuneration { get; set; }
        public string RemunerationDetails { get; set; }
        public int? RemunerationWorkingDays { get; set; }
        public decimal? RemunerationDailyRate { get; set; }
        public decimal? RemunerationTotal { get; set; }
        public string PerDiem { get; set; }
        public string PerDiemDetails { get; set; }
        public int? PerDiemWorkingDays { get; set; }
        public decimal? PerDiemDailyRate { get; set; }
        public decimal? PerDiemTotal { get; set; }
        public string AirFare { get; set; }
        public string AirFareDetails { get; set; }
        public decimal? AirFareTotal { get; set; }
        public string Accommodation { get; set; }
        public string AccommodationDetails { get; set; }
        public decimal? AccommodationTotal { get; set; }
        public string VisaFees { get; set; }
        public string VisaFeesDetails { get; set; }
        public decimal? VisaFeesTotal { get; set; }
        public string TaxiFare { get; set; }
        public string TaxiFareDetails { get; set; }
        public decimal? TaxiFareTotal { get; set; }
        public string Other { get; set; }
        public string OtherDetails { get; set; }
        public int? OtherWorkingDays { get; set; }
        public decimal? OtherDailyRate { get; set; }
        public decimal? OtherTotal { get; set; }
        public bool? IsActive { get; set; }
        public  Banks Bank { get; set; }
        public  Companies Company { get; set; }
        public  Consultants Consultant { get; set; }
        public  Projects Project { get; set; }
    }
}