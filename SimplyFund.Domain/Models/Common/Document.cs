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
    public class Document : EntityBase
    {
        [Required, MaxLength(255)]
        public string? Description { get; set; }
        [Required, MaxLength(100)]
        public string? AllowedExtensions { get; set; }





    }
}
