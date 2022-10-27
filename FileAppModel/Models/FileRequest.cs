using Microsoft.AspNetCore.Http;

namespace FileAppModel.Models
{
    public class FileRequest
    {
        public IFormFile FormFile { get; set; }
        public string FileName { get; set; }
        public string Storage { get; set; }
    }
}
