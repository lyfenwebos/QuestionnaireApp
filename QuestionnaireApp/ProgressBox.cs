using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionannaireApp
{
    public partial class ProgressBox : Form
    {
        //public static ResourceManager rm = new ResourceManager("QuestionannaireApp.Resources.ru", Assembly.GetExecutingAssembly());
        //BackgroundWorker worker;
        public ProgressBox()
        {
            InitializeComponent();
        }

        private void ProgressBox_Load(object sender, EventArgs e)
        {
            //startUpLabel.Text = rm.GetString("startup");
        }
    }
}
