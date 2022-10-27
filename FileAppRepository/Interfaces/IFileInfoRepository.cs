using FileInfo = FileAppModel.DBModels.FileInfo;

namespace FileAppRepository.Interfaces
{
    public interface IFileInfoRepository
    {
        public void Create(FileInfo fileInfo);
    }
}
