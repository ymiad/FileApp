using FileAppRepository.Interfaces;

namespace FileAppService.Interfaces;

public interface IRepositoryProvider
{
    IFileRepository GetRepository(string type);
}
