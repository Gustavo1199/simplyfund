using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Simplyfund.Bll.ServicesInterface.File;
using SimplyFund.Domain.Dto.File;
using SimplyFund.Domain.Dto.Responses;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SimplyFund.File.Controllers.File
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        public readonly IServicesFile servicesFile;
        ErrorResponses errorResponses;

        public FileController(IServicesFile servicesFile)
        {
            this.servicesFile = servicesFile;
            errorResponses = new ErrorResponses();

        }



        [HttpPost("UploadFilesListAsync")]
        public async Task<ActionResult> UploadFileListsAsync([FromForm] List<FileDto> files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await servicesFile.UploadFilesAsync(files);

                    return Ok(files);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpPost("UploadFilesAsync")]
        public async Task<ActionResult> UploadFilesAsync([FromForm] FileDto files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<FileDto> list = new List<FileDto> { files };
                    await servicesFile.UploadFilesAsync(list);

                    return Ok(files);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpPut("UpdateFileAsync")]
        public async Task<ActionResult> UpdateFileAsync([FromForm] FileDto files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<FileDto> list = new List<FileDto> { files };
                    var responses = await servicesFile.UpdateFileAsync(list);

                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpGet("DownloadFileAsync")]
        public async Task<ActionResult<DownloadResponses>> DownloadFileAsync(int FileId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responses = await servicesFile.DownloadFileAsync(FileId);

                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }



        [HttpDelete("DeleteFileAsync")]
        public async Task<ActionResult<DownloadResponses>> DeleteFileAsync(int FileId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responses = await servicesFile.DeleteFileAsync(FileId);

                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpGet("DownloadFileManyAsync")]
        public async Task<ActionResult<DownloadResponses>> DownloadFileManyAsync([FromQuery] List<int> FileId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responses = await servicesFile.DownloadFileManyAsync(FileId);

                    return Ok(responses);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }



        [NonAction]
        public  void InitializeConsumerFiles()
        {
            Task.Run(() => ListenToRabbitMQ());
        }


        private void ListenToRabbitMQ()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclarePassive("fileQueue");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var request = JsonConvert.DeserializeObject<List<FileDto>>(message);
                List<FileDto> files = new List<FileDto>();
                if (request != null)
                {
                    foreach (var item in request)
                    {
                        item.File = ConvertByteArrayToIFormFile(item.Content, item.FileName, item.FileType, item.ContentDisposition);
                        files.Add(item);
                    }
                }

                await servicesFile.UploadFilesAsync(files);
            };

            channel.BasicConsume(queue: "fileQueue", autoAck: true, consumer: consumer);

            // Espera infinita para que el hilo no termine y el método continúe escuchando
            while (true)
            {
                Thread.Sleep(1000); // Puedes ajustar el tiempo de espera según sea necesario
            }
        }

     
        //public IFormFile ConvertByteArrayToIFormFile(byte[] fileBytes, string fileName, string contentType, string contentDisposition)
        //{
        //    using (MemoryStream memoryStream = new MemoryStream(fileBytes))
        //    {
        //        IFormFile file = new FormFile(memoryStream, 0, fileBytes.Length, "file", fileName)
        //        {
        //            Headers = new HeaderDictionary(),
        //            ContentType = contentType,
        //            ContentDisposition = contentDisposition
        //        };

        //        return file;
        //    }
        //}


        [NonAction]
        public IFormFile ConvertByteArrayToIFormFile(byte[] fileBytes, string fileName, string contentType, string contentDisposition)
        {
            MemoryStream memoryStream = new MemoryStream(fileBytes);

            IFormFile file = new FormFile(memoryStream, 0, fileBytes.Length, "Files", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType,
                ContentDisposition = contentDisposition
            };

          

            return file;
        }

    }
}
