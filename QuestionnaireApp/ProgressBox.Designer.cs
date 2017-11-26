namespace QuestionannaireApp
{
    partial class ProgressBox
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
            this.startUpLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startUpLabel
            // 
            this.startUpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startUpLabel.Location = new System.Drawing.Point(71, 38);
            this.startUpLabel.Name = "startUpLabel";
            this.startUpLabel.Size = new System.Drawing.Size(280, 23);
            this.startUpLabel.TabIndex = 0;
            // 
            // ProgressBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 96);
            this.Controls.Add(this.startUpLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressBox";
            this.Text = "Questionnaire App";
            this.Load += new System.EventHandler(this.ProgressBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label startUpLabel;
    }
}