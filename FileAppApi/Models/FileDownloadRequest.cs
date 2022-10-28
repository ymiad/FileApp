namespace FileAppApi.Models;

public class FileDownloadRequest
{
    public string FileName { get; set; } = String.Empty;
    public string Storage { get; set; } = String.Empty;
}
