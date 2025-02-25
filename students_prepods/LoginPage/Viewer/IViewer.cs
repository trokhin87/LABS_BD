using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students_prepods.LoginPage.Viewer
{
    public interface IViewer
    {
        public event EventHandler btnLogin;
        public string LoginID { get; set; }
        public string Password { get; set; }
        public void NavigateToMainPage(string ID,bool isAdmin);
    }
}
