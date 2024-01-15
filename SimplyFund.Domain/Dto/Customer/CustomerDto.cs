using SimplyFund.Domain.Dto.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.Customer
{
    public class CustomerDto : EntityBaseDto
    {

        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? SecondName { get; set; }

        [MaxLength(50)]
        public string? FirstLastName { get; set; }
        [MaxLength(50)]
        public string? SecondLastName { get; set; }
        public int? IdentityTypeId { get; set; }

        [MaxLength(11)]
        public string? IdentityNumber { get; set; }
        public int? CountryId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Email { get; set; }
        public int? CustomerTypeId { get; set; }
        public int StateId { get; set; }
        [MaxLength(13)]
        public string? MovilePhone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        [MaxLength(10)]
        public string? ZipCode { get; set; }
        public int? ProvinceId { get; set; }
        public string? ProvinceName { get; set; }

        public string? SocialReason { get; set; }
        public string? ComertialName { get; set; }
        public int? ConstitutionCountryId { get; set; }
        public bool? IsManco { get; set; }
        public bool? IsFide { get; set; }
        [MaxLength(100)]
        public string? url { get; set; }


        // additional info properties
        public string? Occupation { get; set; }
        public string? Nationality { get; set; }
        public bool? HasDigitalSignature { get; set; }
        public bool? IsPublicOfficer { get; set; }
        public bool? IsRelatedToPublicOfficer { get; set; }
    }
}
