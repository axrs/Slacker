using System;
using System.Collections.Generic;
using System.Text;

namespace Slacker.Native
{
    interface IFileHandler
    {
        string[] ReadAllLines(string file);
        bool Exists(string file);
    }
}
