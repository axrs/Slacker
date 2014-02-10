using System;
using System.Collections.Generic;
using System.Text;

namespace Slacker
{
    class TimeEntry
    {

        private String _jobId;
        private String _description;
        private double _hours = 0.0;
        private DateTime _day;
        
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
                if (value >= 0)
                {
                    _hours = value;
                }
            }
        }
    }
}
