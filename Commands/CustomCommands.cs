using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace LevelEditor.Commands
{
    /// <summary>
    /// Describes Custom commands used in the LevelEditor
    /// </summary>
    public static class CustomCommands
    {
        /// <summary>
        /// About Command is intended to open the AboutWindow
        /// </summary>
        public static readonly RoutedUICommand About = new RoutedUICommand("About", "About", typeof(CustomCommands));
        public static readonly RoutedUICommand ClearMap = new RoutedUICommand("Clear Map", "ClearMap", typeof(CustomCommands));

    }
}
