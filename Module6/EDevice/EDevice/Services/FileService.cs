using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using EDevice.Abstractions;

namespace EDevice
{
    public class FileService : IFileService
    {
        public string ReadFromFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
