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

        private static string DEFAULT_TASK_TYPE= "D";
        private static int DEFAULT_EMPLOYEE_ID = 58;
        private string _jobId = string.Empty;
        private string _description = string.Empty;
        private double _hours = 0.0;
        private DateTime _day = DateTime.Today;

        public static string DefaultTaskType
        {
            get
            {
                return DEFAULT_TASK_TYPE;
            }
            set
            {
                DEFAULT_TASK_TYPE = value;
            }
        }

        public static int Employee
        {
            get
            {
                return DEFAULT_EMPLOYEE_ID;
            }
            set
            {
                DEFAULT_EMPLOYEE_ID = value;
            }
        }

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
