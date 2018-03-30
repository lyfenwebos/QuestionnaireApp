using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.IsolatedStorage;
using System.IO;

namespace QuestionannaireApp
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            string licenseKey=String.Empty;
            if (Properties.Settings.Default.block == false)
            {
                using (IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
                {
                    using (IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream("license.lic", System.IO.FileMode.Open, isolatedStorageFile))
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(isolatedStorageFileStream))
                        {
                            licenseKey = sr.ReadLine();
                        }
                    }
                }
            }
            if (Properties.Settings.Default.culture == "ru-RU")
            {
                if (Properties.Settings.Default.block == true)
                {
                    this.aboutTextBox.Text = "Программа представленна \"Как есть\". Разработчик не несет никакой ответственности.\r\n\r\n" +
                        "По всем вопросам обращаться по почте admin@exordium.cloud\r\n\r\n" +
                        "Разработчик Павел Гончаров." +
                        "\r\nВерсия ПО " + ProductVersion + "\r\n\r\n" +
                        "Тип лицензии - Бесплатная";
                }
                else
                {
                    this.aboutTextBox.Text = "Программа представленна \"Как есть\". Разработчик не несет никакой ответственности.\r\n\r\n" +
                        "По всем вопросам обращаться по почте admin@exordium.cloud\r\n\r\n" +
                        "Разработчик Павел Гончаров." +
                        "\r\nВерсия ПО " + ProductVersion + "\r\n\r\n" +
                        "Тип лицензии - Платная\r\n" +
                        "Ключ - "+licenseKey;
                }
            }
            else if (Properties.Settings.Default.culture == "et-EE")
            {
                if (Properties.Settings.Default.block == true)
                {
                    this.aboutTextBox.Text = "Programm on esitatud \"Mis on\". Arendaja ei vastuta.\r\n\r\n" +
                        "Kõigi küsimuste korral võtke palun ühendust posti teel admin@exordium.cloud\r\n\r\n" +
                        "Arendaja Pavel Gontsarov." +
                        "\r\nTarkvara versioon " + ProductVersion + "\r\n\r\n" +
                        "Litsentsi tüüp - Tasuta";
                }
                else
                {
                    this.aboutTextBox.Text = "Programm on esitatud \"Mis on\". Arendaja ei vastuta.\r\n\r\n" +
                        "Kõigi küsimuste korral võtke palun ühendust posti teel admin@exordium.cloud\r\n\r\n" +
                        "Arendaja Pavel Gontsarov." +
                        "\r\nTarkvara versioon " + ProductVersion + "\r\n\r\n" +
                        "Litsentsi tüüp - Tasuline\r\n" +
                        "Litsentsivõti - "+licenseKey;
                }
            }
            else if (Properties.Settings.Default.culture == "gb-EN")
            {
                if (Properties.Settings.Default.block == true)
                {
                    this.aboutTextBox.Text = "The program is presented \"AS IS\". The developer does not bear any responsibility.\r\n\r\n" +
                        "For all questions please contact by mail admin@exordium.cloud\r\n\r\n" +
                        "Developer Pavel Gontsarov." +
                        "\r\nSoftware Version " + ProductVersion + "\r\n\r\n" +
                        "License type - Free";
                }
                else
                {
                    this.aboutTextBox.Text = "The program is presented \"AS IS\". The developer does not bear any responsibility.\r\n\r\n" +
                        "For all questions please contact by mail admin@exordium.cloud\r\n\r\n" +
                        "Developer Pavel Gontsarov." +
                        "\r\nSoftware Version " + ProductVersion + "\r\n\r\n" +
                        "License type - Paid\r\n" +
                        "License key - "+licenseKey;
                }
            }
            else
            {
                if (Properties.Settings.Default.block == true)
                {
                    this.aboutTextBox.Text = "The program is presented \"AS IS\". The developer does not bear any responsibility.\r\n\r\n" +
                        "For all questions please contact by mail admin@exordium.cloud\r\n\r\n" +
                        "Developer Pavel Gontsarov." +
                        "\r\nSoftware Version " + ProductVersion + "\r\n\r\n" +
                        "License type - Free";
                }
                else
                {
                    this.aboutTextBox.Text = "The program is presented \"AS IS\". The developer does not bear any responsibility.\r\n\r\n" +
                        "For all questions please contact by mail admin@exordium.cloud\r\n\r\n" +
                        "Developer Pavel Gontsarov." +
                        "\r\nSoftware Version " + ProductVersion + "\r\n\r\n" +
                        "License type - Paid\r\n" +
                        "License key - " + licenseKey;
                }
            }
        }
    }
}
    

