namespace QuestionannaireApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.verifyButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.moodulTS = new System.Windows.Forms.ToolStripMenuItem();
            this.moodul1TS = new System.Windows.Forms.ToolStripMenuItem();
            this.moodul2TS = new System.Windows.Forms.ToolStripMenuItem();
            this.moodul3TS = new System.Windows.Forms.ToolStripMenuItem();
            this.moodul4TS = new System.Windows.Forms.ToolStripMenuItem();
            this.examTS = new System.Windows.Forms.ToolStripMenuItem();
            this.moodulName = new System.Windows.Forms.Label();
            this.questionsBox = new System.Windows.Forms.CheckedListBox();
            this.answerBoxB = new System.Windows.Forms.TextBox();
            this.answerBoxC = new System.Windows.Forms.TextBox();
            this.answerBoxD = new System.Windows.Forms.TextBox();
            this.answerBoxE = new System.Windows.Forms.TextBox();
            this.answerBoxA = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.questionBox = new System.Windows.Forms.TextBox();
            this.randomCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // verifyButton
            // 
            this.verifyButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.verifyButton.Location = new System.Drawing.Point(494, 663);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(166, 33);
            this.verifyButton.TabIndex = 13;
            this.verifyButton.Text = "Проверить";
            this.verifyButton.UseVisualStyleBackColor = true;
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nextButton.Location = new System.Drawing.Point(712, 662);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(166, 34);
            this.nextButton.TabIndex = 14;
            this.nextButton.Text = "Далее";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.backButton.Location = new System.Drawing.Point(271, 662);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(166, 34);
            this.backButton.TabIndex = 17;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moodulTS});
            this.menuStrip1.Location = new System.Drawing.Point(9, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(69, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // moodulTS
            // 
            this.moodulTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moodul1TS,
            this.moodul2TS,
            this.moodul3TS,
            this.moodul4TS,
            this.examTS});
            this.moodulTS.Name = "moodulTS";
            this.moodulTS.Size = new System.Drawing.Size(61, 20);
            this.moodulTS.Text = "Moodul";
            // 
            // moodul1TS
            // 
            this.moodul1TS.Name = "moodul1TS";
            this.moodul1TS.Size = new System.Drawing.Size(139, 22);
            this.moodul1TS.Text = "Модуль №1";
            this.moodul1TS.Click += new System.EventHandler(this.moodul1TS_Click);
            // 
            // moodul2TS
            // 
            this.moodul2TS.Name = "moodul2TS";
            this.moodul2TS.Size = new System.Drawing.Size(139, 22);
            this.moodul2TS.Text = "Модуль №2";
            this.moodul2TS.Click += new System.EventHandler(this.moodul2TS_Click);
            // 
            // moodul3TS
            // 
            this.moodul3TS.Name = "moodul3TS";
            this.moodul3TS.Size = new System.Drawing.Size(139, 22);
            this.moodul3TS.Text = "Модуль №3";
            this.moodul3TS.Click += new System.EventHandler(this.moodul3TS_Click);
            // 
            // moodul4TS
            // 
            this.moodul4TS.Name = "moodul4TS";
            this.moodul4TS.Size = new System.Drawing.Size(139, 22);
            this.moodul4TS.Text = "Модуль №4";
            this.moodul4TS.Click += new System.EventHandler(this.moodul4TS_Click);
            // 
            // examTS
            // 
            this.examTS.Name = "examTS";
            this.examTS.Size = new System.Drawing.Size(139, 22);
            this.examTS.Text = "Экзамен";
            this.examTS.Click += new System.EventHandler(this.examTS_Click);
            // 
            // moodulName
            // 
            this.moodulName.AutoSize = true;
            this.moodulName.Location = new System.Drawing.Point(392, 20);
            this.moodulName.Name = "moodulName";
            this.moodulName.Size = new System.Drawing.Size(0, 13);
            this.moodulName.TabIndex = 20;
            // 
            // questionsBox
            // 
            this.questionsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.questionsBox.FormattingEnabled = true;
            this.questionsBox.Location = new System.Drawing.Point(6, 55);
            this.questionsBox.Name = "questionsBox";
            this.questionsBox.ScrollAlwaysVisible = true;
            this.questionsBox.Size = new System.Drawing.Size(135, 619);
            this.questionsBox.TabIndex = 1;
            this.questionsBox.SelectedIndexChanged += new System.EventHandler(this.questionsBox_SelectedIndexChanged);
            // 
            // answerBoxB
            // 
            this.answerBoxB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerBoxB.Location = new System.Drawing.Point(156, 308);
            this.answerBoxB.Multiline = true;
            this.answerBoxB.Name = "answerBoxB";
            this.answerBoxB.ReadOnly = true;
            this.answerBoxB.Size = new System.Drawing.Size(746, 81);
            this.answerBoxB.TabIndex = 2;
            // 
            // answerBoxC
            // 
            this.answerBoxC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerBoxC.Location = new System.Drawing.Point(156, 393);
            this.answerBoxC.Multiline = true;
            this.answerBoxC.Name = "answerBoxC";
            this.answerBoxC.ReadOnly = true;
            this.answerBoxC.Size = new System.Drawing.Size(746, 79);
            this.answerBoxC.TabIndex = 3;
            // 
            // answerBoxD
            // 
            this.answerBoxD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerBoxD.Location = new System.Drawing.Point(156, 478);
            this.answerBoxD.Multiline = true;
            this.answerBoxD.Name = "answerBoxD";
            this.answerBoxD.ReadOnly = true;
            this.answerBoxD.Size = new System.Drawing.Size(746, 79);
            this.answerBoxD.TabIndex = 4;
            // 
            // answerBoxE
            // 
            this.answerBoxE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerBoxE.Location = new System.Drawing.Point(156, 563);
            this.answerBoxE.Multiline = true;
            this.answerBoxE.Name = "answerBoxE";
            this.answerBoxE.ReadOnly = true;
            this.answerBoxE.Size = new System.Drawing.Size(746, 79);
            this.answerBoxE.TabIndex = 5;
            // 
            // answerBoxA
            // 
            this.answerBoxA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerBoxA.Location = new System.Drawing.Point(156, 223);
            this.answerBoxA.Multiline = true;
            this.answerBoxA.Name = "answerBoxA";
            this.answerBoxA.ReadOnly = true;
            this.answerBoxA.Size = new System.Drawing.Size(746, 79);
            this.answerBoxA.TabIndex = 7;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(930, 255);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(33, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "A";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(930, 341);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(33, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "B";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(930, 428);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(33, 17);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "C";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(930, 514);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(34, 17);
            this.checkBox4.TabIndex = 11;
            this.checkBox4.Text = "D";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(930, 596);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(33, 17);
            this.checkBox5.TabIndex = 12;
            this.checkBox5.Text = "E";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // questionBox
            // 
            this.questionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionBox.Location = new System.Drawing.Point(156, 59);
            this.questionBox.Multiline = true;
            this.questionBox.Name = "questionBox";
            this.questionBox.ReadOnly = true;
            this.questionBox.Size = new System.Drawing.Size(770, 99);
            this.questionBox.TabIndex = 15;
            // 
            // randomCheckBox
            // 
            this.randomCheckBox.AutoSize = true;
            this.randomCheckBox.Location = new System.Drawing.Point(156, 178);
            this.randomCheckBox.Name = "randomCheckBox";
            this.randomCheckBox.Size = new System.Drawing.Size(73, 17);
            this.randomCheckBox.TabIndex = 16;
            this.randomCheckBox.Text = "Случайно";
            this.randomCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.moodulName);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.randomCheckBox);
            this.Controls.Add(this.questionBox);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.answerBoxA);
            this.Controls.Add(this.answerBoxE);
            this.Controls.Add(this.answerBoxD);
            this.Controls.Add(this.answerBoxC);
            this.Controls.Add(this.answerBoxB);
            this.Controls.Add(this.questionsBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Программка";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label moodulName;
        private System.Windows.Forms.ToolStripMenuItem moodulTS;
        private System.Windows.Forms.ToolStripMenuItem moodul1TS;
        private System.Windows.Forms.ToolStripMenuItem moodul2TS;
        private System.Windows.Forms.ToolStripMenuItem moodul3TS;
        private System.Windows.Forms.ToolStripMenuItem moodul4TS;
        private System.Windows.Forms.ToolStripMenuItem examTS;
        private System.Windows.Forms.CheckedListBox questionsBox;
        private System.Windows.Forms.TextBox answerBoxB;
        private System.Windows.Forms.TextBox answerBoxC;
        private System.Windows.Forms.TextBox answerBoxD;
        private System.Windows.Forms.TextBox answerBoxE;
        private System.Windows.Forms.TextBox answerBoxA;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.TextBox questionBox;
        private System.Windows.Forms.CheckBox randomCheckBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

