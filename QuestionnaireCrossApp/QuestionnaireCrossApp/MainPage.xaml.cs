using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SimpleCustomGesureFrame;
using SimpleCustomGesureFrame.ViewModels;

namespace QuestionnaireCrossApp
{
	public partial class MainPage : ContentPage
	{
        public bool selected=false;



        private MainViewModel ViewModel
        {
            get { return BindingContext as MainViewModel; }
        }


        public MainPage()
		{



            InitializeComponent();

            Title = "Q&A Pos Check";

            var layout = new AbsoluteLayout();

            BindingContext = new MainViewModel();
            GestureFrame gi = new GestureFrame
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("bf3122"),
            };
            gi.SwipeRight += (s, e) =>
            {
                DisplayAlert("Gesture Info", "Swipe Right Detected", "OK");
                ViewModel.SampleCommand.Execute("Swipe Right Detected");

                //answerBoxA.Text = "другой ответ, кек";
            };

            var boxQ = new BoxView { BackgroundColor = Color.Gray };
            AbsoluteLayout.SetLayoutBounds(boxQ, new Rectangle(0, 0.05, 2, .1));
            AbsoluteLayout.SetLayoutFlags(boxQ, AbsoluteLayoutFlags.All);


            var questionBox = new Label { Text = "01.В чьей компетенции находится выдача и продление свидетельств на право управления локомотивом?", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(questionBox, new Rectangle(0.1, 0.05, 0.9, .1));
            AbsoluteLayout.SetLayoutFlags(questionBox, AbsoluteLayoutFlags.All);



            var boxA = new BoxView { BackgroundColor = Color.Gray};
            AbsoluteLayout.SetLayoutBounds(boxA, new Rectangle(0, .3, 1,.1));
            AbsoluteLayout.SetLayoutFlags(boxA, AbsoluteLayoutFlags.All);

            var answerBoxA = new Label { Text = "Предпринимателя в сфере железнодорожных перевозок", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(answerBoxA, new Rectangle(0.1, .3, 0.9, .1));
            AbsoluteLayout.SetLayoutFlags(answerBoxA, AbsoluteLayoutFlags.All);

            this.Content = gi;


            //var boxB = new BoxView { BackgroundColor = Color.Gray };
            //AbsoluteLayout.SetLayoutBounds(boxB, new Rectangle(0, 0.45, 2, .1));
            //AbsoluteLayout.SetLayoutFlags(boxB, AbsoluteLayoutFlags.All);

            //var answerBoxB = new Label { Text = "Answer B", LineBreakMode = LineBreakMode.WordWrap };
            //AbsoluteLayout.SetLayoutBounds(answerBoxB, new Rectangle(0.1, 0.5, .5, .1));
            //AbsoluteLayout.SetLayoutFlags(answerBoxB, AbsoluteLayoutFlags.All);


            //var boxC = new BoxView { BackgroundColor = Color.Gray };
            //AbsoluteLayout.SetLayoutBounds(boxC, new Rectangle(0, 0.55, 2, .1));
            //AbsoluteLayout.SetLayoutFlags(boxC, AbsoluteLayoutFlags.All);

            //var answerBoxC = new Label { Text = "Answer C", LineBreakMode = LineBreakMode.WordWrap };
            //AbsoluteLayout.SetLayoutBounds(answerBoxC, new Rectangle(0.1, 0.6, .5, .1));
            //AbsoluteLayout.SetLayoutFlags(answerBoxC, AbsoluteLayoutFlags.All);

            //var boxD = new BoxView { BackgroundColor = Color.Gray };
            //AbsoluteLayout.SetLayoutBounds(boxD, new Rectangle(0, 0.65, 2, .1));
            //AbsoluteLayout.SetLayoutFlags(boxD, AbsoluteLayoutFlags.All);

            //var answerBoxD = new Label { Text = "Answer D", LineBreakMode = LineBreakMode.WordWrap };
            //AbsoluteLayout.SetLayoutBounds(answerBoxD, new Rectangle(0.1, 0.7, .5, .1));
            //AbsoluteLayout.SetLayoutFlags(answerBoxD, AbsoluteLayoutFlags.All);


            //var boxE = new BoxView { BackgroundColor = Color.Gray };
            //AbsoluteLayout.SetLayoutBounds(boxE, new Rectangle(0, 0.75, 2, .1));
            //AbsoluteLayout.SetLayoutFlags(boxE, AbsoluteLayoutFlags.All);

            //var answerBoxE = new Label { Text = "Answer E", LineBreakMode = LineBreakMode.WordWrap };
            //AbsoluteLayout.SetLayoutBounds(answerBoxE, new Rectangle(0.1, 0.8, .5, .1));
            //AbsoluteLayout.SetLayoutFlags(answerBoxE, AbsoluteLayoutFlags.All);

            layout.Children.Add(boxQ);
            layout.Children.Add(boxA);
            //layout.Children.Add(boxB);
            //layout.Children.Add(boxC);
            //layout.Children.Add(boxD);
            //layout.Children.Add(boxE);
            layout.Children.Add(questionBox);
            layout.Children.Add(answerBoxA);
            //layout.Children.Add(answerBoxB);
            //layout.Children.Add(answerBoxC);
            //layout.Children.Add(answerBoxD);
            //layout.Children.Add(answerBoxE);

            Content = layout;


            var boxA_Tap = new TapGestureRecognizer();
            boxA_Tap.Tapped += (s, e) =>
            {
                //DisplayAlert("Tapped!", "That's working o.o", "Ok");
                if (selected == false)
                {
                    boxA.Color = Color.LightGray;
                    
                    selected = true;
                }

                else
                {
                    boxA.Color = Color.Gray;
                    selected = false;
                }

            };

            boxA.GestureRecognizers.Add(boxA_Tap);
            answerBoxA.GestureRecognizers.Add(boxA_Tap);
        }
	}
}
