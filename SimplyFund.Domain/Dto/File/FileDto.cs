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
        public string? Document { get; set; }
        public string? EntityType { get; set; }
        public int? EntityId { get; set; }
        public IFormFile? File { get; set; }

    }
}
