using Pulumi;
using Pulumi.Serialization;
using Azure = Pulumi.Azure;

class MyStack : Stack
{
    public MyStack()
    {
        var resourceGroup = new Azure.Core.ResourceGroup(Settings.ResourceGroupName);
        var storageAccount = new Azure.Storage.Account(Settings.StorageAccountName, new Azure.Storage.AccountArgs
        {
            ResourceGroupName = resourceGroup.Name,
            AccountReplicationType = "LRS",
            AccountTier = "Standard"
        });
        var container = new Azure.Storage.Container(Settings.ContainerName, new Azure.Storage.ContainerArgs 
        {
            StorageAccountName = storageAccount.Name
        });

        this.AccountName = storageAccount.Name;
    }

    [Output]
    public Output<string> AccountName { get; set; }
}
