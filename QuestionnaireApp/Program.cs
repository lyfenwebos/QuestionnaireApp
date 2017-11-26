using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Resources;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

          //  System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            ProgressBox progressBox = new ProgressBox();
            progressBox.Show();
            System.Threading.Thread.Sleep(2000);


            UpdateManager updateManager = new UpdateManager();
            if (updateManager.CheckConnection() == true)
            {
                if (updateManager.CheckUpdate() == true)
                {
                    Process.Start("Questionnaire App.exe");
                    Environment.Exit(0);
                }
                else
                {
                    progressBox.Close();
                    updateManager.CheckForCorrupted();
                    Application.Run(new MainForm());
                }

            }
            else
            {
                MessageBox.Show("We are experiencing some problems with connection right now", "Connection can't be established!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                progressBox.Close();
                Application.Run(new MainForm());
            }
        }
    }
}
