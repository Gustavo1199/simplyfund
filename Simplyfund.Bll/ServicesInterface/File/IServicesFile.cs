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
        Task UploadFilesAsyncConteiner(List<FileDto> files);
        Task UploadFilesAsync(List<FileDto> files);
        Task<DownloadResponses> DownloadFileAsync(int FileId);

        Task<List<DownloadResponses>> DownloadFileManyAsync(List<int> FileId);

        Task<List<DownloadResponses>> UpdateFileAsync(List<FileDto> files);

        Task<DownloadResponses> DeleteFileAsync(int FileId);


        Task<DownloadResponses> DeleteFileConteinerAsync(int fileId);
    }
}
