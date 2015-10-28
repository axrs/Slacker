using System;
using System.Collections.Generic;
using System.Text;

namespace Slacker.Native
{
    class WindowsFileHandler : IFileHandler
    {
        public string[] ReadAllLines(string file)
        {
            return System.IO.File.ReadAllLines(file);
        }
        public bool Exists(string file)
        {
            return System.IO.File.Exists(file);
        }
    }
}
