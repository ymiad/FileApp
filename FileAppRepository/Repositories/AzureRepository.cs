using Azure.Storage.Blobs;
using FileAppDomain.Models;
using FileAppRepository.Configurations;
using Microsoft.Extensions.Options;

namespace FileAppDomain.Repositories;

public class AzureRepository : IFileRepository
{
    private readonly AzureStorageOptions _storageOptions;
    public AzureRepository(IOptions<AzureStorageOptions> azureStorageOptions)
    {
        _storageOptions = azureStorageOptions.Value;
    }

    public void Create(FileContent fileContent)
    {
        Stream stream = fileContent.FormFile.OpenReadStream();

        var blobContainerClient = new BlobContainerClient(_storageOptions.ConnectionString, _storageOptions.ContainerName);
        var blobClient = blobContainerClient.GetBlobClient(fileContent.FormFile.FileName);

        blobClient.Upload(stream);
    }

    public byte[] Get(string fileName)
    {
        var blobContainerClient = new BlobContainerClient(_storageOptions.ConnectionString, _storageOptions.ContainerName);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        using var ms = new MemoryStream();
        blobClient.DownloadTo(ms);
        return ms.ToArray();
    }

    public void Delete(string fileName)
    {
        var blobContainerClient = new BlobContainerClient(_storageOptions.ConnectionString, _storageOptions.ContainerName);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        blobClient.DeleteIfExists();
    }
}
