using Microsoft.AspNetCore.Http;

namespace FileAppDomain.Models;

public class FileContent
{
    public IFormFile FormFile { get; set; }
    public string FileName { get; set; } = String.Empty;
    public string Storage { get; set; } = String.Empty;
}
