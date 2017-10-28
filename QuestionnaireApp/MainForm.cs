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


        public static string filename = "";
        public string correctAnswer = "";
        //public string locationEXE = AppDomain.CurrentDomain.BaseDirectory;
        public string questions1 = AppDomain.CurrentDomain.BaseDirectory + "questions1.txt";
        public string questions2 = AppDomain.CurrentDomain.BaseDirectory + "questions2.txt";
        public string questions3 = AppDomain.CurrentDomain.BaseDirectory + "questions3.txt";
        public string questions4 = AppDomain.CurrentDomain.BaseDirectory + "questions4.txt";



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
        public bool verified;

        public static string[] logfile;
        public TextBox[] textBoxes = new TextBox[5];
        public CheckBox[] checkBoxes = new CheckBox[5];
        public bool[] answerArray = new bool[5];
        public string[] answeredQuestuins = new string[10];
        public string[] questions = new string[4];
        public string[] files = { "QuestionannaireApp.exe", "questions1.txt", "questions2.txt", "questions3.txt", "questions4.txt" };
        public string[] examCorrectQuestions = new string[20];
        public string[] examWrongQuestions = new string[20];
        public int[] corrIndexes = new int[20];

        public int[] versionCheckArray = new int[3];


        public string currentVersion = "0.2.2";
        public int[] currentVersionArray = { 0, 2, 0 };
        public string[] previousVersions = { "0.0.1", "0.0.2", "0.0.3", "0.1.1","0.1.2","0.1.3","0.1.4","0.1.5", "0.1.6"};
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(string element in previousVersions)
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + files[0].Insert(18, " - " + element)))
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + files[0].Insert(18, " - " + element));
                System.Threading.Thread.Sleep(50);
            }
            //if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + files[0]))
            //{
            //    File.Delete(AppDomain.CurrentDomain.BaseDirectory + files[0]);
            //}
            


            System.Threading.Thread.Sleep(1000);
            update();
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Version.txt");

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

            questions[0] = questions1;
            questions[1] = questions2;
            questions[2] = questions3;
            questions[3] = questions4;

        }

        private void questionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //for (int k = 0;k< answerArray.Length; k++)
            //{
            //    answerArray[k] = false;
            //}
            answerA = false;
            answerB = false;
            answerC = false;
            answerD = false;
            answerE = false;

            verified = false;

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

            correctAnswers = 0;
            questionBox.Text = questionsBox.SelectedItem.ToString();

            if (!exam)
            {
                //string word = questionsBox.SelectedItem.ToString().Split('.').Last();

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

                        if (position == index + 1)
                        {
                            answerBoxA.Text = aStringBuilder.ToString();

                            answerA = true;
                            //checkBox1.Checked = true;
                        }
                        else if (position == index + 2)
                        {
                            answerBoxB.Text = aStringBuilder.ToString();
                            answerB = true;
                            //checkBox2.Checked = true;
                        }
                        else if (position == index + 3)
                        {
                            answerBoxC.Text = aStringBuilder.ToString();
                            answerC = true;
                            //checkBox3.Checked = true;
                        }
                        else if (position == index + 4)
                        {
                            answerBoxD.Text = aStringBuilder.ToString();
                            answerD = true;
                            //checkBox4.Checked = true;
                        }
                        else if (position == index + 5)
                        {
                            answerBoxE.Text = aStringBuilder.ToString();
                            answerE = true;
                            //checkBox5.Checked = true;
                        }


                    }
                }
                if (answerBoxA.Text == "")
                {
                    answerBoxA.Text = logfile[index + 1];
                }
                if (answerBoxB.Text == "")
                {
                    answerBoxB.Text = logfile[index + 2];
                }
                if (answerBoxC.Text == "")
                {
                    answerBoxC.Text = logfile[index + 3];
                }
                if (answerBoxD.Text == "")
                {
                    answerBoxD.Text = logfile[index + 4];
                }
                if (answerBoxE.Text == "")
                {
                    answerBoxE.Text = logfile[index + 5];
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
                            filename = questions1;
                            logfile = File.ReadAllLines(filename);
                            //logfile.ToArray();
                            for (int o = 0; o < logfile.Length; o += 6)
                            {
                                if (logfile[o].Contains(word))
                                {
                                    oPosition = o;
                                    done = true;
                                }
                            }
                            switchCount++;
                            break;
                        case 2:
                            filename = questions2;
                            logfile = File.ReadAllLines(filename);
                            //logfile.ToArray();
                            for (int o = 0; o < logfile.Length; o += 6)
                            {
                                if (logfile[o].Contains(word))
                                {
                                    oPosition = o;
                                    done = true;
                                }
                            }
                            switchCount++;
                            break;
                        case 3:
                            filename = questions3;
                            logfile = File.ReadAllLines(filename);
                            //logfile.ToArray();
                            for (int o = 0; o < logfile.Length; o += 6)
                            {
                                if (logfile[o].Contains(word))
                                {
                                    oPosition = o;
                                    done = true;
                                }
                            }
                            switchCount++;
                            break;
                        case 4:
                            filename = questions4;
                            logfile = File.ReadAllLines(filename);
                            //logfile.ToArray();
                            for (int o = 0; o < logfile.Length; o += 6)
                            {
                                if (logfile[o].Contains(word))
                                {
                                    oPosition = o;
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

                        if (position == oPosition + 1)
                        {
                            answerBoxA.Text = aStringBuilder.ToString();

                            answerA = true;
                            //checkBox1.Checked = true;
                        }
                        else if (position == oPosition + 2)
                        {
                            answerBoxB.Text = aStringBuilder.ToString();
                            answerB = true;
                            //checkBox2.Checked = true;
                        }
                        else if (position == oPosition + 3)
                        {
                            answerBoxC.Text = aStringBuilder.ToString();
                            answerC = true;
                            //checkBox3.Checked = true;
                        }
                        else if (position == oPosition + 4)
                        {
                            answerBoxD.Text = aStringBuilder.ToString();
                            answerD = true;
                            //checkBox4.Checked = true;
                        }
                        else if (position == oPosition + 5)
                        {
                            answerBoxE.Text = aStringBuilder.ToString();
                            answerE = true;
                            //checkBox5.Checked = true;
                        }
                    }
                }
                if (answerBoxA.Text == "")
                {
                    answerBoxA.Text = logfile[oPosition + 1];
                }
                if (answerBoxB.Text == "")
                {
                    answerBoxB.Text = logfile[oPosition + 2];
                }
                if (answerBoxC.Text == "")
                {
                    answerBoxC.Text = logfile[oPosition + 3];
                }
                if (answerBoxD.Text == "")
                {
                    answerBoxD.Text = logfile[oPosition + 4];
                }
                if (answerBoxE.Text == "")
                {
                    answerBoxE.Text = logfile[oPosition + 5];
                }

            }

           

            //if(position1== index +1 || position1 == index + 2)
            //{
            //    answerA = true;
            //    radioButton1.Checked = true;
            //}
            //else if (position1 == index + 3 || position1 == index + 4)
            //{
            //    answerB = true;
            //    radioButton2.Checked = true;
            //}
            //else if (position1 == index + 5 || position1 == index + 6)
            //{
            //    answerC = true;
            //    radioButton3.Checked = true;
            //}
            //else if (position1 == index + 7 || position1 == index + 8)
            //{
            //    answerD = true;
            //    radioButton4.Checked = true;
            //}
            //else if (position1 == index + 9 || position1 == index + 10)
            //{
            //    answerE = true;
            //    radioButton5.Checked = true;
            //}
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
        public void verify()
        {
            count = 0;
            //Answer A && checkBox1
            if (exam == false)
            {
                if (answerA == true && checkBox1.Checked == true)
                {
                    answerBoxA.BackColor = Color.Green;
                    count++;
                }
                else if (answerA == false && checkBox1.Checked == true)
                {
                    answerBoxA.BackColor = Color.Red;
                }
                else if (answerA == false && checkBox1.Checked == false)
                {
                    answerBoxA.BackColor = Color.WhiteSmoke;
                }

                //Asnwer B && checkBox2
                if (answerB == true && checkBox2.Checked == true)
                {
                    answerBoxB.BackColor = Color.Green;
                    count++;
                }
                else if (answerB == false && checkBox2.Checked == true)
                {
                    answerBoxB.BackColor = Color.Red;
                }
                else if (answerB == false && checkBox2.Checked == false)
                {
                    answerBoxB.BackColor = Color.WhiteSmoke;
                }

                //Answer C && checkBox3
                if (answerC == true && checkBox3.Checked == true)
                {
                    answerBoxC.BackColor = Color.Green;
                    count++;
                }
                else if (answerC == false && checkBox3.Checked == true)
                {
                    answerBoxC.BackColor = Color.Red;
                }
                else if (answerC == false && checkBox3.Checked == false)
                {
                    answerBoxC.BackColor = Color.WhiteSmoke;
                }

                //Answer D && checkBox4
                if (answerD == true && checkBox4.Checked == true)
                {
                    answerBoxD.BackColor = Color.Green;
                    count++;
                }
                else if (answerD == false && checkBox4.Checked == true)
                {
                    answerBoxD.BackColor = Color.Red;
                }
                else if (answerD == false && checkBox4.Checked == false)
                {
                    answerBoxD.BackColor = Color.WhiteSmoke;
                }

                //Answer E && checkBox5
                if (answerE == true && checkBox5.Checked == true)
                {
                    answerBoxE.BackColor = Color.Green;

                    count++;
                }
                else if (answerE == false && checkBox5.Checked == true)
                {
                    answerBoxE.BackColor = Color.Red;
                }
                else if (answerE == false && checkBox5.Checked == false)
                {
                    answerBoxE.BackColor = Color.WhiteSmoke;
                }

                if (count == correctAnswers)
                {
                    questionsBox.SetItemChecked(indexChecked, true);
                    //answeredQuestuins[indexChecked-1]=
                }

                foreach (CheckBox element in checkBoxes)
                {
                    element.Checked = false;
                }

                verified = true;
            }
            else if (exam == true)
            {
                if (answerA == true && checkBox1.Checked == true)
                {
                    count++;
                }

                if (answerB == true && checkBox2.Checked == true)
                {
                    count++;
                }

                if (answerC == true && checkBox3.Checked == true)
                {
                    count++;
                }

                if (answerD == true && checkBox4.Checked == true)
                {
                    count++;
                }

                if (answerE == true && checkBox5.Checked == true)
                {
                    count++;
                }

                if(count == correctAnswers)
                {
                    examCorrectQuestions[corrAnsIndex] = questionBox.Text;
                    corrIndexes[corrAnsIndex] = indexChecked;
                    corrAnsIndex++;
                    
                }
                else
                {
                    examWrongQuestions[wrongAnsIndex]= questionBox.Text;
                    wrongAnsIndex++;
                }
            }




        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (verified == false && (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true))
            {
                verify();
                if (exam == false)
                {
                    foreach (TextBox elements in textBoxes)
                    {
                        elements.Invalidate();
                        elements.Update();
                        elements.Refresh();
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(2000);
                    }


                }


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
                        questionsBox.SetSelected(indexChecked + 1, true);
                    }


                }
                catch (ArgumentOutOfRangeException)
                {
                    if (exam == false)
                    {
                        MessageBox.Show("Это последний вопрос!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
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
                        //try
                        //{
                            //foreach (string element in examCorrectQuestions)
                            //{
                            //    foreach (Object item in questionsBox.Items)
                            //    {
                            //        if (element != null)
                            //        {
                            //            if (Convert.ToString(item) == element)
                            //            {
                            //                questionsBox.SetItemChecked(questionsBox.Items.IndexOf(item), true);
                            //                //int index = questionsBox.Items.IndexOf(item);
                            //            }
                            //        }

                            //    }
                            //}

                        //}
                       // catch (InvalidOperationException)
                       // {
                         //   MessageBox.Show("Результат теста: " + "\n"+ 
                        //        "Из "+ (Convert.ToInt32(examCorrAnsCount)+Convert.ToInt32(examWrongAnsCount)) +" ответов - "+examCorrAnsCount+" правильных и "+examWrongAnsCount+" неправильных", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                       // }
                    //
                    }
                }
            }
        }
        //public 
        private void backButton_Click(object sender, EventArgs e)
        {
            try
            {
                questionsBox.SetSelected(indexChecked - 1, true);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Это первый вопрос!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void moodul1TS_Click(object sender, EventArgs e)
        {
            verifyButton.Enabled = true;
            exam = false;
            questionsBox.Items.Clear();
            moodulName.Text = "Модуль №1";
            filename = questions1;
            fileLoad();
            questionsBox.SetSelected(0, true);
        }

        private void moodul2TS_Click(object sender, EventArgs e)
        {
            verifyButton.Enabled = true;
            exam = false;
            questionsBox.Items.Clear();
            moodulName.Text = "Модуль №2";
            filename = questions2;
            fileLoad();
            questionsBox.SetSelected(0, true);
        }

        private void moodul3TS_Click(object sender, EventArgs e)
        {
            verifyButton.Enabled = true;
            exam = false;
            questionsBox.Items.Clear();
            moodulName.Text = "Модуль №3";
            filename = questions3;
            fileLoad();
            questionsBox.SetSelected(0, true);
        }

        private void moodul4TS_Click(object sender, EventArgs e)
        {
            verifyButton.Enabled = true;
            exam = false;
            questionsBox.Items.Clear();
            moodulName.Text = "Модуль №4";
            filename = questions4;
            fileLoad();
            questionsBox.SetSelected(0, true);
        }

        private void examTS_Click(object sender, EventArgs e)
        {
            //    questions1.ToList();
            //    questions2.ToList();
            //    questions3.ToList();
            //    questions4.ToList();
            exam = true;
            verifyButton.Enabled = false;
            questionsBox.Items.Clear();
            randomCheckBox.Enabled = false;
            backButton.Enabled = false;
            //questionsBox.Enabled = false;

            answerA = false;
            answerB = false;
            answerC = false;
            answerD = false;
            answerE = false;

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
                        filename = questions1;
                        logfile = File.ReadAllLines(filename);
                        qAmount = logfile.Length / 6;
                        break;
                    case 2:
                        filename = questions2;
                        logfile = File.ReadAllLines(filename);
                        qAmount = logfile.Length / 6;
                        break;
                    case 3:
                        filename = questions3;
                        logfile = File.ReadAllLines(filename);
                        qAmount = logfile.Length / 6;
                        break;
                    case 4:
                        filename = questions4;
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
        static string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            for (int r = 0; r<array.Length;r++)
            {
                builder.Append(array[r]);
                if (r != array.Length-1)
                {
                    builder.Append('.');
                }
            }
            return builder.ToString();
        }
        public void update()
        {
            int verPos = 0;
            using (var client = new System.Net.WebClient())
            {
                client.DownloadFile("https://raw.githubusercontent.com/lyfenwebos/QuestionnaireApp/master/QuestionnaireApp/VersionInfo.txt", "Version.txt");
            }
            string[] verCheck = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Version.txt");
            for (int y = 0; y < verCheck.Length; y++)
            {
                versionCheckArray[y] = Convert.ToInt32(verCheck[y]);
            }


            foreach (int element in currentVersionArray)
            {
                if (element < versionCheckArray[verPos])
                {

                    using (var client = new System.Net.WebClient())
                    {
                        for (int p = 0; p < files.Length; p++)
                        {
                            if (p == 0 && !File.Exists(files[p].Insert(18, " - " + ConvertStringArrayToString(verCheck))))
                            {
                                client.DownloadFile("https://github.com/lyfenwebos/QuestionnaireApp/blob/master/QuestionnaireApp/bin/Release/" + files[p] + "?raw=true", files[p].Insert(18, " - " + ConvertStringArrayToString(verCheck)));
                            }
                            else
                            {
                                client.DownloadFile("https://github.com/lyfenwebos/QuestionnaireApp/blob/master/QuestionnaireApp/bin/Release/" + files[p] + "?raw=true", files[p]);
                            }

                        }

                    }
                    System.Threading.Thread.Sleep(5000);
                    System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + files[0].Insert(18, " - " + ConvertStringArrayToString(verCheck)));
                    Application.Exit();
                    break;
                }
                else
                {
                    answerBoxA.Text = "Version is up to date";
                }
                verPos++;
            }

        }
    }


}