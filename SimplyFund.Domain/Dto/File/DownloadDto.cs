using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.File
{
    public class DownloadDto
    {
    }

    public class DownloadResponses
    {
        public string? File { get; set; }
        public string? Error { get; set; }
    }
}
