using System.Text.RegularExpressions;
using ThermoReg.Data;
using ThermoReg.Data.Model;
using ThermoReg.Utils;

namespace ThermoReg
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            var userName = tbUser.Text.Trim();
            if (!Regex.IsMatch(userName, @"^\w{3,}$"))
            {
                MessageBox.Show("Username can only contain letters, numbers and _ symbol and must be at least 3 charcaters long");
            }

            var password = tbPassword.Text.Trim();
            if (password.Length < 3)
            {
                MessageBox.Show("Password must be at least 3 characters long");
            }

            string passwordHash = Password.HashPassword(password);
            DataBase.Data.Users.Add(new User { Name = userName, PasswordHash = passwordHash });
            DataBase.Save();

            Hide();

            (new LoginForm()).Show();
        }
    }
}
