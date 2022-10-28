namespace FileAppRepository.Configurations
{
    public class AzureStorageOptions
    {
        public const string AzureStorage = "Storage:Azure";
        public string ConnectionString { get; set; } = String.Empty;
        public string ContainerName { get; set; } = String.Empty;
    }
}
