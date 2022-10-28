using FileAppDomain.Models;

namespace FileAppDomain;

public interface IFileRepository
{
    void Create(FileContent file);
    void Delete(string fileName);
    byte[] Get(string fileName);
}
