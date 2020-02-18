using Pulumi;

static class Settings
{
    static Settings()
    {
        var config = new Config();
        ContainerName = config.Require("container");
        ResourceGroupName = config.Require("resource-group");
        StorageAccountName = config.Require("storage-account");
    }

    public static string ResourceGroupName { get; }
    public static string StorageAccountName { get; }
    public static string ContainerName { get; }
}
