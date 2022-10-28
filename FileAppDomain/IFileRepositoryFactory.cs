namespace FileAppDomain
{
    public interface IFileRepositoryFactory
    {
        IFileRepository GetFileRepository(string storageType);
    }
}
