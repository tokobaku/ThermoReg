namespace ThermoReg
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbLoginForm = new GroupBox();
            btLogin = new Button();
            tbPassword = new TextBox();
            tbUser = new TextBox();
            lbPassword = new Label();
            lbUser = new Label();
            gbLoginForm.SuspendLayout();
            SuspendLayout();
            // 
            // gbLoginForm
            // 
            gbLoginForm.Controls.Add(btLogin);
            gbLoginForm.Controls.Add(tbPassword);
            gbLoginForm.Controls.Add(tbUser);
            gbLoginForm.Controls.Add(lbPassword);
            gbLoginForm.Controls.Add(lbUser);
            gbLoginForm.Location = new Point(228, 157);
            gbLoginForm.Name = "gbLoginForm";
            gbLoginForm.Size = new Size(303, 144);
            gbLoginForm.TabIndex = 0;
            gbLoginForm.TabStop = false;
            gbLoginForm.Text = "Login";
            // 
            // btLogin
            // 
            btLogin.Location = new Point(215, 97);
            btLogin.Name = "btLogin";
            btLogin.Size = new Size(75, 23);
            btLogin.TabIndex = 4;
            btLogin.Text = "Login";
            btLogin.UseVisualStyleBackColor = true;
            btLogin.Click += btLogin_Click;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(190, 52);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(100, 23);
            tbPassword.TabIndex = 3;
            // 
            // tbUser
            // 
            tbUser.Location = new Point(190, 19);
            tbUser.Name = "tbUser";
            tbUser.Size = new Size(100, 23);
            tbUser.TabIndex = 2;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(59, 52);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(57, 15);
            lbPassword.TabIndex = 1;
            lbPassword.Text = "Password";
            // 
            // lbUser
            // 
            lbUser.AutoSize = true;
            lbUser.Location = new Point(59, 19);
            lbUser.Name = "lbUser";
            lbUser.Size = new Size(30, 15);
            lbUser.TabIndex = 0;
            lbUser.Text = "User";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 573);
            Controls.Add(gbLoginForm);
            Name = "LoginForm";
            Text = "Form1";
            gbLoginForm.ResumeLayout(false);
            gbLoginForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbLoginForm;
        private Label lbUser;
        private Label lbPassword;
        private TextBox tbUser;
        private TextBox tbPassword;
        private Button btLogin;
    }
}
