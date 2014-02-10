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
        private String _jobId = String.Empty;
        private String _description = String.Empty;
        private double _hours = 0.0;
        private DateTime _day = DateTime.Today;

        public TimeEntry()
        {
        }

        public String description
        {
            get { return _description; }
            set { _description = value; }
        }

        public String jobId
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
