using Microsoft.AspNetCore.Http;
using FileAppService.Interfaces;
using FileInfo = FileAppModel.DBModels.FileInfo;
using FileAppModel.Models;
using FileAppRepository.Interfaces;
using FileAppRepository;

namespace FileAppService.Services
{
    public class FileService : IFileService
    {
        private readonly IFileInfoRepository fileInfoRepository;
        private readonly RepositoryResolver GetFileRepository;

        public FileService(RepositoryResolver repositoryResolver,
                IFileInfoRepository fileInfoRepository)
        {
            GetFileRepository = repositoryResolver;
            this.fileInfoRepository = fileInfoRepository;
        }

        public void Upload(FileRequest fileRequest)
        {
            SaveFile(fileRequest);
            SaveFileInfo(fileRequest);
        }

        public byte[] Download(FileRequest fileRequest)
        {
            var fileRepository = GetFileRepository(fileRequest.Storage);
            return fileRepository.Get(fileRequest.FileName);
        }

        private void SaveFile(FileRequest fileRequest)
        {
            IFileRepository fileRepository = GetFileRepository(fileRequest.Storage);
            fileRepository.Create(fileRequest.FormFile);
        }

        private void SaveFileInfo(FileRequest fileRequest)
        {
            var fileInfo = CreateFileInfo(fileRequest);

            fileInfoRepository.Create(fileInfo);
        }

        private FileInfo CreateFileInfo(FileRequest fileRequest)
        {
            var fileInfo = new FileInfo
            {
                Id = Guid.NewGuid().ToString(),
                Name = fileRequest.FormFile.FileName,
                Storage = fileRequest.Storage
            };

            return fileInfo;
        }
    }
}
