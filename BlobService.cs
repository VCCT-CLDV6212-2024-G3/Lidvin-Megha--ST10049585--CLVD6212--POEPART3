using Azure.Storage.Blobs;
using System.Data.SqlClient;

namespace CLVD6212_POEPART3.Services
{
    public class BlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(IConfiguration configuration)
        {
            _blobServiceClient = new BlobServiceClient(configuration["AzureStorage:ConnectionString"]);
        }

        public async Task UploadBlobAsync(string containerName, string blobName, Stream content)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(content, true);
        }
    }
}
