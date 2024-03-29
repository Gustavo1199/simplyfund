﻿using Azure;
using Azure.Storage.Files.Shares;
using Microsoft.Extensions.Configuration;
using Simplyfund.Bll.ServicesInterface.File;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Dto.File;
using SimplyFund.Domain.Models.Common;
using File = System.IO.File;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Azure.Storage.Files.Shares.Models;
using SimplyFund.Domain.Dto.ViaFirma;
using Document = SimplyFund.Domain.Models.Common.Document;
using System.ComponentModel.Design;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Blob;
using Azure.Storage.Sas;
using Azure.Storage;
using Azure.Storage.Blobs;

namespace Simplyfund.Bll.Services.Files
{
    public class ServicesFile : IServicesFile
    {
        IConfiguration Configuration;
        public string? conexionString;
        public string? shareName;

        IBaseDatas<EntityType> dataEntityType;
        IBaseDatas<Document> dataDocument;
        IBaseDatas<SimplyFund.Domain.Models.Common.File> dataFile;
        IMapper mapper;

        public ServicesFile(IConfiguration configuration, IBaseDatas<EntityType> dataEntityType, IBaseDatas<Document> dataDocument, IBaseDatas<SimplyFund.Domain.Models.Common.File> dataFile, IMapper mapper)
        {
            Configuration = configuration;
            this.dataEntityType = dataEntityType;
            this.dataDocument = dataDocument;



            conexionString = Configuration.GetSection("AzureFileShare:connectionString").Value;
            shareName = Configuration.GetSection("AzureFileShare:shareName").Value;
            this.dataFile = dataFile;
            this.mapper = mapper;
        }

        public async Task UploadFilesAsync(List<FileDto> files)
        {
            foreach (var item in files)
            {

                var FileType = await dataEntityType.GetAsync(x => x.Name == item.EntityType);
                if (FileType != null)
                {

                    var Document = await dataDocument.GetAsync(x => x.Description == item.Document);
                    if (Document != null)
                    {
                        item.DocumentId = Document.Id;
                        item.EntityTypeId = FileType.Id;
                        item.ShareName = shareName;
                        item.DirName = FileType.Name;

                        if (item.File != null)
                        {
                            item.FileName = DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + item.File.FileName;

                        }


                        string temp = Path.Combine($"{Directory.GetCurrentDirectory()}{Configuration.GetSection("FilesDirectory").Value}", item.FileName);
                        item.FilePath = temp;
                        using (var stream = new FileStream(temp, FileMode.Create))
                        {
                            if (item.File != null)
                            {
                                await item.File.CopyToAsync(stream);
                                item.FileType = item.File.ContentType;
                                item.Length = item.File.Length;



                            }
                        }

                        ShareClient share = new ShareClient(conexionString, shareName);

                        if (!await share.ExistsAsync())
                        {
                            await share.CreateAsync();
                        }


                        ShareDirectoryClient directory = share.GetDirectoryClient(FileType.Name);
                        if (!await directory.ExistsAsync())
                        {
                            await directory.CreateAsync();

                        }

                        string fileName = Path.GetFileName(temp);
                        ShareFileClient file = directory.GetFileClient(fileName);

                        using (var stream = File.OpenRead(temp))
                        {
                            await file.CreateAsync(stream.Length);
                            await file.UploadRangeAsync(
                                new HttpRange(0, stream.Length),
                                stream);
                        }


                        // var url =  GenerateSignature(file);

                        string? sasToken = Configuration.GetSection("AzureFileShare:SasToken").Value;

                        item.FilePath = file.Uri.ToString() + sasToken;




                        await saveFile(item);

                        File.Delete(temp);


                        Console.WriteLine($"Archivo '{fileName}' cargado con éxito.");
                    }
                }

            }
        }


        public async Task UploadFilesAsyncConteiner(List<FileDto> files)
        {
            foreach (var item in files)
            {
                var FileType = await dataEntityType.GetAsync(x => x.Name == item.EntityType);
                if (FileType != null)
                {
                    var Document = await dataDocument.GetAsync(x => x.Description == item.Document);
                    if (Document != null)
                    {
                        item.DocumentId = Document.Id;
                        item.EntityTypeId = FileType.Id;

                        if (item.File != null)
                        {
                            item.FileName = DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + item.File.FileName;
                        }

                        string? blobContainerName = Configuration.GetSection("AzureBlobStorage:ContainerName").Value;
                        BlobServiceClient blobServiceClient = new BlobServiceClient(Configuration.GetSection("AzureBlobStorage:ConnectionString").Value);
                        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);

                        if (!await containerClient.ExistsAsync())
                        {
                            await containerClient.CreateAsync();
                        }

                        BlobClient blobClient = containerClient.GetBlobClient(item.FileName);

                        if (item != null)
                        {
                            if (item.File != null)
                            {

                                using (var stream = item.File.OpenReadStream())
                                {
                                    await blobClient.UploadAsync(stream, true);
                                }

                                item.FileType = item.File.ContentType;
                                item.Length = item.File.Length;

                                // You can generate a SAS token if needed
                                // var sasToken = GenerateSasToken(blobClient.Uri);

                                item.FilePath = blobClient.Uri.ToString();

                                await saveFile(item);
                            }

                            Console.WriteLine($"Archivo '{item.FileName}' cargado con éxito.");
                        }
                    }
                }
            }
        }


        public async Task<DownloadResponses> DownloadFileAsync(int FileId)
        {
            try
            {


                var files = dataFile.Get(x => x.Id == FileId);
                DownloadResponses downloadResponses = new DownloadResponses();

                if (files != null)
                {

                    string relativePath = Path.Combine($"{Configuration.GetSection("FilesDirectory").Value}", files.FileName);
                    string localFilePath = Path.Combine($"{Directory.GetCurrentDirectory()}" + relativePath);

                    ShareClient share = new ShareClient(conexionString, shareName);
                    ShareDirectoryClient directory = share.GetDirectoryClient(files.DirName);
                    ShareFileClient file = directory.GetFileClient(files.FileName);

                    ShareFileDownloadInfo download = await file.DownloadAsync();

                    using (FileStream stream = File.OpenWrite(localFilePath))
                    {
                        await download.Content.CopyToAsync(stream);
                    }

                    downloadResponses.Error = null;
                    downloadResponses.File = relativePath;

                }
                else
                {
                    downloadResponses.Error = "El archivo especificado no existe";
                    downloadResponses.File = null;

                }

                return downloadResponses;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<DownloadResponses>> DownloadFileManyAsync(List<int> FileId)
        {
            if (FileId != null)
            {
                List<DownloadResponses> responses = new List<DownloadResponses>();

                foreach (var item in FileId)
                {
                    DownloadResponses downloadResponses = new DownloadResponses();

                    var files = dataFile.Get(x => x.Id == item);

                    if (files != null)
                    {
                        string relativePath = Path.Combine($"{Configuration.GetSection("FilesDirectory").Value}", files.FileName);
                        string localFilePath = Path.Combine($"{Directory.GetCurrentDirectory()}" + relativePath);


                        ShareClient share = new ShareClient(conexionString, shareName);
                        ShareDirectoryClient directory = share.GetDirectoryClient(files.DirName);
                        ShareFileClient file = directory.GetFileClient(files.FileName);

                        ShareFileDownloadInfo download = await file.DownloadAsync();

                        using (FileStream stream = File.OpenWrite(localFilePath))
                        {
                            await download.Content.CopyToAsync(stream);
                        }

                        downloadResponses.File = relativePath;
                        downloadResponses.Error = null;
                    }
                    else
                    {
                        downloadResponses.Error = $"Archivo {item} no existe";
                        downloadResponses.File = null;
                    }


                    responses.Add(downloadResponses);
                }

                return responses;
            }
            else
            {
                throw new ArgumentNullException("La lista no puede esta null");
            }

        }


        public async Task<List<DownloadResponses>> UpdateFileAsync(List<FileDto> files)
        {
            List<DownloadResponses> responses = new List<DownloadResponses>();
            foreach (var item in files)
            {
                DownloadResponses downloadResponses = new DownloadResponses();
                var Files = await dataFile.GetAsync(x => x.Id == item.FileId);
                if (Files != null)
                {

                    string updatedLocalFilePath = Path.Combine($"{Directory.GetCurrentDirectory()}{Configuration.GetSection("FilesDirectory").Value}", Files.FileName);
                    using (var stream = new FileStream(updatedLocalFilePath, FileMode.Create))
                    {
                        if (item.File != null)
                        {
                            item.File.CopyTo(stream);
                            item.FileType = item.File.ContentType;
                        }

                    }


                    ShareClient share = new ShareClient(conexionString, shareName);
                    ShareDirectoryClient directory = share.GetDirectoryClient(Files.DirName);
                    ShareFileClient file = directory.GetFileClient(Files.FileName);

                    if (!await file.ExistsAsync())
                    {
                        downloadResponses.Error = "El archivo no existe en azure ";
                    }

                    using (FileStream stream = File.OpenRead(updatedLocalFilePath))
                    {
                        await file.UploadRangeAsync(
                            new HttpRange(0, stream.Length),
                            stream);
                    }

                    downloadResponses.File = "Archivo actualizado con éxito.";
                }
                else
                {
                    downloadResponses.Error = $"Archivo {item.FileId} no existe";
                }
                responses.Add(downloadResponses);

            }


            return responses;

        }

        public async Task<DownloadResponses> DeleteFileAsync(int FileId)
        {
            try
            {


                DownloadResponses downloadResponses = new DownloadResponses();


                var Files = await dataFile.GetAsync(x => x.Id == FileId);

                if (Files != null)
                {
                    ShareClient share = new ShareClient(conexionString, shareName);
                    ShareDirectoryClient directory = share.GetDirectoryClient(Files.DirName);
                    ShareFileClient file = directory.GetFileClient(Files.FileName);

                    if (await file.ExistsAsync())
                    {
                        await file.DeleteIfExistsAsync();

                        downloadResponses.File = "Archivo eliminado con éxito de forma asíncrona.";

                        var delete = await dataFile.DeleteAsync(Files);
                    }
                    else
                    {
                        downloadResponses.Error = "El archivo no existe en Azure Storage.";
                    }
                }
                else
                {
                    downloadResponses.Error = "No existe el este archivo ";
                }

                return downloadResponses;

            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<DownloadResponses> DeleteFileConteinerAsync(int fileId)
        {
            try
            {
                DownloadResponses downloadResponses = new DownloadResponses();

                var file = await dataFile.GetAsync(x => x.Id == fileId);

                if (file != null)
                {
                    string? blobContainerName = Configuration.GetSection("AzureBlobStorage:ContainerName").Value;
                    BlobServiceClient blobServiceClient = new BlobServiceClient(Configuration.GetSection("AzureBlobStorage:ConnectionString").Value);
                    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);
                    BlobClient blobClient = containerClient.GetBlobClient(file.FileName);

                    if (await blobClient.ExistsAsync())
                    {
                        await blobClient.DeleteIfExistsAsync();

                        downloadResponses.File = "Archivo eliminado con éxito de forma asíncrona.";

                        var delete = await dataFile.DeleteAsync(file);
                    }
                    else
                    {
                        downloadResponses.Error = "El archivo no existe en Azure Blob Storage.";
                    }
                }
                else
                {
                    downloadResponses.Error = "No existe este archivo.";
                }

                return downloadResponses;
            }
            catch (Exception)
            {
                throw;
            }
        }




        public string GenerateSignature(ShareFileClient file)
        {
            var accountName = Configuration.GetSection("AzureFileShare:AccountName").Value;
            var accountKey = Configuration.GetSection("AzureFileShare:AccountKey").Value;

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(accountName, accountKey);

            // Crear el generador de SAS para el archivo de Share
            ShareSasBuilder sasBuilder = new ShareSasBuilder
            {
                ShareName = file.ShareName,
                FilePath = file.Name,
                Resource = "f",
                StartsOn = DateTimeOffset.UtcNow,
                ExpiresOn = DateTimeOffset.MaxValue,
            };

            sasBuilder.SetPermissions(ShareSasPermissions.Read);

            // Obtener la firma de acceso compartido (SAS)
            string sasBlobToken = sasBuilder.ToSasQueryParameters(sharedKeyCredential).ToString();

            Uri blobSasUri = new Uri(file.Uri + "?" + sasBlobToken);

            return blobSasUri.ToString();
        }


        async Task saveFile(FileDto item)
        {
            try
            {
                var models = mapper.Map<SimplyFund.Domain.Models.Common.File>(item);
                await dataFile.AddAsync(models);
            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}
