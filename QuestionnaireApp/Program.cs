using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Resources;
using System.IO.IsolatedStorage;
using System.Net;
using System.Reflection;

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

            System.Resources.ResourceManager rm = null;
            rm = new System.Resources.ResourceManager("QuestionannaireApp.Localization", Assembly.GetExecutingAssembly());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Properties.Settings.Default.culture);
            ProgressBox progressBox = new ProgressBox();
            License license = new License();
            progressBox.Show();
            checkLicenseFile();
            string setupPath = Path.GetTempPath() + "questionnaireAppSetup.msi";

            if (File.Exists(setupPath))
            {
                File.Delete(setupPath);
            }
            UpdateManager updateManager = new UpdateManager();
            if (updateManager.CheckConnection() == true)
            {
                if (updateManager.CheckUpdate() == true)
                {
                    Process.Start(setupPath);
                    Environment.Exit(0);
                }
                else
                {
                    progressBox.Close();
                    Application.Run(new MainForm());
                }

            }
            else
            {
                MessageBox.Show(rm.GetString("serverUnreachable"), rm.GetString("cantEstablish"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                progressBox.Close();
                Application.Run(new MainForm());
            }
        }
        public static void checkLicenseFile()
        {
            System.Resources.ResourceManager rm = null;
            rm = new System.Resources.ResourceManager("QuestionannaireApp.Localization", Assembly.GetExecutingAssembly());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Properties.Settings.Default.culture);

            using (IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {
                try
                {
                    using (IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream("license.lic", System.IO.FileMode.Open, isolatedStorageFile))
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(isolatedStorageFileStream))
                        {
                            var activated = LicenseCheck.isActivated(sr.ReadLine());
                            if (!activated)
                            {
                                MessageBox.Show(rm.GetString("activationExpired"), rm.GetString("activation"), MessageBoxButtons.OK);
                                Properties.Settings.Default.block = true;
                            }
                            else
                            {
                                Properties.Settings.Default.block = false;
                            }

                        }
                    }
                }

                catch
                {
                    if (CheckForInternetConnection() == true && !isolatedStorageFile.FileExists("license.lic"))
                    {
                        License license = new License();
                        license.ShowDialog();
                    }
                    else if (CheckForInternetConnection() == false && !isolatedStorageFile.FileExists("license.lic"))
                    {
                        Properties.Settings.Default.block = true;
                    }
                    else
                    {
                        Properties.Settings.Default.block = false;
                    }

                }
            }
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
