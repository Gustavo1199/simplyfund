using SimplyFund.Domain.Base;
using SimplyFund.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Customer
{
    public class LegalRepresentative : EntityBase
    {
        public int CustomerId { get; set; }
        [Required, MaxLength(50)]
        public required  string FirstName { get; set; }
        [MaxLength(50)]
        public string? SecondName { get; set; }
        [Required, MaxLength(50)]
        public required string FirstLastName { get; set; }
        [MaxLength(50)]
        public string? SecondLastName { get; set; }
        public int IdentityTypeId { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
        public int? ProvinceId { get; set; }
        [MaxLength(50)]
        public string? ProvinceName { get; set; }
        [Required, MaxLength(50)]
        public required string? City { get; set; }
        [Required, MaxLength(150)]
        public required string Address1 { get; set; }
        [MaxLength(150)]
        public string? Address2 { get; set; }
        [MaxLength(20)]
        public string? Zipcode { get; set; }
        [Required, MaxLength(150)]
        public string? Email { get; set; }
        [Required, MaxLength(13)]
        public string? MovilePhone { get; set; }

        public virtual Country? Country { get; set; }
        public virtual IdentityType? IdentityType { get; set; }
        public virtual Province? Province { get; set; }
    }
}
