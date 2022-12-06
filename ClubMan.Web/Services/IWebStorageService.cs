namespace ClubMan.Web.Services;

public interface ICloudStorageService
{
    Task<String> StoreBlob(string fileName, Stream stream);
}