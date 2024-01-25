using Microsoft.AspNetCore.Identity;
using SimplyFund.Domain.Base;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Customer;
using SimplyFund.Domain.Models.Funds;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = SimplyFund.Domain.Models.Common.File;

namespace SimplyFund.Domain.Models.Client
{
    public class Customer : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public required string FirstName { get; set; }
        [MaxLength(50)]
        public string? SecondName { get; set; }
        [Required, MaxLength(50)]
        public required string FirstLastName { get; set; }
        [MaxLength(50)]
        public string? SecondLastName { get; set; }
        public int IdentityTypeId { get; set; }
        [Required]
        [MaxLength(11)]
        public required string IdentityNumber { get; set; }
        public int CountryId { get; set; }
        [Required, MaxLength(100)]
        public required string Address1 { get; set; }
        [MaxLength(100)]
        public string? Address2 { get; set; }
        [Required, MaxLength(100)]
        public required string Email { get; set; }
        public int CustomerTypeId { get; set; }

        [Required, MaxLength(13)]
        public  required string MovilePhone { get; set; }

        public DateTime? BirthDate { get; set; }
        [Required, MaxLength(50)]
        public required string City { get; set; }
        [MaxLength(13)]
        public string? PhoneNumber { get; set; }
        [MaxLength(10)]
        public string? ZipCode { get; set; }
        public int? ProvinceId { get; set; }
        public string? ProvinceName { get; set; }


        // Legal Customer Properties
        public string? SocialReason { get; set; }
        public string? ComertialName { get; set; }
        public int? ConstitutionCountryId { get; set; }
        public bool IsManco { get; set; }
        public bool IsFide { get; set; }
        [MaxLength(100)]
        public string? url { get; set; }

        // additional info properties
        public string? Occupation { get; set; }
        public string? Nationality { get; set; }
        public bool? HasDigitalSignature { get; set; }
        public bool? IsPublicOfficer { get; set; }
        public bool? IsRelatedToPublicOfficer { get; set; } // ¿Está relacionado con un funcionario público?



        public virtual CustomerType? CustomerType { get; set; }
        public virtual IdentityType? IdentityType { get; set; }
        public virtual Country? Country { get; set; }
        public virtual Country? ConstitutionCountry { get; set; }
        public virtual Province? Province { get; set; }

        public virtual List<ContactPerson>? ContactPersons { get; set; }
        public virtual List<LegalRepresentative>? LegalRepresentatives { get; set; }

        //add for edit
        public virtual List<BankAccount>? BankAccounts { get; set; }
        public virtual List<Shareholder>? Shareholders { get; set; }

        [NotMapped]
        public virtual List<File>? Files { get; set; }
        public virtual List<CustomerRequiredDocument>? RequiredDocuments { get; set; }
        public virtual CustomerWorkingInfo? WorkingInfo { get; set; }

        //public virtual CompanyAdditionalInfo? CompanyAdditionalInfo { get; set; }
        public virtual List<SeniorityBalance>? SeniorityBalances { get; set; }
        public virtual List<Fund>? Funds { get; set; }

        [NotMapped]
        public string? Password { get; set; }
        public virtual CustomerFinancialSummary? FinancialSummary { get; set; }

        public virtual List<FinancialSummary>? LegalFinancialSumaries { get; set; }

        //public virtual LaborData? LaborData { get; set; }

        public bool? PasswordChange { get; set; }





    }
}
