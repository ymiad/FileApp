using Microsoft.Extensions.Configuration;
using FileAppRepository.Interfaces;

namespace FileAppRepository
{
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        private readonly IConfiguration _configuration;

        public RepositoryConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string AzureConnectionString => _configuration["Storage:Azure:AzureWebJobsStorage"];
        public string AzureContainerName => _configuration["Storage:Azure:ContainerName"];
        public string LocalStoragePath => _configuration["Storage:LocalStorePath"];
    }
}
