using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.FileConverter
{
    public class FileConverter : IFileConverter
    {
        public IFormFile ConvertBytesToFile(byte[] fileBytes, string contentType, string fileName)
        {
            var stream = new MemoryStream(fileBytes);
            IFormFile file = new FormFile(stream, 0, fileBytes.Length, fileName, fileName);
            return file;
        }

        public byte[] ConvertFileToBytes(IFormFile file)
        {
            byte[] fileBytes = null;

            if (fileBytes != null || file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    fileBytes = memoryStream.ToArray();
                    //string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }
                return fileBytes;
            }

            return null;
        }
    }
}
