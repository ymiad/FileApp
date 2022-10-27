using FileAppModel.Models;
using FileAppService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileApp.Controllers
{
    [Route("File")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("Upload")]
        public IActionResult Upload(FileRequest fileRequest)
        {
            if (fileRequest.FormFile.Length > 0)
            {
                _fileService.Upload(fileRequest);
            }

            return Ok("success");
        }

        [HttpGet("Download")]
        public IActionResult Download(string fileName, string storage)
        {
            var fileRequest = new FileRequest
            {
                Storage = storage,
                FileName = fileName
            };
            var bytes = _fileService.Download(fileRequest);
            MemoryStream ms = new MemoryStream(bytes);
            return new FileStreamResult(ms, "application/png");
        }
    }
}
