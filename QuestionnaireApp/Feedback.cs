using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
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


            MailAddress from = new MailAddress("noreply@gmail.com", "QuestionnaireApp");
            MailAddress to = new MailAddress("admin@gmail.com", "Pavel Goncharov");
            List<MailAddress> cc = new List<MailAddress>();

            string Text = textBox3.Text;
            SmtpClient mailClient = new SmtpClient("mail.privateemail.com ", 465);
            mailClient.EnableSsl = true;
            MailMessage msgMail;
            msgMail = new MailMessage();
            msgMail.From = from;
            msgMail.To.Add(to);
            foreach (MailAddress addr in cc)
            {
                msgMail.CC.Add(addr);
            }
            msgMail.Subject = textBox1.Text + ", " + textBox2.Text;
            msgMail.Body = Text;
            msgMail.IsBodyHtml = true;
            mailClient.Send(msgMail);
            msgMail.Dispose();
        }
    }
}
