using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionannaireApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            UpdateManager updateManager = new UpdateManager();
            if (updateManager.CheckConnection() == true)
            {
                updateManager.CheckUpdate();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("We are experiencing some problems with connection right now", "Connection can't be established!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }

        }
    }
}
