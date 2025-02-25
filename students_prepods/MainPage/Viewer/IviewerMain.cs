using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students_prepods.MainPage.Viewer
{
    public interface IviewerMain
    {
        public event EventHandler btnUpdate;
        public event EventHandler btnDelete;
        public string mark { get; set; }
        public event EventHandler btnCellStr;
        public event EventHandler LoadMark;
        public void LoadData(DataTable table);
        public event EventHandler<string> SearchText;
    }
}
