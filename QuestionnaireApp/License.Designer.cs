namespace QuestionannaireApp
{
    partial class License
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(License));
            this.licenseA = new System.Windows.Forms.TextBox();
            this.licenseB = new System.Windows.Forms.TextBox();
            this.licenseC = new System.Windows.Forms.TextBox();
            this.licenseD = new System.Windows.Forms.TextBox();
            this.licenseE = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // licenseA
            // 
            this.licenseA.AcceptsTab = true;
            this.licenseA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.licenseA.Location = new System.Drawing.Point(28, 30);
            this.licenseA.MaxLength = 4;
            this.licenseA.Name = "licenseA";
            this.licenseA.Size = new System.Drawing.Size(79, 20);
            this.licenseA.TabIndex = 0;
            this.licenseA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.licenseA.WordWrap = false;
            // 
            // licenseB
            // 
            this.licenseB.AcceptsTab = true;
            this.licenseB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.licenseB.Location = new System.Drawing.Point(113, 30);
            this.licenseB.MaxLength = 4;
            this.licenseB.Name = "licenseB";
            this.licenseB.Size = new System.Drawing.Size(79, 20);
            this.licenseB.TabIndex = 1;
            this.licenseB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.licenseB.WordWrap = false;
            // 
            // licenseC
            // 
            this.licenseC.AcceptsTab = true;
            this.licenseC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.licenseC.Location = new System.Drawing.Point(198, 30);
            this.licenseC.MaxLength = 4;
            this.licenseC.Name = "licenseC";
            this.licenseC.Size = new System.Drawing.Size(79, 20);
            this.licenseC.TabIndex = 2;
            this.licenseC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.licenseC.WordWrap = false;
            // 
            // licenseD
            // 
            this.licenseD.AcceptsTab = true;
            this.licenseD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.licenseD.Location = new System.Drawing.Point(283, 30);
            this.licenseD.MaxLength = 4;
            this.licenseD.Name = "licenseD";
            this.licenseD.Size = new System.Drawing.Size(79, 20);
            this.licenseD.TabIndex = 3;
            this.licenseD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.licenseD.WordWrap = false;
            // 
            // licenseE
            // 
            this.licenseE.AcceptsTab = true;
            this.licenseE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.licenseE.Location = new System.Drawing.Point(368, 30);
            this.licenseE.MaxLength = 4;
            this.licenseE.Name = "licenseE";
            this.licenseE.Size = new System.Drawing.Size(79, 20);
            this.licenseE.TabIndex = 4;
            this.licenseE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.licenseE.WordWrap = false;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(28, 72);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(164, 23);
            this.registerButton.TabIndex = 5;
            this.registerButton.Text = "Register the license";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(283, 71);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(164, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 107);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.licenseE);
            this.Controls.Add(this.licenseD);
            this.Controls.Add(this.licenseC);
            this.Controls.Add(this.licenseB);
            this.Controls.Add(this.licenseA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "License";
            this.Text = "License";
            this.Load += new System.EventHandler(this.License_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox licenseA;
        private System.Windows.Forms.TextBox licenseB;
        private System.Windows.Forms.TextBox licenseC;
        private System.Windows.Forms.TextBox licenseD;
        private System.Windows.Forms.TextBox licenseE;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button cancelButton;
    }
}