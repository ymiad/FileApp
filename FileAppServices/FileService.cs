using FileAppDomain.Models;
using FileAppDomain;

namespace FileAppService;

public class FileService : IFileService
{
    private readonly IFileRepositoryFactory _fileRepositoryFactory;
    private readonly IFileMetadataRepository _fileMetadataRepository;

    public FileService(IFileRepositoryFactory fileRepositoryFactory,
            IFileMetadataRepository fileInfoRepository)
    {
        _fileRepositoryFactory = fileRepositoryFactory;
        _fileMetadataRepository = fileInfoRepository;
    }

    public void Upload(FileContent fileContent)
    {
        SaveFile(fileContent);
        SaveFileInfo(fileContent);
    }

    public byte[] Download(FileContent fileContent)
    {
        IFileRepository fileRepository = _fileRepositoryFactory.GetFileRepository(fileContent.Storage);
        return fileRepository.Get(fileContent.FileName);
    }

    private void SaveFile(FileContent fileContent)
    {
        IFileRepository fileRepository = _fileRepositoryFactory.GetFileRepository(fileContent.Storage);
        fileRepository.Create(fileContent);
    }

    private void SaveFileInfo(FileContent fileContent)
    {
        _fileMetadataRepository.Create(fileContent);
    }
}
