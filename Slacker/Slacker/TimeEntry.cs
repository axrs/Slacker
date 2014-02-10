using System;
using System.Collections.Generic;
using System.Text;

namespace Slacker
{
    /// <summary>
    /// Generic representation of a time entry
    /// </summary>
    class TimeEntry
    {
        private string _jobId = string.Empty;
        private string _description = string.Empty;
        private double _hours = 0.0;
        private DateTime _day = DateTime.Today;

        public TimeEntry()
        {
        }

        public override string ToString()
        {
            return string.Format("{3} {0} | {1} | {2}", _jobId, _hours, _description, _day);
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string jobId
        {
            get { return _jobId; }
            set { _jobId = value; }
        }

        public DateTime day
        {
            get { return _day; }
            set { _day = value; }
        }

        public double hours
        {
            get { return _hours; }
            set
            {
                if (value >= 0 && value <= 24)
                {
                    _hours = value;
                }
                else
                {
                    _hours = 0;
                }
            }
        }
    }
}
