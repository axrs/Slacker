using System;
using System.Collections.Generic;
using System.Text;

namespace Slacker.Commands
{
    /// <summary>
    /// Command Pattern Interface
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// Command Interface
        /// </summary>
        bool execute();
    }
}
