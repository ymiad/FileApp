using FileAppDomain.Models;

namespace FileAppDomain;

public interface IFileService
{
    public void Upload(FileContent fileRequest);
    public byte[] Download(FileContent fileRequest);
}
