using Microsoft.AspNetCore.Http;
using SimplyFund.Domain.Dto.Base;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.Customer;
using SimplyFund.Domain.Dto.File;
using SimplyFund.Domain.Dto.Warrantys;
using SimplyFund.Domain.Models.Warrantys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Request
{
    public class RequestDatailsDto : EntityBaseDto
    {
        public int RequestStatusId { get; set; }
        public int RequestCategoryId { get; set; }
        public bool RequireInterestInvoice { get; set; }
        public string? Name { get; set; }
        public int CustomerId { get; set; }
        public int BadgeId { get; set; }
        public double Amount { get; set; }
        public int PeriodId { get; set; }
        public int Installments { get; set; }
        public double AnnualInterest { get; set; }
        public int Commission { get; set; }
        public int AmortizationTableId { get; set; }
        public bool IsNegotiable { get; set; }
        public int WarrantyId { get; set; }
        public int BankAccountId { get; set; }
        public string? Description { get; set; }
        public string? FutureStagesOfTheProject { get; set; }
        public string? Location { get; set; }
        public string? WarrantyDescription { get; set; }
        public bool? FundsReceived { get; set; }
        public string? DestinationBankAccount { get; set; }
        public bool? IsScrowAccountDefault { get; set; }

        //public virtual CustomerDto? Customer { get; set; }
        public virtual PeriodDto? Period { get; set; }
        public virtual BadgeDto? Badge { get; set; }
        public virtual RequestStatusDto? RequestStatus { get; set; }
        public virtual WarrantyDto? Warranty { get; set; }
        public List<FileDto>? WarrantyFiles { get; set; }
        
        public int? OfferCount { get; set; }

        public bool Iniciar { get; set; }
        public bool Eliminar { get; set; }
    }

}
