namespace JourneyLog.BLL.Services.Interfaces;

public interface IBlobStorageService
{
    Task<string> CreateImageAsyncAndGetFileName(string imageBase64);
    Task DeleteImageAsync(string fileName);
}