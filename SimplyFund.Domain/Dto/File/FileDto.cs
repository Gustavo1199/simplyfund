using SimplyFund.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SimplyFund.Domain.Dto.File
{
    public class FileDto
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        [Required]

        public string? Document { get; set; }
        [Required]
        public string? EntityType { get; set; }
        [Required]
        public int? EntityId { get; set; }
        [Required]
        public IFormFile? File { get; set; }

        public byte[]? Content { get; set; }
        public int? EntityTypeId { get; set; }
        public int? DocumentId { get; set; }
        public string? ShareName { get; set; }
        public string? DirName { get; set; }
        public int? FileId { get; set; }

        public string? ContentDisposition { get; set; }

    }
}
