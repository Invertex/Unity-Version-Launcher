using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
namespace Invertex.UnityVersionLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                string[] argSplit = args[0].Split('^');
                if (argSplit.Length > 1 && argSplit[1] == "del")
                {
                    MainWindow.RemoveKey(argSplit[0]);
                    Application.ExitThread();
                    Application.Exit();
                    return;
                }
            }
  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
