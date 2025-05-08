namespace DatabasesComplusory.Application.Interfaces
{
    public interface IBlobStorageService
    {
        Task<string> UploadFileAsync(string containerName, Stream fileStream, string fileName, string contentType);
        Task<string> GetFileUrlAsync(string fileName);
        Task DeleteFileAsync(string containerName, string fileName);   
    }
}