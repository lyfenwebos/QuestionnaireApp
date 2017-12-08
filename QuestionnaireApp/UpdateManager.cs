using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace QuestionannaireApp
{
    public class UpdateManager
    {
        System.Resources.ResourceManager rm = null;
        public string address = "http://46.101.148.248/";
        public static string GetWebPage(string URL)
        {
            HttpWebRequest Request = (HttpWebRequest)(WebRequest.Create(new Uri(URL)));
            Request.Method = "GET";
            Request.MaximumAutomaticRedirections = 4;
            Request.MaximumResponseHeadersLength = 4;
            Request.ContentLength = 0;

            StreamReader ReadStream = null;
            HttpWebResponse Response = null;
            string ResponseText = string.Empty;

            try
            {
                Response = (HttpWebResponse)(Request.GetResponse());
                Stream ReceiveStream = Response.GetResponseStream();
                ReadStream = new StreamReader(ReceiveStream, System.Text.Encoding.UTF8);
                ResponseText = ReadStream.ReadToEnd();
                Response.Close();
                ReadStream.Close();

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return ResponseText;
        }
        public bool CheckUpdate()
        {
            rm = new System.Resources.ResourceManager("QuestionannaireApp.Localization", Assembly.GetExecutingAssembly());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Properties.Settings.Default.culture);
            XmlDocument VersionInfo = new XmlDocument();
            VersionInfo.LoadXml(GetWebPage(address+"update/update.xml"));

            if (VersionInfo.SelectSingleNode("//latestversion").InnerText != Application.ProductVersion)
            {
                var files = VersionInfo.DocumentElement.SelectNodes("//updatedfile");
                DialogResult result = MessageBox.Show(rm.GetString("newVersionAvailable"), rm.GetString("newVersion"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    using (var client = new WebClient())
                    {
                        foreach (XmlNode element in files)
                        {
                            client.DownloadFile(address+"update/" + element.InnerText, element.InnerText);
                            System.Threading.Thread.Sleep(50);

                        }

                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

            //textDescription.Text = VersionInfo.SelectSingleNode("//description").InnerText;

        }
        public bool CheckConnection()
        {

            WebRequest request = WebRequest.Create(address);
                try
                {

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response == null || response.StatusCode != HttpStatusCode.OK)
                    {
                    System.Threading.Thread.Sleep(500);
                    response.Close();
                        return false;
                    }
                    else if (response.StatusCode == HttpStatusCode.OK)
                    {
                    System.Threading.Thread.Sleep(50);
                    response.Close();
                        return true;
                    }
                }
                catch (WebException)
                {
                System.Threading.Thread.Sleep(500);
                return false;
                }

                return false;
            
        }
        //public void CheckForCorrupted()
        //{
        //    //string location = AppDomain.CurrentDomain.BaseDirectory;
        //    string[] files = {"questions1.txt", "questions2.txt", "questions3.txt", "questions4.txt" };
        //    foreach (string element in files)
        //    {
        //        if (!File.Exists(element))
        //        {
        //            using (var client = new WebClient())
        //            {
        //                client.DownloadFile(address+"update/" + element, element);
        //                System.Threading.Thread.Sleep(50);
        //            }
        //        }
        //    }

        //}
    }
}




