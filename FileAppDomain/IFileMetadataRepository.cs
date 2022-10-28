using FileAppDomain.Models;

namespace FileAppDomain;

public interface IFileMetadataRepository
{
    public void Create(FileContent fileInfo);
}
