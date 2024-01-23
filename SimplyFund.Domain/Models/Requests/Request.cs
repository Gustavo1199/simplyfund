using SimplyFund.Domain.Base;
using SimplyFund.Domain.Dto.File;
using SimplyFund.Domain.Models.Client;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Warrantys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customers = SimplyFund.Domain.Models.Client.Customer;

namespace SimplyFund.Domain.Models.Requests
{
    public class Request : EntityBase
    {
        [Required]
        public int RequestStatusId { get; set; }
        [Required]
        public int RequestCategoryId { get; set; }
        public bool RequireInterestInvoice { get; set; }
        public string? Name { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int BadgeId { get; set; }
        [Required, Range(1, double.MaxValue)]
        public double Amount { get; set; }
        [Required]
        public int PeriodId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Installments { get; set; }
        [Required]
        public double AnnualInterest { get; set; }
        [Required, Range(1, 100)]
        public int Commission { get; set; }
        [Required]
        public int AmortizationTableId { get; set; }
        [Required]
        public bool IsNegotiable { get; set; }
        [Required]
        public int WarrantyId { get; set; }
        [Required]
        public int BankAccountId { get; set; }
        [Required, MaxLength(255)]
        public string? Description { get; set; }
        [MaxLength(255)]
        public string? FutureStagesOfTheProject { get; set; }
        [MaxLength(200)]
        public string? Location { get; set; }
        [MaxLength(200)]
        public string? WarrantyDescription { get; set; }
        public bool? FundsReceived { get; set; }
        public string? DestinationBankAccount { get; set; }
        public bool? IsScrowAccountDefault { get; set; }
        public bool? escrow { get; set; }
        public string? trustName { get; set; }


        public virtual Customers? Customer { get; set; }
        public virtual AmortizationTable? AmortizationTables { get; set; }
        public virtual Period? Period { get; set; }
        public virtual Badge? Badge { get; set; }
        public virtual RequestStatus? RequestStatus { get; set; }

        public virtual Warranty? Warranty { get; set; }
        public virtual RequestCategory? RequestCategory { get; set; }


        [NotMapped]
        public List<FileDto>? Files { get; set; }


        [NotMapped]
        public List<RequestExpenseRelation>? RequestExpenses { get; set; }

    }


    //public class Request : EntityBase
    //{

    //    public int RequestStatusId { get; set; }
    //    [Required, MaxLength(100)]
    //    public int RequestCategoryId { get; set; }
    //    public bool RequireInterestInvoice { get; set; }
    //    public string? Name { get; set; }
    //    [Required]
    //    public int CustomerId { get; set; }
    //    [Required]
    //    public int BadgeId { get; set; }
    //    [Required, Range(1, double.MaxValue)]
    //    public double Amount { get; set; }

    //    public int PeriodId { get; set; }
    //    [Required, Range(1, int.MaxValue)]
    //    public int Installments { get; set; }
    //    [Required]
    //    public double AnnualInterest { get; set; }
    //    [Required, Range(1, 100)]
    //    public int Commission { get; set; }
    //    public int AmortizationTableId { get; set; }
    //    [Required]
    //    public bool IsNegotiable { get; set; }
    //    [Required]
    //    public int WarrantyId { get; set; }
    //    [Required]
    //    public int BankAccountId { get; set; }
    //    [Required, MaxLength(255)]
    //    public required string Description { get; set; }
    //    [MaxLength(255)]
    //    public string? FutureStagesOfTheProject { get; set; }
    //    [MaxLength(200)]
    //    public string? Location { get; set; }
    //    [MaxLength(200)]
    //    public string? WarrantyDescription { get; set; }
    //    public bool? FundsReceived { get; set; }
    //    public string? DestinationBankAccount { get; set; }
    //    public bool? IsScrowAccountDefault { get; set; }


    //    public virtual Client.Customer? Customer { get; set; }
    //    public virtual Period? Period { get; set; }
    //    public virtual Badge? Badge { get; set; }
    //    public virtual RequestStatus? RequestStatus { get; set; }

    //    public virtual Warranty? Warranty { get; set; }

    //}


    //public class Request : EntityBase
    //{
    //    public int RequestStatusId { get; set; }

    //    //[Required, MaxLength(100)]
    //    public string? RequestCategoryId { get; set; } // Corregí el tipo de dato

    //    public bool RequireInterestInvoice { get; set; }
    //    public string? Name { get; set; }

    //    //[Required]
    //    public int CustomerId { get; set; }

    //    // [Required]
    //    public int BadgeId { get; set; }

    //    // [Required, Range(0, double.MaxValue)] // Modifiqué el rango
    //    public double Amount { get; set; }

    //    public int PeriodId { get; set; }

    //    //[Required, Range(1, int.MaxValue)]
    //    public int Installments { get; set; }

    //    //[Required, Range(0, double.MaxValue)] // Modifiqué el rango
    //    public double AnnualInterest { get; set; }

    //    //[Required, Range(1, 100)]
    //    public int Commission { get; set; }

    //    public int AmortizationTableId { get; set; }

    //    // [Required]
    //    public bool IsNegotiable { get; set; }

    //    // [Required]
    //    public int WarrantyId { get; set; }

    //    // [Required]
    //    public int BankAccountId { get; set; }

    //    //  [Required, MaxLength(255)]
    //    public string? Description { get; set; }

    //    [MaxLength(255)]
    //    public string? FutureStagesOfTheProject { get; set; }

    //    [MaxLength(200)]
    //    public string? Location { get; set; }

    //    [MaxLength(200)]
    //    public string? WarrantyDescription { get; set; }

    //    public bool? FundsReceived { get; set; }
    //    public string? DestinationBankAccount { get; set; }
    //    public bool? IsScrowAccountDefault { get; set; }

    //    public virtual Client.Customer? Customer { get; set; }
    //    public virtual Period? Period { get; set; }
    //    public virtual Badge? Badge { get; set; }
    //    public virtual RequestStatus? RequestStatus { get; set; }
    //    public virtual Warranty? Warranty { get; set; }
    //}

}
