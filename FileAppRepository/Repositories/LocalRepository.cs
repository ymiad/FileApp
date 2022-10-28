using FileAppDomain.Models;
using FileAppRepository.Configurations;
using Microsoft.Extensions.Options;

namespace FileAppDomain.Repositories;

public class LocalRepository : IFileRepository
{
    private readonly LocalStorageOptions _storageOptions;
    public LocalRepository(IOptions<LocalStorageOptions> localStorageOptions)
    {
        _storageOptions = localStorageOptions.Value;
    }

    public void Create(FileContent fileContent)
    {
        string path = Path.Combine(_storageOptions.Path, fileContent.FormFile.FileName);

        using var stream = System.IO.File.Create(path);
        fileContent.FormFile.CopyTo(stream);
    }

    public void Delete(string fileName)
    {
        string path = Path.Combine(_storageOptions.Path, fileName);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public byte[] Get(string fileName)
    {
        string path = Path.Combine(_storageOptions.Path, fileName);
        byte[] bytes = File.ReadAllBytes(path);
        return bytes;
    }
}
