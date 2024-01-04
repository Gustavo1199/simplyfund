using SimplyFund.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Models.Common
{
    public class File : EntityBase
    {

        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }

        //[ForeignKey("Document")]
        public int? DocumentId { get; set; }
        //public virtual Document? Document { get; set; }

        //[ForeignKey("EntityType")]
        public int? EntityTypeId { get; set; }
        public virtual EntityType? EntityTypes { get; set; }

        [Required]
        [StringLength(100)]
        public string? ShareName { get; set; }

        [Required]
        [StringLength(100)]
        public string? DirName { get; set; }


        public int? EntityId { get; set; }


    }
}
