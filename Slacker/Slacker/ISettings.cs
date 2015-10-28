using System;
using System.Collections.Generic;
using System.Text;

namespace Slacker
{
    interface ISettings
    {
        void set(string section, string key, string value);
        string get(string section, string key, string def);
    }
}
