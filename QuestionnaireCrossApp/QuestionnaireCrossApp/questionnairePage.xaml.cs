using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuestionnaireCrossApp
{
	public partial class questionnairePage : ContentPage
	{
        public bool selected = false;
        public BoxView[] boxes = new BoxView[5];
        public Label[] labels = new Label[5];
        public bool[] answerSelected = { false, false, false, false, false };




        public questionnairePage()
        {
            
            //getQuestions();
            var boxA_Tap = new TapGestureRecognizer();
            var boxB_Tap = new TapGestureRecognizer();
            var boxC_Tap = new TapGestureRecognizer();
            var boxD_Tap = new TapGestureRecognizer();
            var boxE_Tap = new TapGestureRecognizer();
            var buttonNext_Tap = new TapGestureRecognizer();



            //answerSelected[0] = false;
            //Title = "Q&A Pos Check";

            var layout = new AbsoluteLayout();


            //Labels
            var questionLabel = new Label { Text = "01.В чьей компетенции находится выдача и продление свидетельств на право управления локомотивом?01.В чьей компетенции находится выдача и продление свидетельств на право управления локомотивом?", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(questionLabel, new Rectangle(0.1, .05, .9, .1));
            AbsoluteLayout.SetLayoutFlags(questionLabel, AbsoluteLayoutFlags.All);

            var answerLabelA = new Label { Text = "Предпринимателя в сфере железнодорожных перевозок", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(answerLabelA, new Rectangle(.1, .25, .9, .1));
            AbsoluteLayout.SetLayoutFlags(answerLabelA, AbsoluteLayoutFlags.All);

            //var border = new BoxView { BackgroundColor = Color.Black };
            //AbsoluteLayout.SetLayoutBounds(boxA, new Rectangle(0, .4, .1, .1));
            //AbsoluteLayout.SetLayoutFlags(boxA, AbsoluteLayoutFlags.All);

            var answerLabelB = new Label { Text = "Депо", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(answerLabelB, new Rectangle(.1, .4, .9, .1));
            AbsoluteLayout.SetLayoutFlags(answerLabelB, AbsoluteLayoutFlags.All);


            var answerLabelC = new Label { Text = "Министерства экономики и коммуникаций", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(answerLabelC, new Rectangle(.1, .55, .9, .1));
            AbsoluteLayout.SetLayoutFlags(answerLabelC, AbsoluteLayoutFlags.All);


            var answerLabelD = new Label { Text = "Департамента технического надзора ", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(answerLabelD, new Rectangle(.1, .7, .9, .1));
            AbsoluteLayout.SetLayoutFlags(answerLabelD, AbsoluteLayoutFlags.All);


            var answerLabelE = new Label { Text = "Какой-либо обслуживающей фирмы", LineBreakMode = LineBreakMode.WordWrap };
            AbsoluteLayout.SetLayoutBounds(answerLabelE, new Rectangle(.1, .85, .9, .1));
            AbsoluteLayout.SetLayoutFlags(answerLabelE, AbsoluteLayoutFlags.All);




            //Boxes
            var backgroundBox = new BoxView { BackgroundColor = Color.DimGray };
            AbsoluteLayout.SetLayoutBounds(backgroundBox, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(backgroundBox, AbsoluteLayoutFlags.All);


            var boxQ = new BoxView { BackgroundColor = Color.Gray};
            AbsoluteLayout.SetLayoutBounds(boxQ, new Rectangle(0, .05, 2, .1));
            AbsoluteLayout.SetLayoutFlags(boxQ, AbsoluteLayoutFlags.All);


            var boxA = new BoxView { BackgroundColor = Color.Gray, HeightRequest = answerLabelA.Height};
            AbsoluteLayout.SetLayoutBounds(boxA, new Rectangle(0, .25, 1, .1));
            AbsoluteLayout.SetLayoutFlags(boxA, AbsoluteLayoutFlags.All);


            var boxB = new BoxView { BackgroundColor = Color.Gray, HeightRequest = answerLabelB.Height };
            AbsoluteLayout.SetLayoutBounds(boxB, new Rectangle(0, .4, 1, .1));
            AbsoluteLayout.SetLayoutFlags(boxB, AbsoluteLayoutFlags.All);


            var boxC = new BoxView { BackgroundColor = Color.Gray, HeightRequest =answerLabelC.Height };
            AbsoluteLayout.SetLayoutBounds(boxC, new Rectangle(0, .55, 1, .1));
            AbsoluteLayout.SetLayoutFlags(boxC, AbsoluteLayoutFlags.All);


            var boxD = new BoxView { BackgroundColor = Color.Gray, HeightRequest = answerLabelD.Height };
            AbsoluteLayout.SetLayoutFlags(boxD, AbsoluteLayoutFlags.All);


            var boxE = new BoxView { BackgroundColor = Color.Gray, HeightRequest = answerLabelE.Height };
            AbsoluteLayout.SetLayoutBounds(boxE, new Rectangle(0, .85, 1, .1));
            AbsoluteLayout.SetLayoutFlags(boxE, AbsoluteLayoutFlags.All);



           




            var nextButton = new Button { Text = "Далее" };
            AbsoluteLayout.SetLayoutBounds(nextButton, new Rectangle(.95, .95, .3, .1));
            AbsoluteLayout.SetLayoutFlags(nextButton, AbsoluteLayoutFlags.All);



            layout.Children.Add(backgroundBox);
            layout.Children.Add(boxQ);
            layout.Children.Add(boxA);
            layout.Children.Add(boxB);
            layout.Children.Add(boxC);
            layout.Children.Add(boxD);
            layout.Children.Add(boxE);
            layout.Children.Add(questionLabel);
            layout.Children.Add(answerLabelA);
            layout.Children.Add(answerLabelB);
            layout.Children.Add(answerLabelC);
            layout.Children.Add(answerLabelD);
            layout.Children.Add(answerLabelE);
            layout.Children.Add(nextButton);
            //layout.Children.Add(border);
            Content = layout;

            //boxes[0] = boxA;
            //boxes[1] = boxB;
            //boxes[2] = boxC;
            //boxes[3] = boxD;
            //boxes[4] = boxE;

            //labels[0] = answerLabelA;
            //labels[1] = answerLabelB;
            //labels[2] = answerLabelC;
            //labels[3] = answerLabelD;
            //labels[4] = answerLabelE;

            //foreach (BoxView element in boxes)
            //{
            //    element.GestureRecognizers.Add(box_Tap);
            //}

            //foreach (Label element in labels)
            //{
            //    element.GestureRecognizers.Add(box_Tap);
            //}
            boxA.GestureRecognizers.Add(boxA_Tap);
            answerLabelA.GestureRecognizers.Add(boxA_Tap);
            boxB.GestureRecognizers.Add(boxB_Tap);
            answerLabelB.GestureRecognizers.Add(boxB_Tap);
            boxC.GestureRecognizers.Add(boxC_Tap);
            answerLabelC.GestureRecognizers.Add(boxC_Tap);
            boxD.GestureRecognizers.Add(boxD_Tap);
            answerLabelD.GestureRecognizers.Add(boxD_Tap);
            boxE.GestureRecognizers.Add(boxE_Tap);
            answerLabelE.GestureRecognizers.Add(boxE_Tap);

            boxA_Tap.Tapped += (s, e) =>
            {
                try
                {
                    if (boxA.Color != Color.LightGray)
                    {
                        boxA.Color = Color.LightGray;
                    }
                    else
                    {
                        boxA.Color = Color.Gray;
                    }

                }
                catch(Exception ex)
                {
                    DisplayAlert("Exception!", ex.ToString(), "Ok");
                }

            };
            boxB_Tap.Tapped += (s, e) =>
            {
                try
                {
                    if (boxB.Color != Color.LightGray)
                    {
                        boxB.Color = Color.LightGray;
                    }
                    else
                    {
                        boxB.Color = Color.Gray;
                    }

                }
                catch (Exception ex)
                {
                    DisplayAlert("Exception!", ex.ToString(), "Ok");
                }

            };
            boxC_Tap.Tapped += (s, e) =>
            {
                try
                {
                    if (boxC.Color != Color.LightGray)
                    {
                        boxC.Color = Color.LightGray;
                    }
                    else
                    {
                        boxC.Color = Color.Gray;
                    }

                }
                catch (Exception ex)
                {
                    DisplayAlert("Exception!", ex.ToString(), "Ok");
                }

            };
            boxD_Tap.Tapped += (s, e) =>
            {
                try
                {
                    if (boxD.Color != Color.LightGray)
                    {
                        boxD.Color = Color.LightGray;
                    }
                    else
                    {
                        boxD.Color = Color.Gray;
                    }

                }
                catch (Exception ex)
                {
                    DisplayAlert("Exception!", ex.ToString(), "Ok");
                }
            };
            boxE_Tap.Tapped += (s, e) =>
            {
                try
                {
                    if (boxE.Color != Color.LightGray)
                    {
                        boxE.Color = Color.LightGray;
                    }
                    else
                    {
                        boxE.Color = Color.Gray;
                    }

                }
                catch (Exception ex)
                {
                    DisplayAlert("Exception!", ex.ToString(), "Ok");
                }

            };

            buttonNext_Tap.Tapped += (s, e) =>
            {

            };

        }
        public void getQuestions()
        {

        }
	}
}
