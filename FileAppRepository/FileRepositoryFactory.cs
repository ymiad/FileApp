using FileAppDomain.Constants;
using FileAppDomain.Repositories;
using FileAppRepository.Configurations;
using Microsoft.Extensions.Options;

namespace FileAppDomain;

public class FileRepositoryFactory : IFileRepositoryFactory
{
    private readonly IOptions<AzureStorageOptions> _azureStorageOptions;
    private readonly IOptions<LocalStorageOptions> _localStorageOptions;

    public FileRepositoryFactory(IOptions<AzureStorageOptions> azureStorageOptions,
        IOptions<LocalStorageOptions> localStorageOptions)
    {
        _azureStorageOptions = azureStorageOptions;
        _localStorageOptions = localStorageOptions;
    }

    public IFileRepository GetFileRepository(string storageType)
    {
        return storageType switch
        {
            Storage.LocalStorageType => new LocalRepository(_localStorageOptions),
            Storage.AzureStorageType => new AzureRepository(_azureStorageOptions),
            _ => new AzureRepository(_azureStorageOptions)
        };
    }
}
