using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using DatabasesComplusory.Application.Interfaces;

namespace DatabasesComplusory.Application.Service;

public class BlobStorageService : IBlobStorageService
{

    private readonly BlobServiceClient _blobStorageClient;

    public BlobStorageService(BlobServiceClient blobStorageService)
    {
        _blobStorageClient = blobStorageService;
    }
    public async Task<string> UploadFileAsync(string containerName, Stream fileStream, string fileName, string contentType)
    {
        var container = _blobStorageClient.GetBlobContainerClient(containerName);
        await container.CreateIfNotExistsAsync(PublicAccessType.Blob);

        var blob = container.GetBlobClient(fileName);
        await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });
        return blob.Uri.ToString();
    }
    public Task<string> GetFileUrlAsync(string fileName)
    {
        throw new NotImplementedException();
    }
    public async Task DeleteFileAsync(string containerName, string fileName)
    {
        var container = _blobStorageClient.GetBlobContainerClient(containerName);
        var blob = container.GetBlobClient(containerName);
        await blob.DeleteIfExistsAsync();
    }
}