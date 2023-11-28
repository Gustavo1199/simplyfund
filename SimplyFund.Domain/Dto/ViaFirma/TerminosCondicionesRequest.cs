using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFund.Domain.Dto.ViaFirma
{

    public class TerminosCondicionesRequest
    {
        public string? groupCode { get; set; }
        public string? externalCode { get; set; }
        public Workflow? workflow { get; set; }
        public Notification? notification { get; set; }
        public Document? document { get; set; }
        public List<MetadataList>? metadataList { get; set; }
    }

}
