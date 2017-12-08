using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace QuestionannaireApp
{
    public partial class MainForm : Form
    {


        public string filename = "";
        public string correctAnswer = "";
        //public string locationEXE = AppDomain.CurrentDomain.BaseDirectory;
        public string path = AppDomain.CurrentDomain.BaseDirectory + "Questions//";
        public string estLanguage = "EST//";
        public string rusLanguage = "RUS//";
        public string culture = string.Empty;


        public int position = 0;
        public int correctAnswers = 0;
        public int count = 0;
        public int index;
        public int indexChecked;
        public int qAmount = 0;
        public int qPosition = 1;
        public int oPosition;
        public int corrAnsIndex;
        public int wrongAnsIndex;


        public bool answerA;
        public bool answerB;
        public bool answerC;
        public bool answerD;
        public bool answerE;
        public bool correct;
        public bool exam;
        public bool block=true;

        public static string[] logfile;
        public TextBox[] textBoxes = new TextBox[5];
        public CheckBox[] checkBoxes = new CheckBox[5];
        public bool[] answerArray = new bool[5];
        public string[] answeredQuestuins = new string[10];
        public string[] questionsRus = new string[4];
        public string[] questionsEst = new string[4];
        public string[] examCorrectQuestions = new string[20];
        public string[] examWrongQuestions = new string[20];
        public int[] corrIndexes = new int[20];

        private System.Resources.ResourceManager rm = null;

        public MainForm()
        {
            InitializeComponent();
        }
        private void UpdateUIControls()
        {
            try
            {
                if (rm != null)
                {
                    backButton.Text = rm.GetString("backButton");
                    examTS.Text = rm.GetString("examTS");
                    feedbackButton.Text = rm.GetString("feedbackButton");
                    finishButton.Text = rm.GetString("finishButton");
                    modul1TS.Text = rm.GetString("modul1TS");
                    modul2TS.Text = rm.GetString("modul2TS");
                    modul3TS.Text = rm.GetString("modul3TS");
                    modul4TS.Text = rm.GetString("modul4TS");
                    modulTS.Text = rm.GetString("modulTS");
                    nextButton.Text = rm.GetString("nextButton");
                    randomCheckBox.Text = rm.GetString("randomCheckBox");
                    verifyButton.Text = rm.GetString("verifyButton");
                    languageTS.Text = rm.GetString("languageTS");
                    settingsTS.Text = rm.GetString("settingsTS");
                    fontTS.Text = rm.GetString("fontTS");
                    aboutTS.Text = rm.GetString("aboutTS");
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {

            textBoxes[0] = answerBoxA;
            textBoxes[1] = answerBoxB;
            textBoxes[2] = answerBoxC;
            textBoxes[3] = answerBoxD;
            textBoxes[4] = answerBoxE;

            checkBoxes[0] = checkBox1;
            checkBoxes[1] = checkBox2;
            checkBoxes[2] = checkBox3;
            checkBoxes[3] = checkBox4;
            checkBoxes[4] = checkBox5;

            answerArray[0] = answerA;
            answerArray[1] = answerB;
            answerArray[2] = answerC;
            answerArray[3] = answerD;
            answerArray[4] = answerE;

            questionsRus[0] = path + rusLanguage + "rusModul1.txt";
            questionsRus[1] = path + rusLanguage + "rusModul2.txt";
            questionsRus[2] = path + rusLanguage + "rusModul3.txt";
            questionsRus[3] = path + rusLanguage + "rusModul4.txt";

            questionsEst[0] = path + estLanguage + "estModul1.txt";
            questionsEst[1] = path + estLanguage + "estModul2.txt";
            questionsEst[2] = path + estLanguage + "estModul3.txt";
            questionsEst[3] = path + estLanguage + "estModul4.txt";


            rm = new System.Resources.ResourceManager("QuestionannaireApp.Localization", Assembly.GetExecutingAssembly());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Properties.Settings.Default.culture);
            UpdateUIControls();
            UpdateFont(Properties.Settings.Default.fontName, Properties.Settings.Default.fontSize);
            if (Properties.Settings.Default.block == true)
            {
                examTS.Enabled = false;
            }
            else
            {
                examTS.Enabled = true;
            }
        }
        public void UpdateFont(string font,float size)
        {
            foreach(TextBox element in textBoxes)
            {
                element.Font = new Font(font, size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            questionBox.Font = new Font(font, size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        private void questionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int k = 0; k < answerArray.Length; k++)
            {
                answerArray[k] = false;
            }

            foreach (CheckBox element in checkBoxes)
            {
                element.Checked = false;
                element.Enabled = true;
            }

            foreach (TextBox element in textBoxes)
            {
                element.Text = "";
                element.Enabled = true;
            }

            foreach (TextBox element in textBoxes)
            {
                element.BackColor = Color.WhiteSmoke;
            }
            if (!exam)
            {
                nextButton.Enabled = false;
            }
            else { nextButton.Enabled = true; }

            if (!exam)
            {
                verifyButton.Enabled = true;
                verifyButton.Visible = true;
                finishButton.Enabled = false;
                finishButton.Visible = false;
            }

            if (questionsBox.SelectedIndex == 19 && exam == true)
            {
                nextButton.Enabled = false;
            }
            correctAnswers = 0;
            questionBox.Text = questionsBox.SelectedItem.ToString();

            if (!exam)
            {
                index = Array.IndexOf(logfile, questionBox.Text);



                indexChecked = questionsBox.SelectedIndex;



                for (int y = index; y <= index + 5; y++)
                {
                    if (logfile[y].Contains('+'))
                    {
                        correctAnswers++;
                        var aStringBuilder = new StringBuilder(logfile[y]);
                        aStringBuilder.Remove(0, 1);
                        //logfile[y] = aStringBuilder.ToString();

                        position = y;
                        for (int i = 0; i < textBoxes.Length; i++)
                        {
                            if (position == index + (i + 1))
                            {
                                textBoxes[i].Text = aStringBuilder.ToString();
                                answerArray[i] = true;
                            }

                        }
                    }
                }
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    if (textBoxes[i].Text == "")
                    {
    
                        textBoxes[i].Text = logfile[index + (i + 1)];
                        if (textBoxes[i].Text == "-")
                        {
                            textBoxes[i].Enabled = false;
                            checkBoxes[i].Enabled = false;
                        }
                    }
                }
            }
            else if (exam)
            {
                int switchCount = 1;
                bool done = false;
                string word = questionsBox.SelectedItem.ToString().Split('.').Last();
                while (!done)
                {
                    switch (switchCount)
                    {
                        case 1:
                            if (Properties.Settings.Default.culture == "et-EE")
                            {
                                filename = questionsEst[0];
                            }
                            else
                            {
                                filename = questionsRus[0];
                            }
                            logfile = File.ReadAllLines(filename);
                            //logfile.ToArray();
                            for (int o = 0; o < logfile.Length; o += 6)
                            {
                                if (logfile[o].Contains(word))
                                {
                                    oPosition = o;
                                    moodulName.Text = rm.GetString("modul1TS"); ;
                                    done = true;
                                }
                            }
                            switchCount++;
                            break;
                        case 2:
                            if (Properties.Settings.Default.culture == "et-EE")
                            {
                                filename = questionsEst[1];
                            }
                            else
                            {
                                filename = questionsRus[1];
                            }
                            logfile = File.ReadAllLines(filename);
                            //logfile.ToArray();
                            for (int o = 0; o < logfile.Length; o += 6)
                            {
                                if (logfile[o].Contains(word))
                                {
                                    oPosition = o;
                                    moodulName.Text = rm.GetString("modul2TS"); ;
                                    done = true;
                                }
                            }
                            switchCount++;
                            break;
                        case 3:
                            if (Properties.Settings.Default.culture == "et-EE")
                            {
                                filename = questionsEst[2];
                            }
                            else
                            {
                                filename = questionsRus[2];
                            }
                            logfile = File.ReadAllLines(filename);
                            //logfile.ToArray();
                            for (int o = 0; o < logfile.Length; o += 6)
                            {
                                if (logfile[o].Contains(word))
                                {
                                    oPosition = o;
                                    moodulName.Text = rm.GetString("modul3TS"); ;
                                    done = true;
                                }
                            }
                            switchCount++;
                            break;
                        case 4:
                            if (Properties.Settings.Default.culture == "et-EE")
                            {
                                filename = questionsEst[3];
                            }
                            else
                            {
                                filename = questionsRus[3];
                            }
                            logfile = File.ReadAllLines(filename);
                            //logfile.ToArray();
                            for (int o = 0; o < logfile.Length; o += 6)
                            {
                                if (logfile[o].Contains(word))
                                {
                                    oPosition = o;
                                    moodulName.Text = rm.GetString("modul4TS"); ;
                                    done = true;
                                }

                            }
                            break;
                    }
                }
                indexChecked = questionsBox.SelectedIndex;
                for (int y = oPosition; y <= oPosition + 5; y++)
                {
                    if (logfile[y].Contains('+'))
                    {
                        correctAnswers++;
                        var aStringBuilder = new StringBuilder(logfile[y]);
                        aStringBuilder.Remove(0, 1);
                        //logfile[y] = aStringBuilder.ToString();

                        position = y;

                        for (int i = 0; i < textBoxes.Length; i++)
                        {
                            if (position == oPosition + (i + 1))
                            {
                                textBoxes[i].Text = aStringBuilder.ToString();
                                answerArray[i] = true;
                            }

                        }
                    }
                    for (int i = 0; i < textBoxes.Length; i++)
                    {
                        if (textBoxes[i].Text == "")
                        {
                            textBoxes[i].Text = logfile[oPosition + (i + 1)];
                        }
                        if (textBoxes[i].Text == "-")
                        {
                            textBoxes[i].Enabled = false;
                            checkBoxes[i].Enabled = false;
                        }
                    }

                }
            }
        }

        public void fileLoad()
        {

            using (StreamReader sr = new StreamReader(filename))
            {
                logfile = File.ReadAllLines(filename);
                for (int z = 0; z <= logfile.Length; z += 6)
                {
                    if (z + 6 != logfile.Length)
                    {
                        questionsBox.Items.Add(logfile[z]);
                    }
                    else if (z + 6 == logfile.Length)
                    {
                        questionsBox.Items.Add(logfile[z]);
                        break;
                    }

                }

            }
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {

            verify();

        }
        public bool verify()
        {
            count = 0;
            //Answer A && checkBox1
            if (exam == false)
            {
                for (int i = 0; i < answerArray.Length; i++)
                {
                    if (answerArray[i] == true && checkBoxes[i].Checked == true)
                    {
                        textBoxes[i].BackColor = Color.Green;
                        count++;
                    }
                    else if (answerArray[i] == false && checkBoxes[i].Checked == true)
                    {
                        textBoxes[i].BackColor = Color.Red;
                    }
                }

                if (count == correctAnswers && count!=0)
                {
                    questionsBox.SetItemChecked(indexChecked, true);
                    

                    foreach (TextBox elements in textBoxes)
                    {
                        elements.Invalidate();
                        elements.Update();
                        elements.Refresh();
                        Application.DoEvents();

                    }
                    nextButton.Enabled = true;
                    return true;
                    //answeredQuestuins[indexChecked-1]=
                }
                else
                {
                    foreach(CheckBox element in checkBoxes)
                    {
                        element.Checked = false;
                    }
                    return false;
                }

            }

            else if (exam == true && (checkBox1.Checked==true|| checkBox2.Checked == true|| checkBox3.Checked == true|| checkBox4.Checked == true|| checkBox5.Checked == true))
            {
                for (int i = 0; i < answerArray.Length; i++)
                {
                    if (answerArray[i] == true && checkBoxes[i].Checked == true)
                    {
                        count++;
                    }
                }

                if (count == correctAnswers)
                {
                    examCorrectQuestions[corrAnsIndex] = questionBox.Text;
                    corrIndexes[corrAnsIndex] = indexChecked;
                    corrAnsIndex++;
                    return true;
                }
                else
                {
                    examWrongQuestions[wrongAnsIndex] = questionBox.Text;
                    wrongAnsIndex++;
                    return true;
                }
            }
            return false;
        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (randomCheckBox.Checked == true)
                {
                    Random rnd = new Random();
                    int randomIndex = rnd.Next(0, questionsBox.Items.Count);
                    //while (randomIndex == indexChecked && questionsBox.GetSelected(randomIndex) == true)
                    //{
                    //    randomIndex = rnd.Next(0, questionsBox.Items.Count);
                    //}

                    //if (questionsBox.GetItemChecked(randomIndex)==true)
                    //{
                    //    randomIndex = rnd.Next(0, questionsBox.Items.Count);
                    //}

                    check:

                    if (!questionsBox.GetItemChecked(randomIndex))
                    {
                        questionsBox.SetSelected(randomIndex, true);
                    }
                    else if (questionsBox.GetItemChecked(randomIndex))
                    {
                        randomIndex = rnd.Next(0, questionsBox.Items.Count);
                        goto check;
                    }
                }
                else
                {
                    if ((exam==false)||(exam && verify() == true))
                    {
                        questionsBox.SetSelected(indexChecked + 1, true);
                    }
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                if (exam == false)
                {
                    MessageBox.Show(rm.GetString("lastQuestion"), rm.GetString("attention"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        private void finishButton_Click(object sender, EventArgs e)
        {

                verify();
                int examCorrAnsCount = 0;
                int examWrongAnsCount = 0;

                foreach (string element in examCorrectQuestions)
                {
                    if (element != null && element != "")
                    {
                        examCorrAnsCount++;
                    }
                }
                foreach (string element in examWrongQuestions)
                {
                    if (element != null && element != "")
                    {
                        examWrongAnsCount++;
                    }
                }
                foreach (int element in corrIndexes)
                {
                    if (element != 0)
                    {
                        questionsBox.SetItemChecked(element, true);
                    }
                }


            string answers, correct, incorrect;
            if(examCorrAnsCount ==0 || examCorrAnsCount > 1)
            {
                correct = rm.GetString("correctPlural");
            }
            else
            {
                correct = rm.GetString("correctSingle");
            }

            if ((Convert.ToInt32(examCorrAnsCount) + Convert.ToInt32(examWrongAnsCount)) == 0 || (Convert.ToInt32(examCorrAnsCount) + Convert.ToInt32(examWrongAnsCount)) > 1)
            {
                answers = rm.GetString("answerPlural");
            }
            else
            {
                answers = rm.GetString("answerSingle");
            }

            if (examWrongAnsCount == 0 || examWrongAnsCount > 1)
            {
                incorrect = rm.GetString("incorrectPlural");
            }
            else
            {
                incorrect = rm.GetString("incorrectSingle");
            }


            MessageBox.Show(rm.GetString("testResult") + ": " + "\n" +
                    rm.GetString("from") + " " + (Convert.ToInt32(examCorrAnsCount) + Convert.ToInt32(examWrongAnsCount)) + " " + answers + " - " + examCorrAnsCount + " " + correct + ", " + examWrongAnsCount + " " + incorrect, rm.GetString("attention"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


            
                Array.Clear(examCorrectQuestions, 0, examCorrectQuestions.Length);
                Array.Clear(examWrongQuestions, 0, examWrongQuestions.Length);
                Array.Clear(corrIndexes, 0, corrIndexes.Length);
            }
        

        private void backButton_Click(object sender, EventArgs e)
        {
            try
            {
                questionsBox.SetSelected(indexChecked - 1, true);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(rm.GetString("firstQuestion"), rm.GetString("attention"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void modul1TS_Click(object sender, EventArgs e)
        {
            verifyButton.Enabled = true;
            randomCheckBox.Enabled = true;
            backButton.Enabled = true;
            exam = false;
            questionsBox.Items.Clear();
            moodulName.Text = rm.GetString("modul1TS");
            if (Properties.Settings.Default.culture == "et-EE")
            {
                filename = questionsEst[0];
            }
            else
            {
                filename = questionsRus[0];
            }
            fileLoad();
            questionsBox.Enabled = true;
            questionsBox.SetSelected(0, true);
        }

        private void modul2TS_Click(object sender, EventArgs e)
        {
            verifyButton.Enabled = true;
            randomCheckBox.Enabled = true;
            backButton.Enabled = true;
            exam = false;
            questionsBox.Items.Clear();
            moodulName.Text = rm.GetString("modul2TS");
            if (Properties.Settings.Default.culture == "et-EE")
            {
                filename = questionsEst[1];
            }
            else
            {
                filename = questionsRus[1];
            }
            fileLoad();
            questionsBox.Enabled = true;
            questionsBox.SetSelected(0, true);
        }

        private void modul3TS_Click(object sender, EventArgs e)
        {
            verifyButton.Enabled = true;
            randomCheckBox.Enabled = true;
            backButton.Enabled = true;
            exam = false;
            questionsBox.Items.Clear();
            moodulName.Text = rm.GetString("modul3TS");
            if (Properties.Settings.Default.culture == "et-EE")
            {
                filename = questionsEst[2];
            }
            else
            {
                filename = questionsRus[2];
            }
            fileLoad();
            questionsBox.Enabled = true;
            questionsBox.SetSelected(0, true);
        }

        private void modul4TS_Click(object sender, EventArgs e)
        {
            verifyButton.Enabled = true;
            randomCheckBox.Enabled = true;
            backButton.Enabled = true;
            exam = false;
            questionsBox.Items.Clear();
            moodulName.Text = rm.GetString("modul4TS");
            if (Properties.Settings.Default.culture == "et-EE")
            {
                filename = questionsEst[3];
            }
            else
            {
                filename = questionsRus[3];
            }
            fileLoad();
            questionsBox.Enabled = true;
            questionsBox.SetSelected(0, true);
        }

        private void examTS_Click(object sender, EventArgs e)
        {
            //    questions1.ToList();
            //    questions2.ToList();
            //    questions3.ToList();
            //    questions4.ToList();
            qPosition = 1;
            exam = true;
            verifyButton.Enabled = false;
            questionsBox.Items.Clear();
            randomCheckBox.Checked = false;
            randomCheckBox.Enabled = false;
            backButton.Enabled = false;
            verifyButton.Enabled = false;
            verifyButton.Visible = false;
            finishButton.Enabled = true;
            finishButton.Visible = true;
            questionsBox.Enabled = false;
            //questionsBox.Enabled = false;

            for (int k = 0; k < answerArray.Length; k++)
            {
                answerArray[k] = false;
            }

            foreach (CheckBox element in checkBoxes)
            {
                element.Checked = false;
            }

            foreach (TextBox element in textBoxes)
            {
                element.Text = "";
            }

            foreach (TextBox element in textBoxes)
            {
                element.BackColor = Color.WhiteSmoke;
            }

            for (int k = 1; k <= 4; k++)
            {
                switch (k)
                {
                    case 1:
                        if (Properties.Settings.Default.culture == "et-EE")
                        {
                            filename = questionsEst[0];
                        }
                        else
                        {
                            filename = questionsRus[0];
                        }
                        logfile = File.ReadAllLines(filename);
                        qAmount = logfile.Length / 6;
                        break;
                    case 2:
                        if (Properties.Settings.Default.culture == "et-EE")
                        {
                            filename = questionsEst[1];
                        }
                        else
                        {
                            filename = questionsRus[1];
                        }
                        logfile = File.ReadAllLines(filename);
                        qAmount = logfile.Length / 6;
                        break;
                    case 3:
                        if (Properties.Settings.Default.culture == "et-EE")
                        {
                            filename = questionsEst[2];
                        }
                        else
                        {
                            filename = questionsRus[2];
                        }
                        logfile = File.ReadAllLines(filename);
                        qAmount = logfile.Length / 6;
                        break;
                    case 4:
                        if (Properties.Settings.Default.culture == "et-EE")
                        {
                            filename = questionsEst[3];
                        }
                        else
                        {
                            filename = questionsRus[3];
                        }
                        logfile = File.ReadAllLines(filename);
                        qAmount = logfile.Length / 6;
                        break;
                }

                for (int y = 1; y <= 5; y++)
                {
                    int x = 0;
                    Random rnd = new Random();
                    switch (k)
                    {
                        case 1:
                            x = rnd.Next(0, qAmount);
                            x *= 6;
                            break;
                        case 2:
                            x = rnd.Next(0, qAmount);
                            x *= 6;
                            break;
                        case 3:
                            x = rnd.Next(0, qAmount);
                            x *= 6;
                            break;
                        case 4:
                            x = rnd.Next(0, qAmount);
                            x *= 6;
                            break;
                    }
                    var aStringBuilder = new StringBuilder(logfile[x]);
                    aStringBuilder.Remove(0, 3);
                    aStringBuilder.Insert(0,qPosition + ".");
                    qPosition++;
                    questionsBox.Items.Add(aStringBuilder);
                    System.Threading.Thread.Sleep(50);


                }
                questionsBox.SetSelected(0, true);
            }
        }

        // FEEDBACK

        private void feedbackButton_Click(object sender, EventArgs e)
        {
         //  MessageBox.Show(rm.GetString("feedback"), rm.GetString("contactMe"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            Feedback feedback = new Feedback();
            feedback.Show();
    
        }

        private void estonianTS_Click(object sender, EventArgs e)
        {
            culture = "et-EE";
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            Properties.Settings.Default.culture = culture;
            Properties.Settings.Default.Save();
            UpdateUIControls();
        }

        private void russianTS_Click(object sender, EventArgs e)
        {
            culture = "ru-Ru";
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            Properties.Settings.Default.culture = culture;
            Properties.Settings.Default.Save();
            UpdateUIControls();
        }

        private void englishTS_Click(object sender, EventArgs e)
        {
            culture = "en-GB";
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            Properties.Settings.Default.culture = culture;
            Properties.Settings.Default.Save();
            UpdateUIControls();
        }

        private void fontTS_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            DialogResult result = fontDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateFont(fontDialog.Font.Name, fontDialog.Font.Size);

                Properties.Settings.Default.fontName = fontDialog.Font.Name;
                Properties.Settings.Default.fontSize = fontDialog.Font.Size;
                Properties.Settings.Default.Save();
            }

        }

        private void aboutTS_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }
    }
}