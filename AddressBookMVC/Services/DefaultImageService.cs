using AddressBookMVC.Services.Interfaces;

namespace AddressBookMVC.Services
{
    public class DefaultImageService : IImageService
    {
        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            if (fileData is null)
            {
                return string.Empty;
            }

            string imageBase64Data = Convert.ToBase64String(fileData);
            return $"data:{extension};base64,{imageBase64Data}";
        }

        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            using MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] byteFile = memoryStream.ToArray();
            return byteFile;
        }
    }
}
