namespace Wolds.Hr.Api.Cr.Library.Helpers.Interfaces;

internal interface IAzureStorageBlobHelper
{
    Task SaveBlobToAzureStorageContainerAsync(IFormFile file, string containerName, string fileName);
    Task DeleteBlobInAzureStorageContainerAsync(string fileName, string containerName);
}