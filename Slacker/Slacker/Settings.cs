using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Slacker
{
    class Settings : ISettings
    {

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
        string key,
        string val,
        string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
        string key,
        string def,
        StringBuilder retVal,
        int size,
        string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSection(string section,
        IntPtr lpReturnedString,
        int size,
        string filePath);

        private string _filePath;
        public Settings()
        {
            file = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\config.ini";
        }

        public Settings(string filePath)
        {
            file = filePath;
        }

        public string file
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                if (!System.IO.File.Exists(_filePath))
                {
                    set("GENERAL", "VERSION", "0.0.1");
                }
            }
        }

        public void set(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value.ToLower(), file);
        }

        public string get(string section, string key, string def = "")
        {
            StringBuilder SB = new StringBuilder(32767);
            int i = GetPrivateProfileString(section, key, def, SB, 32767, file);
            return SB.ToString();
        }

    }
}
