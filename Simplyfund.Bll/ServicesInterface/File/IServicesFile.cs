using SimplyFund.Domain.Dto.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.ServicesInterface.File
{
    public interface IServicesFile
    {
        Task UploadFilesAsync(List<FileDto> files);
    }
}
