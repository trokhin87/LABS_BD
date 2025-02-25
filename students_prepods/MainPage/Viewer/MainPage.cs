using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace students_prepods.MainPage.Viewer
{
    public partial class MainPage : Form,IviewerMain
    {
        private bool isAdmin;
        public MainPage(bool isAdmin)
        {
            InitializeComponent();
            update.Click += (s, e) => btnUpdate?.Invoke(dataTableMark, e);
            delete.Click += (s, e) => btnDelete?.Invoke(dataTableMark, e);
            dataTableMark.SelectionChanged += (s, e) => btnCellStr?.Invoke(dataTableMark, e);
            this.isAdmin = isAdmin;
            TextSearch.TextChanged += (s,e) => SearchText?.Invoke(s, TextSearch.Text);
            SetVisible(isAdmin);

            LoadMark?.Invoke(this, EventArgs.Empty);
        }


        public string mark { get => TextMark.Text; set => TextMark.Text=value; }

        public event EventHandler btnUpdate;
        public event EventHandler btnDelete;
        public event EventHandler btnCellStr;
        public event EventHandler LoadMark;
        public event EventHandler<string> SearchText;
        public void SetVisible(bool isAdmin)
        {
            update.Visible = isAdmin;
            delete.Visible = isAdmin;
            TextMark.Visible = isAdmin;
            TextSearch.Visible = isAdmin;
        }
        public void LoadData(DataTable table)
        {
            dataTableMark.DataSource = table;
        }


    }
}
