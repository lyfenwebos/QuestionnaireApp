using System;
using System.Collections.Generic;
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
        public void CheckUpdate()
        {
            XmlDocument VersionInfo = new XmlDocument();
            VersionInfo.LoadXml(GetWebPage("http://46.16.119.202/update/update.xml"));
            

            if (VersionInfo.SelectSingleNode("//latestversion").InnerText != Application.ProductVersion)
            {
                var files = VersionInfo.DocumentElement.SelectNodes("//updatedfile");
                DialogResult result =  MessageBox.Show("New Version:  " + (VersionInfo.SelectSingleNode("//latestversion").InnerText), "New Version is available!",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    using (var client = new WebClient())
                    {
                        foreach (XmlNode element in files)
                        {
                            client.DownloadFile("http://46.16.119.202/update/" + element.InnerText, element.InnerText);
                        }

                    }
                }
            }

            //textDescription.Text = VersionInfo.SelectSingleNode("//description").InnerText;

        }
        public bool CheckConnection()
        {
            WebRequest request = WebRequest.Create("http://46.16.119.202");
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response == null || response.StatusCode != HttpStatusCode.OK)
                {
                    response.Close();
                    return false;
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.Close();
                    return true;
                }
            }
            catch (WebException)
            {
                return false;
            }
            return false;
        }

    }

}

