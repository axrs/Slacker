using System;
using System.Collections.Generic;
using System.Text;

namespace Slacker
{
    /// <summary>
    /// Command Pattern Interface
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// Command Interface
        /// </summary>
        void execute();
    }
}
