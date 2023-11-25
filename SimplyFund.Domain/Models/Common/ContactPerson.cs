using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class ContactPerson : EntityBase
    {
        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Required, MaxLength(50)]
        public required string JobTitle { get; set; }

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
        public required string Email { get; set; }

        [Required, MaxLength(13)]
        public required string MovilePhone { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required, MaxLength(50)]
        public required string City { get; set; }
        [MaxLength(13)]
        public string? PhoneNumber { get; set; }
        [MaxLength(10)]
        public string? ZipCode { get; set; }
        public int? ProvinceId { get; set; }
        public string? ProvinceName { get; set; }

        public string? WorkedTime { get; set; }


        public virtual IdentityType? IdentityType { get; set; }
        public virtual Country? Country { get; set; }
        public virtual Province? Province { get; set; }

        //public virtual Customer Customer { get; set; }
    }
}
