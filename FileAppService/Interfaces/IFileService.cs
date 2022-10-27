using FileAppModel.Models;

namespace FileAppService.Interfaces
{
    public interface IFileService
    {
        public void Upload(FileRequest fileRequest);
        public byte[] Download(FileRequest fileRequest);
    }
}
