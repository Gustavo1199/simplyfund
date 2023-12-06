using Microsoft.AspNetCore.Mvc;
using Simplyfund.Bll.ServicesInterface.File;
using SimplyFund.Domain.Dto.File;
using SimplyFund.Domain.Dto.Responses;
using System.Collections.Generic;

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

    }
}
