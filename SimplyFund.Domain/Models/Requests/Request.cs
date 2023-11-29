using SimplyFund.Domain.Base;
using SimplyFund.Domain.Models.Client;
using SimplyFund.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Requests
{
    public class Request : EntityBase
    {
        private Customer? customer;

        public int RequestStatusId { get; set; }
        [Required, MaxLength(100)]
        public int RequestCategoryId { get; set; }
        public bool RequireInterestInvoice { get; set; }
        public string Name { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int BadgeId { get; set; }
        [Required, Range(1, double.MaxValue)]
        public double Amount { get; set; }

        public int PeriodId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Installments { get; set; }
        [Required]
        public double AnnualInterest { get; set; }
        [Required, Range(1, 100)]
        public int Commission { get; set; }
        public int AmortizationTableId { get; set; }
        [Required]
        public bool IsNegotiable { get; set; }
        [Required]
        public int WarrantyId { get; set; }
        [Required]
        public int BankAccountId { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string? FutureStagesOfTheProject { get; set; }
        [MaxLength(200)]
        public string? Location { get; set; }
        [MaxLength(200)]
        public string? WarrantyDescription { get; set; }
        public bool? FundsReceived { get; set; }
        public string? DestinationBankAccount { get; set; }
        public bool? IsScrowAccountDefault { get; set; }


        public virtual Customers? Customer { get; set; }
        public virtual Period? Period { get; set; }
        public virtual Badge? Badge { get; set; }
        public virtual RequestStatus? RequestStatus { get; set; }

        public virtual Warranty? Warranty { get; set; }

    }
}
