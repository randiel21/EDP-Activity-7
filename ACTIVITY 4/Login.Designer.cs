namespace ACTIVITY_4
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.ADPIC = new System.Windows.Forms.PictureBox();
            this.ForgotPassword = new System.Windows.Forms.LinkLabel();
            this.Passwordlabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.usern = new System.Windows.Forms.TextBox();
            this.passwrd = new System.Windows.Forms.TextBox();
            this.LoginBttn = new System.Windows.Forms.Button();
            this.LoginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADPIC)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.Tan;
            this.LoginPanel.Controls.Add(this.ADPIC);
            this.LoginPanel.Controls.Add(this.ForgotPassword);
            this.LoginPanel.Controls.Add(this.Passwordlabel);
            this.LoginPanel.Controls.Add(this.UsernameLabel);
            this.LoginPanel.Controls.Add(this.usern);
            this.LoginPanel.Controls.Add(this.passwrd);
            this.LoginPanel.Controls.Add(this.LoginBttn);
            this.LoginPanel.Location = new System.Drawing.Point(330, 85);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(311, 299);
            this.LoginPanel.TabIndex = 0;
            // 
            // ADPIC
            // 
            this.ADPIC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ADPIC.Image = ((System.Drawing.Image)(resources.GetObject("ADPIC.Image")));
            this.ADPIC.Location = new System.Drawing.Point(118, 15);
            this.ADPIC.Name = "ADPIC";
            this.ADPIC.Size = new System.Drawing.Size(73, 57);
            this.ADPIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ADPIC.TabIndex = 6;
            this.ADPIC.TabStop = false;
            // 
            // ForgotPassword
            // 
            this.ForgotPassword.AutoSize = true;
            this.ForgotPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgotPassword.Location = new System.Drawing.Point(160, 168);
            this.ForgotPassword.Name = "ForgotPassword";
            this.ForgotPassword.Size = new System.Drawing.Size(99, 13);
            this.ForgotPassword.TabIndex = 5;
            this.ForgotPassword.TabStop = true;
            this.ForgotPassword.Text = "Forgot Password?";
            this.ForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ForgotPassword_LinkClicked);
            // 
            // Passwordlabel
            // 
            this.Passwordlabel.AutoSize = true;
            this.Passwordlabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passwordlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.Passwordlabel.Location = new System.Drawing.Point(83, 127);
            this.Passwordlabel.Name = "Passwordlabel";
            this.Passwordlabel.Size = new System.Drawing.Size(59, 15);
            this.Passwordlabel.TabIndex = 4;
            this.Passwordlabel.Text = "Password";
            this.Passwordlabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.UsernameLabel.Location = new System.Drawing.Point(83, 75);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(64, 15);
            this.UsernameLabel.TabIndex = 3;
            this.UsernameLabel.Text = "Username";
            this.UsernameLabel.Click += new System.EventHandler(this.UsernameLabel_Click);
            // 
            // usern
            // 
            this.usern.Location = new System.Drawing.Point(86, 93);
            this.usern.Name = "usern";
            this.usern.Size = new System.Drawing.Size(147, 20);
            this.usern.TabIndex = 2;
            // 
            // passwrd
            // 
            this.passwrd.Location = new System.Drawing.Point(86, 145);
            this.passwrd.Name = "passwrd";
            this.passwrd.Size = new System.Drawing.Size(147, 20);
            this.passwrd.TabIndex = 1;
            this.passwrd.UseSystemPasswordChar = true;
            // 
            // LoginBttn
            // 
            this.LoginBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBttn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBttn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.LoginBttn.Location = new System.Drawing.Point(118, 184);
            this.LoginBttn.Name = "LoginBttn";
            this.LoginBttn.Size = new System.Drawing.Size(64, 28);
            this.LoginBttn.TabIndex = 0;
            this.LoginBttn.Text = "Login";
            this.LoginBttn.UseVisualStyleBackColor = true;
            this.LoginBttn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(969, 450);
            this.Controls.Add(this.LoginPanel);
            this.Name = "Login";
            this.Text = "login";
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADPIC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Button LoginBttn;
        private System.Windows.Forms.Label Passwordlabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox usern;
        private System.Windows.Forms.TextBox passwrd;
        private System.Windows.Forms.LinkLabel ForgotPassword;
        private System.Windows.Forms.PictureBox ADPIC;
    }
}

