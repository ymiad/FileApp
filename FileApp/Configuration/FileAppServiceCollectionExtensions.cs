using FileApp.Constants;
using FileAppRepository;
using FileAppRepository.Interfaces;
using FileAppRepository.Repositories;
using FileAppService.Interfaces;
using FileAppService.Services;

namespace FileApp.Configuration;

public static class FileAppServiceCollectionExtensions
{
    public static IServiceCollection AddFileAppRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IRepositoryConfiguration, RepositoryConfiguration>();

        services.AddTransient<IFileInfoRepository, FileInfoRepository>();

        services.AddTransient<LocalRepository>();
        services.AddTransient<AzureRepository>();

        services.AddTransient<RepositoryResolver>(repositoryProvider => type => type switch
            {
                Storage.LocalStorageType => repositoryProvider.GetService<LocalRepository>() ?? throw new ArgumentNullException(),
                Storage.AzureStorageType => repositoryProvider.GetService<AzureRepository>() ?? throw new ArgumentNullException(),
                _ => repositoryProvider.GetService<LocalRepository>() ?? throw new ArgumentNullException()
            });

        return services;
    }

    public static IServiceCollection AddFileAppServices(this IServiceCollection services)
    {
        services.AddTransient<IFileService, FileService>();

        return services;
    }
}
