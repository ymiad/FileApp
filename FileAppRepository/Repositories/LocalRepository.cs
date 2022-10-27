using Microsoft.AspNetCore.Http;
using FileAppRepository.Interfaces;

namespace FileAppRepository.Repositories
{
    public class LocalRepository : IFileRepository
    {
        private readonly string _storagePath = string.Empty;
        public LocalRepository(IRepositoryConfiguration configuration)
        {
            _storagePath = configuration.LocalStoragePath;
        }

        public void Create(IFormFile file)
        {
            string path = Path.Combine(_storagePath, file.FileName);

            using (var stream = System.IO.File.Create(path))
            {
                file.CopyTo(stream);
            }
        }

        public void Delete(string fileName)
        {
            string path = Path.Combine(_storagePath, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public byte[] Get(string fileName)
        {
            string path = Path.Combine(_storagePath, fileName);
            byte[] bytes = File.ReadAllBytes(path);
            return bytes;
        }
    }
}
