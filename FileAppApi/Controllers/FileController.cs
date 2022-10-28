using FileAppApi.Models;
using FileAppDomain;
using FileAppDomain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileAppApi.Controllers;

[Route("File")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;
    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("Upload")]
    public IActionResult Upload(FileUploadRequest fileRequest)
    {
        FileContent fileContent = new FileContent
        {
            Storage = fileRequest.Storage,
            FormFile = fileRequest.FormFile
        };

        _fileService.Upload(fileContent);

        return Ok("success");
    }

    [HttpGet("Download")]
    public IActionResult Download(string fileName, string storage)
    {
        FileContent fileContent = new FileContent
        {
            Storage = storage,
            FileName = fileName
        };

        var bytes = _fileService.Download(fileContent);
        MemoryStream ms = new MemoryStream(bytes);
        return new FileStreamResult(ms, "application/text");
    }
}
