using System.IO;
using Microsoft.AspNetCore.Http;

namespace WeAreNotGoodFood.Services
{
    public class FileUploadServiceWe
    {
        public FileUploadServiceWe()
        {
            
        }
        public async void Upload(string path, string fileName, IFormFile file)
        {
            Directory.CreateDirectory(path);
            using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}