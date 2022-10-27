using FileAppRepository.Interfaces;

namespace FileAppRepository;

public delegate IFileRepository RepositoryResolver(string type);
