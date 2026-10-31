namespace ThermoReg
{
    partial class RegisterForm
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
            gbRegister = new GroupBox();
            btRegister = new Button();
            tbPassword = new MaskedTextBox();
            tbUser = new TextBox();
            lbPassword = new Label();
            lbUser = new Label();
            gbRegister.SuspendLayout();
            SuspendLayout();
            // 
            // gbRegister
            // 
            gbRegister.Controls.Add(btRegister);
            gbRegister.Controls.Add(tbPassword);
            gbRegister.Controls.Add(tbUser);
            gbRegister.Controls.Add(lbPassword);
            gbRegister.Controls.Add(lbUser);
            gbRegister.Location = new Point(242, 107);
            gbRegister.Name = "gbRegister";
            gbRegister.Size = new Size(329, 175);
            gbRegister.TabIndex = 0;
            gbRegister.TabStop = false;
            gbRegister.Text = "Register";
            // 
            // btRegister
            // 
            btRegister.Location = new Point(197, 128);
            btRegister.Name = "btRegister";
            btRegister.Size = new Size(75, 23);
            btRegister.TabIndex = 3;
            btRegister.Text = "Register";
            btRegister.UseVisualStyleBackColor = true;
            btRegister.Click += btRegister_Click;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(181, 88);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(100, 23);
            tbPassword.TabIndex = 2;
            // 
            // tbUser
            // 
            tbUser.Location = new Point(181, 54);
            tbUser.Name = "tbUser";
            tbUser.Size = new Size(100, 23);
            tbUser.TabIndex = 1;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(68, 87);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(57, 15);
            lbPassword.TabIndex = 1;
            lbPassword.Text = "Password";
            // 
            // lbUser
            // 
            lbUser.AutoSize = true;
            lbUser.Location = new Point(68, 62);
            lbUser.Name = "lbUser";
            lbUser.Size = new Size(30, 15);
            lbUser.TabIndex = 0;
            lbUser.Text = "User";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gbRegister);
            Name = "RegisterForm";
            Text = "RegisterForm";
            gbRegister.ResumeLayout(false);
            gbRegister.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbRegister;
        private Button btRegister;
        private MaskedTextBox tbPassword;
        private TextBox tbUser;
        private Label lbPassword;
        private Label lbUser;
    }
}
