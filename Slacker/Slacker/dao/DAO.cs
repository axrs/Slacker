using System;
using System.Collections.Generic;
using System.Text;

namespace Slacker.dao
{
    abstract class DAO
    {
        public abstract int count();
        public abstract void loadTimes();
        public abstract void saveTimes();

        /// <summary>
        /// Gets a list of Time entries from the DAO
        /// </summary>
        /// <returns>List of TimeEntry</returns>
        public abstract List<TimeEntry> getTimes();
    }
}
