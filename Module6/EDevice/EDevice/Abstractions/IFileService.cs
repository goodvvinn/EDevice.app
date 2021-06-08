using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDevice.Abstractions
{
    public interface IFileService
    {
        string ReadFromFile(string path);
    }
}
