using System;
using System.Collections.Generic;
using System.Text;

namespace Slacker
{
    interface IStorage
    {
        void initialise();
        bool isReady();
        void insert(List<TimeEntry> times);
    }
}
