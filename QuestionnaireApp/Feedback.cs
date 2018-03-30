using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionannaireApp
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            MailAddress from = new MailAddress("feedback@exordium.cloud", "Feedback System");
            MailAddress to = new MailAddress("lyfenwebos@exordium.cloud", "Pavel Goncharov");
 
            string Text = msgBox.Text;
            SmtpClient mailClient = new SmtpClient("mail.exordium.cloud", 25);
            mailClient.EnableSsl = true;
            MailMessage msgMail;
            msgMail = new MailMessage();
            msgMail.From = from;
            msgMail.To.Add(to);
            msgMail.Subject = nameBox.Text + ", " + emailBox.Text;
            msgMail.Body = Text;
            msgMail.IsBodyHtml = true;
            ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate,
             X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
            if (nameBox.Text!=String.Empty)
            {
                nameBox.BackColor = Color.WhiteSmoke;
                if (emailBox.Text != String.Empty && emailBox.Text.Contains('@'))
                {
                    emailBox.BackColor = Color.WhiteSmoke;
                    if (msgBox.Text != String.Empty)
                    {
                        msgBox.BackColor = Color.WhiteSmoke;
                        mailClient.Send(msgMail);
                        msgMail.Dispose();
                        this.Close();
                    }
                    else
                    {
                        msgBox.BackColor = Color.Red;
                    }
                }
                else
                {
                    emailBox.BackColor = Color.Red;
                }
            }
            else
            {
                nameBox.BackColor = Color.Red;
            }
        }
    }
}
