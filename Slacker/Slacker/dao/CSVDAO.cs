using System;
using System.Collections.Generic;
using System.IO;
using Slacker.commands;

namespace Slacker.dao
{
    class CSVDAO : DAO, ICommand
    {
        private string _filePath = string.Empty;

        private bool _hasValidFilePath = false;
        private List<TimeEntry> _times = new List<TimeEntry>();

        private DateTime _entryDate = DateTime.Now;

        public CSVDAO(String filePath)
        {
            _filePath = filePath;
            _hasValidFilePath = File.Exists(_filePath);
        }

        /// <summary>
        /// Executes the CSV DAO Process to read the file
        /// </summary>
        /// <returns>True if run on a valid file</returns>
        public override bool execute()
        {
            bool hasRun = false;

            if (_hasValidFilePath)
            {
                loadTimes();

                hasRun = true;
            }
            return hasRun;
        }

        /// <summary>
        /// Processes the first line of the file to determine the entry dates
        /// </summary>
        /// <param name="line"></param>
        private void processFirstLine(String line)
        {
            string result = line.Split(',')[2].Trim('"');
            this._entryDate = Convert.ToDateTime(result);
        }

        /// <summary>
        /// Processes the entry lines reading the time spent and hours
        /// </summary>
        /// <param name="line"></param>
        private void processEntry(String line)
        {
            string[] fields = line.Split(',');

            TimeEntry entry = new TimeEntry();
            entry.day = _entryDate;
            entry.jobId = fields[0].Trim('"');
            entry.description = fields[1].Trim('"');
            entry.hours = Convert.ToDouble(fields[2].Trim('"'));
            _times.Add(entry);
        }

        /// <summary>
        /// Gets a list of TimeEntry's found within the CSV file
        /// </summary>
        /// <returns></returns>
        public override List<TimeEntry> getTimes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the total number of entries found
        /// </summary>
        /// <returns></returns>
        public override int count()
        {
            return _times.Count;
        }

        /// <summary>
        /// Reads the entries from the CSV
        /// </summary>
        public override void loadTimes()
        {
            string[] lines = File.ReadAllLines(_filePath);
            processFirstLine(lines[0]);

            //process the second to second last lines
            for (int i = 1; i < lines.Length - 1; i++)
            {
                processEntry(lines[i]);
            }
        }
        /// <summary>
        /// Saves the files to the CSV (Not Implemented)
        /// </summary>
        public override void saveTimes()
        {
            throw new NotImplementedException();
        }
    }
}
