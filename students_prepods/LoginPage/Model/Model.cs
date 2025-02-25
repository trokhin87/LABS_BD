using System;
using Npgsql;
using students_prepods.DataBase;

namespace students_prepods.LoginPage.Model
{
    public class Model
    {
        private readonly DataReader reader = DataReader.Instance();

        public bool CheckProfessor(string id, string pass)
        {
            try
            {
                using var connection = new NpgsqlConnection(reader.connectionStringAdmin);
                connection.Open();
                string query = "SELECT COUNT(1) FROM professors WHERE professor_id=@login AND last_name=@pass";
                using var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("login", int.Parse(id));
                command.Parameters.AddWithValue("pass", pass);
                var result = command.ExecuteScalar();
                return Convert.ToInt32(result) > 0;
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Ошибка соединения с базой данных: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Произошла неизвестная ошибка: " + ex.Message, ex);
            }
        }

        public bool CheckStudent(string id, string pass)
        {
            try
            {
                using var connection = new NpgsqlConnection(reader.connectionStringJunior);
                connection.Open();
                string query = "SELECT COUNT(1) FROM students WHERE student_id=@login AND last_name=@pass";
                using var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("login", int.Parse(id));
                command.Parameters.AddWithValue("pass", pass);
                var result = command.ExecuteScalar();
                return Convert.ToInt32(result) > 0;
            }
            catch (FormatException)
            {
                throw new ArgumentException("Некорректный формат ID студента");
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Ошибка соединения с базой данных: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Произошла неизвестная ошибка: " + ex.Message, ex);
            }
        }
    }
}
