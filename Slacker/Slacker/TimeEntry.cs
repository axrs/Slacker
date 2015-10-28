using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Slacker
{
    /// <summary>
    /// Generic representation of a time entry
    /// </summary>
    class TimeEntry
    {
        private static string DEFAULT_TASK_TYPE= "D";
        private static int DEFAULT_EMPLOYEE_ID = 0;
        private string _jobId = string.Empty;
        private string _description = string.Empty;
        private double _hours = 0.0;
        private DateTime _day = DateTime.Today;
        private static double DEFAULT_EMPLOYEE_RATE = 0.0;
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

        public static double Rate
        {
            get
            {
                return DEFAULT_EMPLOYEE_RATE;
            }
            set{
                DEFAULT_EMPLOYEE_RATE = value;
            }
        }

        public TimeEntry()
        {
            if (DEFAULT_EMPLOYEE_ID == 0)
            {
                ISettings _settings = new Settings();
                string empId = _settings.get("TIMES", "EMPLOYEE_ID", "58");
                string task = _settings.get("TIMES", "TASK_KEY", "D");
                string rate = _settings.get("TIMES", "EMPLOYEE_RATE", "120");
                System.Diagnostics.Debug.WriteLine(String.Format("Employee {0} using Task ID {1}",empId,task));
                DEFAULT_TASK_TYPE = task;
                DEFAULT_EMPLOYEE_ID = Convert.ToInt32(empId);
                DEFAULT_EMPLOYEE_RATE = Convert.ToDouble(rate);
            }

        }
        public bool isValid()
        {
            string resultString = null;
            try
            {
                resultString = Regex.Match(_jobId, @"(([a-zA-Z].*?){3}|([a-zA-Z].*?){1})\d{2}(\d{3}|\d{2})", RegexOptions.IgnoreCase).Value;
                if (resultString != "")
                {
                    return true;
                }
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }
            return false;
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
