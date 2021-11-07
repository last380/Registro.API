﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Registro.API.Repositories
{
    public class LocalStorageImageRepository : IImageRepository
    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return GetServerRelativepath(fileName);

        }

        private string GetServerRelativepath(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }
    }
}
