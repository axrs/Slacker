using System;
using System.Collections.Generic;
using System.IO;
using Slacker.Commands;
using Slacker;
using Slacker.Native;
using Microsoft.VisualBasic.FileIO;

namespace Slacker.DAO
{
    class CSVDAO : AbstractDAO, ICommand
    {
        private List<TimeEntry> _times = new List<TimeEntry>();
        private string _filePath = string.Empty;

        private IFileHandler _handler;

        public CSVDAO(string file)
        {
            FileHandler = new WindowsFileHandler();

            this.file = file;
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
            }
        }

        public IFileHandler FileHandler
        {
            get
            {
                return _handler;
            }
            set
            {
                _handler = value;
            }
        }

        /// <summary>
        /// Processes the first line of the file to determine the entry dates
        /// </summary>
        /// <param name="line"></param>
        private DateTime processFirstLine(String line)
        {
            string result = line.Split(',')[2].Trim('"');
            return Convert.ToDateTime(result);
        }

        private DateTime processFirstLine(string[] fields)
        {
            return Convert.ToDateTime(fields[2]);
        }
        /// <summary>
        /// Processes the entry lines reading the time spent and hours
        /// </summary>
        /// <param name="line"></param>
        private TimeEntry processEntry(String line)
        {
            string[] fields = line.Split(',');

            TimeEntry entry = new TimeEntry();
            entry.jobId = fields[0].Trim('"');
            entry.description = fields[1].Trim('"');
            entry.day = Convert.ToDateTime(fields[2].Trim('"'));
            int fieldLength = fields.Length;
            entry.hours = Convert.ToDouble(fields[fieldLength-1].Trim('"'));
            return entry;
        }


        private TimeEntry processEntry(string[] fields)
        {
            TimeEntry entry = new TimeEntry();
            entry.jobId = fields[0].Trim('"');
            entry.description = fields[1].Trim('"');
            entry.day = Convert.ToDateTime(fields[2].Trim('"'));
            int fieldLength = fields.Length;
            entry.hours = Convert.ToDouble(fields[fieldLength-1].Trim('"'));
            return entry;
        }

        /// <summary>
        /// Gets a list of TimeEntry's found within the CSV file
        /// </summary>
        /// <returns></returns>
        public override List<TimeEntry> getTimes()
        {
            return _times;
        }

        new public int count
        {
            get { return _times.Count; }
        }

        /// <summary>
        /// Reads the entries from the CSV
        /// </summary>
        public override void loadTimes()
        {
            string[] lines = FileHandler.ReadAllLines(file);

            //process the second to second last lines
            for (int i = 1; i < lines.Length - 1; i++)
            {
                using (TextFieldParser parser = new TextFieldParser(new System.IO.StringReader(lines[i])))
                {
                    parser.SetDelimiters(new string[] { "," });
                    parser.HasFieldsEnclosedInQuotes = true;
                    string[] fields = parser.ReadFields();
                    if (fields != null)
                    {
                        _times.Add(processEntry(fields));
                    }
                }
            }
        }
        /// <summary>
        /// Saves the files to the CSV (Not Implemented)
        /// </summary>
        public override void saveTimes()
        {
            throw new NotImplementedException();
        }

        public bool execute()
        {
            bool hasRun = false;
            if (file != string.Empty && FileHandler.Exists(file))
            {
                loadTimes();
                hasRun = true;
            }
            return hasRun;
        }
    }
}
