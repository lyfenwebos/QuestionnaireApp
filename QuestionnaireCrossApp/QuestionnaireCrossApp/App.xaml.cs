using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace QuestionnaireCrossApp
{
	public partial class App : Application
	{

        public App ()
        { 
			InitializeComponent();

            var mainPage = new FirstPage();//this could be content page
            var rootPage = new NavigationPage(mainPage);

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
            // Handle when your app resumes
        }
	}
}
