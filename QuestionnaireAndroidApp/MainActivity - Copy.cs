//using Android.App;
//using Android.Widget;
//using Android.OS;
//using System.IO;
//using System.Collections.Generic;
//using Android.Content.Res;
//using System;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using Android.Content;

//namespace QuestionnaireAndroidApp
//{
//    [Activity(Label = "QuestionnaireAndroidApp", MainLauncher = true)]
//     class MainActivity : Activity
//    {
//        public ListView mainListView;
//        public List<string> items;
//        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);



//        protected override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);
//            Download("questions1.txt");
//            Download("questions2.txt");
//            Download("questions3.txt");
//            Download("questions4.txt");
//            Toast.MakeText(this, "Downloaded!", ToastLength.Short).Show();

//            // Set our view from the "main" layout resource
//            SetContentView(Resource.Layout.Main);

//            mainListView = FindViewById<ListView>(Resource.Id.mainListView);
//            items = new List<string>();
//            items.Add("Модуль 1");
//            items.Add("Модуль 2");
//            items.Add("Модуль 3");
//            items.Add("Модуль 4");
//            items.Add("Экзамен");
//            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
//            mainListView.Adapter = adapter;
//            mainListView.ItemClick += MainListView_ItemClick;

//            //Download();
//            //fileLoad();
//        }

//        public void MainListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
//        {
//            //switch (e.Position)
//            //{
//            //    case 0:
//            //        fileLoad("questions1.txt");
//            //        StartActivity(typeof(QuestionnaireActivity));
//            //        break;
//            //    case 1:
//            //        fileLoad("questions2.txt");
//            //        StartActivity(typeof(QuestionnaireActivity));
//            //        break;
//            //    case 2:
//            //        fileLoad("questions3.txt");
//            //        StartActivity(typeof(QuestionnaireActivity));
//            //        break;
//            //    case 3:
//            //        fileLoad("questions4.txt");
//            //        StartActivity(typeof(QuestionnaireActivity));
//            //        break;
//            //    case 4:
//            //        StartActivity(typeof(QuestionnaireActivity));
//            //        break;
//            //}
//            //QuestionnaireActivity secondActivity = new QuestionnaireActivity();
//            //Task.Run(() => secondActivity.fileLoad("questions" + (e.Position + 1) + ".txt"));
//            //secondActivity.fileLoad("questions" + (e.Position + 1) + ".txt");
//            if (e.Position != 4)
//            {
//                var secondActivity = new Intent(this, typeof(QuestionnaireActivity));
//                secondActivity.PutExtra("position", e.Position.ToString());
//                StartActivity(secondActivity);
//            }
//            else
//            {
//                StartActivity(typeof(QuestionnaireActivity));
//            }

//        }

//        public void Download(string file)
//        {
//            var webClient = new WebClient();
//            webClient.DownloadStringCompleted += (s, e) =>
//            {
//                var text = e.Result; // get the downloaded text
//                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
//                string localFilename = file;
//                string localPath = Path.Combine(documentsPath, localFilename);
//                File.WriteAllText(localPath, text); // writes to local storage

//            };


//            var url = new Uri("https://github.com/lyfenwebos/QuestionnaireApp/blob/master/QuestionnaireApp/bin/Release/" + file + "?raw=true"); // Html page
//            webClient.Encoding = Encoding.UTF8;

//            webClient.DownloadStringAsync(url);
            
//        }
        

//    }
//}

