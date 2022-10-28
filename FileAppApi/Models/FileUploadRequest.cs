namespace FileAppApi.Models;

public class FileUploadRequest
{
    public IFormFile FormFile { get; set; }
    public string Storage { get; set; } = String.Empty;
}
