using FileAppDomain;
using FileAppDomain.Repositories;
using FileAppService;

namespace FileAppWebApi.Configuration;

public static class ContainerConfiguration
{
    public static IServiceCollection AddFileAppRepositories(this IServiceCollection services)
    {
        //services.AddSingleton<IRepositoryConfiguration, RepositoryConfiguration>();

        services.AddSingleton<IFileRepositoryFactory, FileRepositoryFactory>();


        services.AddTransient<IFileMetadataRepository, FileMetadataRepository>();

        return services;
    }

    public static IServiceCollection AddFileAppServices(this IServiceCollection services)
    {
        services.AddTransient<IFileService, FileService>();

        return services;
    }
}
