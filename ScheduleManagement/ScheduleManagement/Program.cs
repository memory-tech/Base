using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleManagement
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main f1=new Main();
            Application.Run(f1);
            
            
            
        }
    }
}