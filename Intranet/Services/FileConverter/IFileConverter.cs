using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Services.FileConverter
{
    interface IFileConverter
    {
        IFormFile ConvertBytesToFile(byte[] fileBytes, string contentType, string fileName);
        byte[] ConvertFileToBytes(IFormFile file);
    }
}
