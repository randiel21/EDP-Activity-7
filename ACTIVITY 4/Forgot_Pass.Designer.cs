namespace ACTIVITY_4
{
    partial class Forgot_Pass
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
            this.ForgotPanel = new System.Windows.Forms.Panel();
            this.question = new System.Windows.Forms.Label();
            this.securityQ = new System.Windows.Forms.TextBox();
            this.LoginBttn = new System.Windows.Forms.Button();
            this.NewPass = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsrNmebox = new System.Windows.Forms.TextBox();
            this.ForgotPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ForgotPanel
            // 
            this.ForgotPanel.BackColor = System.Drawing.Color.Tan;
            this.ForgotPanel.Controls.Add(this.question);
            this.ForgotPanel.Controls.Add(this.securityQ);
            this.ForgotPanel.Controls.Add(this.LoginBttn);
            this.ForgotPanel.Controls.Add(this.NewPass);
            this.ForgotPanel.Controls.Add(this.UsernameLabel);
            this.ForgotPanel.Controls.Add(this.UsrNmebox);
            this.ForgotPanel.Location = new System.Drawing.Point(326, 69);
            this.ForgotPanel.Name = "ForgotPanel";
            this.ForgotPanel.Size = new System.Drawing.Size(311, 330);
            this.ForgotPanel.TabIndex = 1;
            // 
            // question
            // 
            this.question.AutoSize = true;
            this.question.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.question.Location = new System.Drawing.Point(83, 149);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(159, 15);
            this.question.TabIndex = 9;
            this.question.Text = "What is your Favorite food?";
            // 
            // securityQ
            // 
            this.securityQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.securityQ.Location = new System.Drawing.Point(85, 169);
            this.securityQ.Name = "securityQ";
            this.securityQ.Size = new System.Drawing.Size(147, 26);
            this.securityQ.TabIndex = 8;
            // 
            // LoginBttn
            // 
            this.LoginBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBttn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBttn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.LoginBttn.Location = new System.Drawing.Point(109, 244);
            this.LoginBttn.Name = "LoginBttn";
            this.LoginBttn.Size = new System.Drawing.Size(87, 28);
            this.LoginBttn.TabIndex = 7;
            this.LoginBttn.Text = "Confirm";
            this.LoginBttn.UseVisualStyleBackColor = true;
            this.LoginBttn.Click += new System.EventHandler(this.LoginBttn_Click);
            // 
            // NewPass
            // 
            this.NewPass.AutoSize = true;
            this.NewPass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.NewPass.Location = new System.Drawing.Point(82, 134);
            this.NewPass.Name = "NewPass";
            this.NewPass.Size = new System.Drawing.Size(111, 15);
            this.NewPass.TabIndex = 6;
            this.NewPass.Text = "Security Question?";
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
            // 
            // UsrNmebox
            // 
            this.UsrNmebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrNmebox.Location = new System.Drawing.Point(86, 93);
            this.UsrNmebox.Name = "UsrNmebox";
            this.UsrNmebox.Size = new System.Drawing.Size(147, 26);
            this.UsrNmebox.TabIndex = 2;
            this.UsrNmebox.TextChanged += new System.EventHandler(this.UsrNmebox_TextChanged);
            // 
            // Forgot_Pass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(965, 488);
            this.Controls.Add(this.ForgotPanel);
            this.Name = "Forgot_Pass";
            this.Text = "Forgot_Pass";
            this.Load += new System.EventHandler(this.Forgot_Pass_Load);
            this.ForgotPanel.ResumeLayout(false);
            this.ForgotPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ForgotPanel;
        private System.Windows.Forms.Label NewPass;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox UsrNmebox;
        private System.Windows.Forms.Button LoginBttn;
        private System.Windows.Forms.TextBox securityQ;
        private System.Windows.Forms.Label question;
    }
}