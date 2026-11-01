using ThermoReg.Data;
using ThermoReg.UI;
using ThermoReg.Utils;

namespace ThermoReg
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Load += new EventHandler(this.OnLoad);
            Resize += new EventHandler(this.OnResize);
        }

        void OnLoad(object? sender, EventArgs args)
        {
            CalculateLayout();
        }

        void OnResize(object? sender, EventArgs args)
        {
            CalculateLayout();
        }

        private void CalculateLayout()
        {
            gbLoginForm.Location = new Point(
                (Width - gbLoginForm.Width) / 2,
                (Height - gbLoginForm.Height) / 2 - (int)gbLoginForm.Font.Size * 2);

            lbUser.Location = new Point(20, 20);
            tbUser.Location = new Point(lbUser.Location.X + Math.Max(lbUser.Width, lbPassword.Width) + 20, lbUser.Location.Y);
            tbUser.Width = 200;

            lbPassword.Location = new Point(lbUser.Location.X, lbUser.Location.Y + lbUser.Height + 20);
            tbPassword.Location = new Point(tbUser.Location.X, lbPassword.Location.Y);
            tbPassword.Width = tbUser.Width;
            tbPassword.UseSystemPasswordChar = true;

            btLogin.Location = new Point(
                tbPassword.Location.X + tbPassword.Width - btLogin.Width,
                tbPassword.Location.Y + btLogin.Height + 20);
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            var userName = tbUser.Text.Trim();
            var password = tbPassword.Text.Trim();

            var user = DataBase.Data.Users.Find(u => u.Name == userName);
            if (user == null)
            {
                MessageBox.Show("Wrong credentials");
                return;
            }

            if (!Password.VerifyPassword(password, user.PasswordHash))
            {
                MessageBox.Show("Wrong credentials");
                return;
            }

            Hide();
            (new DashboardForm()).Show();
        }
    }
}
