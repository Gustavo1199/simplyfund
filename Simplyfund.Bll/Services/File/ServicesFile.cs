using Azure;
using Azure.Storage.Files.Shares;
using Microsoft.Extensions.Configuration;
using Simplyfund.Bll.ServicesInterface.File;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Dto.File;
using SimplyFund.Domain.Models.Common;
using File = System.IO.File;
using System.Security.Cryptography.X509Certificates;


namespace Simplyfund.Bll.Services.Files
{
    public class ServicesFile : IServicesFile
    {
        IConfiguration Configuration;

        public string? conexionString;
        public string? shareName;

        IBaseDatas<EntityType> dataEntityType;
        IBaseDatas<Document> dataDocument;
        public ServicesFile(IConfiguration configuration, IBaseDatas<EntityType> dataEntityType, IBaseDatas<Document> dataDocument)
        {
            Configuration = configuration;
            conexionString = Configuration.GetSection("AzureFileShare:connectionString").Value;
            shareName = Configuration.GetSection("AzureFileShare:shareName").Value;
            this.dataEntityType = dataEntityType;
            this.dataDocument = dataDocument;
        }

        public async Task UploadFilesAsync(List<FileDto> files)
        {
            foreach (var item in files)
            {

                var FileType = await dataEntityType.GetAsync(x => x.Name == item.FileType);
                if (FileType != null)
                {

                    var Document = await dataDocument.GetAsync(x => x.Description == item.Document);
                    if (Document != null)
                    {

                        string temp = Path.Combine($"{Directory.GetCurrentDirectory()}{Configuration.GetSection("FilesDirectory").Value}", item.FileName);

                        using (var stream = new FileStream(temp, FileMode.Create))
                        {
                            if (item.File != null)
                            {
                                item.File.CopyTo(stream);
                            }

                        }

                        ShareClient share = new ShareClient(conexionString, shareName);
                        await share.CreateAsync();

                        ShareDirectoryClient directory = share.GetDirectoryClient(FileType.Name);
                        await directory.CreateAsync();

                        string fileName = Path.GetFileName(temp);
                        ShareFileClient file = directory.GetFileClient(fileName);

                        using (FileStream stream = File.OpenRead(temp))
                        {
                            await file.CreateAsync(stream.Length);
                            await file.UploadRangeAsync(
                                new HttpRange(0, stream.Length),
                                stream);
                        }

                        File.Delete(temp);


                        Console.WriteLine($"Archivo '{fileName}' cargado con éxito.");
                    }
                }

            }
        }




    }
}
