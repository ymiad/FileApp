using Azure.Storage.Blobs;
using FileAppRepository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FileAppRepository.Repositories
{
    public class AzureRepository : IFileRepository
    {
        private readonly string _connectionString;
        private readonly string _containerName;
        public AzureRepository(IRepositoryConfiguration configuration)
        {
            _connectionString = configuration.AzureConnectionString;
            _containerName = configuration.AzureContainerName;
        }

        public void Create(IFormFile formFile)
        {
            Stream stream = formFile.OpenReadStream();

            var blobContainerClient = new BlobContainerClient(_connectionString, _containerName);
            var blobClient = blobContainerClient.GetBlobClient(formFile.FileName);

            blobClient.Upload(stream);
        }

        public byte[] Get(string fileName)
        {
            var blobContainerClient = new BlobContainerClient(_connectionString, _containerName);
            var blobClient = blobContainerClient.GetBlobClient(fileName);

            using (var ms = new MemoryStream())
            {
                blobClient.DownloadTo(ms);
                return ms.ToArray();
            }
        }

        public void Delete(string fileName)
        {
            var blobContainerClient = new BlobContainerClient(_connectionString, _containerName);
            var blobClient = blobContainerClient.GetBlobClient(fileName);

            blobClient.DeleteIfExists();
        }
    }
}
