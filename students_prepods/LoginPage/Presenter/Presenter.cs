using System;
using System.Windows.Forms;
using students_prepods.DataBase;
using students_prepods.LoginPage.Model;
using students_prepods.LoginPage.Viewer;

namespace students_prepods.LoginPage.Presenter
{
    public class Presenter
    {
        private readonly Model.Model _model = new Model.Model();
        private readonly IViewer _view;

        public Presenter(IViewer viewer)
        {
            _view = viewer;
            viewer.btnLogin += OnLoginBtnClicked;
        }

        private void OnLoginBtnClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.LoginID) || string.IsNullOrWhiteSpace(_view.Password))
                {
                    MessageBox.Show("Введите корректные данные", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (_model.CheckProfessor(_view.LoginID, _view.Password))
                {
                    _view.NavigateToMainPage(_view.LoginID, true);
                }
                else if (_model.CheckStudent(_view.LoginID, _view.Password))
                {
                    _view.NavigateToMainPage(_view.LoginID, false);
                }
                else
                {
                    MessageBox.Show("Неверные данные для входа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                DataReader reader = DataReader.Instance();
                Console.WriteLine(reader.connectionStringJunior);
                MessageBox.Show($"Ошибка соединения с базой данных:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
