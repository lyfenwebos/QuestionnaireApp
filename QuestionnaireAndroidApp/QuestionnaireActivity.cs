using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;

namespace QuestionnaireAndroidApp
{
    [Activity(Label = "questionnaireActivity")]
    public class QuestionnaireActivity : Activity
    {
        public string filename;
        public static string[] logfile;
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public List<string> questionsList;
        public ListView qListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.questionnairePage);

            string selected = Intent.GetStringExtra("position") ?? "Data not available";
            fileLoad("questions" + (Convert.ToInt32(selected)+1).ToString()  + ".txt");
        }


        public void fileLoad(string file)
        {
            filename = Path.Combine(path, file);
            System.Threading.Thread.Sleep(1000);
            qListView = FindViewById<ListView>(Resource.Id.qListView);
            questionsList = new List<string>();

            using (StreamReader sr = new StreamReader(filename))
            {
                logfile = File.ReadAllLines(filename);
                for (int z = 0; z <= logfile.Length; z += 6)
                {
                    if (z + 6 != logfile.Length)
                    {
                        questionsList.Add(logfile[z]);
                    }
                    else if (z + 6 == logfile.Length)
                    {
                        questionsList.Add(logfile[z]);
                        break;
                    }

                }

            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, questionsList);
            qListView.Adapter = adapter;
        }
        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}