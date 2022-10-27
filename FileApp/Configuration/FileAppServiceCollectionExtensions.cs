using FileAppHelper.Constnats;
using FileAppRepository;
using FileAppRepository.Interfaces;
using FileAppRepository.Repositories;
using FileAppService.Interfaces;
using FileAppService.Services;

namespace FileApp.Configuration
{
    public static class FileAppServiceCollectionExtensions
    {
        public static IServiceCollection AddFileAppRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRepositoryConfiguration, RepositoryConfiguration>();

            services.AddTransient<IFileInfoRepository, FileInfoRepository>();

            services.AddTransient<LocalRepository>();
            services.AddTransient<AzureRepository>();


            services.AddTransient<RepositoryResolver>(repositoryProvider => type =>
            {
                switch (type)
                {
                    case Storage.LocalStorageType:
                        return repositoryProvider.GetService<LocalRepository>();
                    case Storage.AzureStorageType:
                        return repositoryProvider.GetService<AzureRepository>();
                    default:
                        return repositoryProvider.GetService<LocalRepository>();
                }
            });

            return services;
        }

        public static IServiceCollection AddFileAppServices(this IServiceCollection services)
        {
            services.AddTransient<IFileService, FileService>();

            return services;
        }
    }
}
