using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionannaireApp
{
    public partial class License : Form
    {
        public License()
        {
            InitializeComponent();
        }
        public static TextBox[] textBoxes = new TextBox[5];
        public bool licenseStatusOk=false;

        private System.Resources.ResourceManager rm = null;

        private void License_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Properties.Settings.Default.culture);
            rm = new System.Resources.ResourceManager("QuestionannaireApp.Localization", Assembly.GetExecutingAssembly());

            textBoxes[0] = licenseA;
            textBoxes[1] = licenseB;
            textBoxes[2] = licenseC;
            textBoxes[3] = licenseD;
            textBoxes[4] = licenseE;

            textBoxes[0].Focus();
            registerButton.Text = rm.GetString("registerButton");
            cancelButton.Text = rm.GetString("cancelButton");
            foreach (TextBox element in textBoxes)
            {
                element.TextChanged += Element_TextChanged;
            }
            this.FormClosing += License_FormClosing;
        }

        private void License_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (licenseStatusOk == false)
            {
                Properties.Settings.Default.block = true;
            }
        }


        private void Element_TextChanged(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;

            if (textbox.TextLength == 4)
            {
                int index = Array.IndexOf(textBoxes, textbox);
                if (index != textBoxes.Length-1)
                {
                    textBoxes[index + 1].Focus();
                }
                else
                {
                    registerButton.Focus();
                }
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (TextBox element in textBoxes)
            {
                if (element.TextLength == 4)
                {
                    int index = Array.IndexOf(textBoxes, element);
                    if (index != textBoxes.Length - 1)
                    {
                        sb.Append(element.Text + "-");
                    }
                    else
                    {
                        sb.Append(element.Text);
                    }
                }
                else
                {
                    MessageBox.Show(rm.GetString("incompleteKey"));
                    break;
                }
            }

            if (sb.Length == 24)
            {
                LicenseCheck.activateSoftware(sb.ToString());
                licenseStatusOk = true;
                Properties.Settings.Default.block = false;
                this.Close();
            }

            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
