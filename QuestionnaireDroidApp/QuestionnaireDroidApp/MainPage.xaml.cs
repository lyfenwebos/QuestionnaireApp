using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuestionnaireDroidApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            Title = "Q&A Pos Check";
            var layout = new AbsoluteLayout();

            var questionBox = new Label { Text = "Question", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(questionBox, new Rectangle(.5, 0.9, .5, .1));
            AbsoluteLayout.SetLayoutFlags(questionBox, AbsoluteLayoutFlags.All);

            var answerBoxA = new Label { Text = "Answer A", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(answerBoxA, new Rectangle(0, 0.7, .5, .1));
            AbsoluteLayout.SetLayoutFlags(answerBoxA, AbsoluteLayoutFlags.All);


            var answerBoxB = new Label { Text = "Answer B", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(answerBoxB, new Rectangle(0, 0.6, .5, .1));
            AbsoluteLayout.SetLayoutFlags(answerBoxB, AbsoluteLayoutFlags.All);

            var answerBoxC = new Label { Text = "Answer C", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(answerBoxC, new Rectangle(0, 0.5, .5, .1));
            AbsoluteLayout.SetLayoutFlags(answerBoxC, AbsoluteLayoutFlags.All);

            var answerBoxD = new Label { Text = "Answer D", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(answerBoxD, new Rectangle(0, 0.4, .5, .1));
            AbsoluteLayout.SetLayoutFlags(answerBoxD, AbsoluteLayoutFlags.All);

            var answerBoxE = new Label { Text = "Answer E", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(answerBoxE, new Rectangle(0, 0.3, .5, .1));
            AbsoluteLayout.SetLayoutFlags(answerBoxE, AbsoluteLayoutFlags.All); 


            layout.Children.Add(questionBox);
            layout.Children.Add(answerBoxA);
            layout.Children.Add(answerBoxB);
            layout.Children.Add(answerBoxC);
            layout.Children.Add(answerBoxD);
            layout.Children.Add(answerBoxE);

            Content = layout;
        }
	}
}
