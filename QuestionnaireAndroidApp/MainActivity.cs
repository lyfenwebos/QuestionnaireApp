using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Collections.Generic;
using Android.Content.Res;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Views;

namespace QuestionnaireAndroidApp
{
    [Activity(Label = "QuestionnaireAndroidApp", MainLauncher = true)]
     class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SlidingTabsFragment fragment = new SlidingTabsFragment();
            transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            transaction.Commit();
        }

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
        //    return base.OnCreateOptionsMenu(menu);
        //}


    }
}

