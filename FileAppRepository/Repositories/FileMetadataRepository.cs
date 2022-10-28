using FileAppDomain.Models;

namespace FileAppDomain.Repositories;

public class FileMetadataRepository : IFileMetadataRepository
{
    public void Create(FileContent fileContent)
    {
        var fileMetadata = new FileMetadata
        {
            Id = Guid.NewGuid().ToString(),
            Name = fileContent.FormFile.FileName,
            Storage = fileContent.Storage
        };

        //save to db...
    }
}
