using ThermoReg.Data;

namespace ThermoReg
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            DataBase.Init();
            if (DataBase.Data.Users.Count == 0)
            {
                Application.Run(new RegisterForm());
            }
            else
            {
                Application.Run(new LoginForm());
            }
        }
    }
}
