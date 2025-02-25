using students_prepods.MainPage.Viewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students_prepods.MainPage.Presenter
{
    internal class PresenterMain
    {
        private readonly Model.ModelMain _modelMain=new Model.ModelMain();
        private readonly Viewer.IviewerMain _viewerMain;
        private string id;
        private bool isAdmin;
        private string lastName;
        private string firstName;
        private string subject;
        public PresenterMain(IviewerMain iviewerMain,string ID,bool isAdmin) 
        { 
            _viewerMain = iviewerMain;
            _viewerMain.btnCellStr += OnCellBtnClicked;
            _viewerMain.btnDelete += OnDeleteBtnClicked;
            _viewerMain.btnUpdate += ObUpdateBtnClicked;
            _viewerMain.SearchText += OnSearchText;
            id=ID;
            this.isAdmin=isAdmin;


            LoadData();
        }

        private void OnSearchText(object? sender, string e)
        {
            if (!string.IsNullOrWhiteSpace(e))
            {
                DataTable filteredTable = _modelMain.SearchByLastName(e,isAdmin,id);
                _viewerMain.LoadData(filteredTable);
            }
            else
            {
                LoadData(); 
            }
        }

        private void ObUpdateBtnClicked(object? sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(_viewerMain.mark))
            {
                _modelMain.UpdateMark(lastName,firstName,subject, _viewerMain.mark);
            }
            LoadData();
        }

        private void OnDeleteBtnClicked(object? sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(_viewerMain.mark))
            {
                _modelMain.DeleteMark(lastName, firstName, subject, _viewerMain.mark);
            }    
        }

        private void OnCellBtnClicked(object? sender, EventArgs e)
        {
            if (sender is DataGridView dataGrid && dataGrid.CurrentRow != null)
            {
                var selectedRow = dataGrid.CurrentRow;
                if (selectedRow.Cells["mark"].Value != null)
                {
                    _viewerMain.mark = selectedRow.Cells["mark"].Value.ToString();
                }
                if (selectedRow.Cells["first_name"].Value != null)
                {
                    firstName = selectedRow.Cells["first_name"].Value.ToString();
                }
                if (selectedRow.Cells["last_name"].Value != null)
                {
                    lastName = selectedRow.Cells["last_name"].Value.ToString();
                }
                if (selectedRow.Cells["field_name"].Value != null)
                {
                    subject = selectedRow.Cells["field_name"].Value.ToString();
                }
            }
        }
        private void LoadData()
        {
            DataTable dataTable;
            if (isAdmin)
            {
                dataTable=_modelMain.PrepodTake(id);
            }
            else
            {
                dataTable=_modelMain.StudentTake(id);
            }
            _viewerMain.LoadData(dataTable);
        }
    }
}
