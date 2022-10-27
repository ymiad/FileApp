using Microsoft.AspNetCore.Http;

namespace FileAppRepository.Interfaces
{
    public interface IFileRepository
    {
        void Create(IFormFile file);
        void Delete(string fileName);
        byte[] Get(string fileName);
    }
}
