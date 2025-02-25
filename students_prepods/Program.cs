namespace students_prepods
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
            var form = new LoginPage.Viewer.LoginForm();
            var presenter=new LoginPage.Presenter.Presenter(form);
            Application.Run(form);
        }
    }
}