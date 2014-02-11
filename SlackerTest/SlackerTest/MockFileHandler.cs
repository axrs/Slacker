using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlackerTest
{
    class MockFileHandler : Slacker.Native.IFileHandler
    {
        public string[] ReadAllLines(string file)
        {
            string[] lines = { 
                                 "\"Tag 1\",\"Notes\",\"10/02/2014\",\"Total\"",
                                 "\"B14101\",\"C/F Shading\",\"0.25\",\"0.25\"", 
                                 "\"B14101\",\"Sheets and Plots\",\"1.75\",\"1.75\"", 
                                 "\"B14101\",\"Symbol and Note Update\",\"0.75\",\"0.75\"", 
                                 "\"B14101\",\"Update 3D Model to Match Land Arch/Shanes Markups\",\"5.25\",\"5.25\"", 
                                 "\"T14001\",\"Meeting with Pat\",\"0.25\",\"0.25\"", 
                                 "\"T14001\",\"Staff Meeting\",\"0.25\",\"0.25\"",
                                 "\"T14001\",\"Think Printer Application Setup on Wildcat\",\"0.25\",\"0.25\"",
                                "\"T14001\",\"With Pat regarding Schedule\",\"0.25\",\"0.25\"",
                                "\"Total\",\"\",\"9.00\",\"9.00\""
                             };
            return lines;
        }

        public bool Exists(string file)
        {
            return true;
        }
    }
}
