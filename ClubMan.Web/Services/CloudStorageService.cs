namespace ClubMan.Web.Services;

public class CloudStorageService : ICloudStorageService
{
    public async Task<String> StoreBlob(string fileName, Stream stream)
    {
        var container = new Azure.Storage.Blobs.BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=barolitblobstorage;AccountKey=SQgzWYWHLYFscpvX2cuf9NI4ZPMPtfjEWVW3WEQ8qnKZh7ColquKRM5r0sj7EZXBAbv7D6HK9c7+kzziLEoI0w==;EndpointSuffix=core.windows.net", "clubman");
        stream.Position = 0;
        await container.UploadBlobAsync(fileName, stream);
        return $"https://barolitblobstorage.blob.core.windows.net/clubman/{fileName}";

    }
}