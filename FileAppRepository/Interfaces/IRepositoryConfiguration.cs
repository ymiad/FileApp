using Microsoft.Extensions.Configuration;

namespace FileAppRepository.Interfaces
{
    public interface IRepositoryConfiguration
    {
        string AzureConnectionString { get; }
        string AzureContainerName { get; }
        string LocalStoragePath { get; }
    }
}
