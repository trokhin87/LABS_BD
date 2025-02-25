using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace students_prepods.LoginPage.Viewer
{
    public partial class LoginForm : Form, IViewer
    {
        public LoginForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => btnLogin?.Invoke(this, EventArgs.Empty);
        }

        public string LoginID { get => textID.Text; set => textID.Text=value; }
        public string Password { get => TextPass.Text; set => TextPass.Text=value; }

        public event EventHandler btnLogin;

        public void NavigateToMainPage(string ID, bool isAdmin)
        {
            var MainPage=new MainPage.Viewer.MainPage(isAdmin);
            var PresenterMain = new MainPage.Presenter.PresenterMain(MainPage,ID,isAdmin);
            MainPage.Show();
            this.Hide();
        }
    }
}
