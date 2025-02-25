using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using students_prepods.DataBase;
namespace students_prepods.MainPage.Model
{
    internal class ModelMain
    {
        public DataTable PrepodTake(string id)
        {
            DataBase.DataReader data = DataReader.Instance();
            string connect = data.connectionStringAdmin;
            string query = @"SELECT st.last_name, st.first_name, f.field_name, fc.mark 
                     FROM students st
                     JOIN field_comprehensions fc ON fc.student_id = st.student_id 
                     JOIN fields f ON f.field_id = fc.field 
                     JOIN professors p ON p.professor_id = f.professor_id 
                     WHERE p.professor_id = @id";

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connect))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", int.Parse(id));       
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            return table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки данных");
                return null;
            }
        }

        public DataTable StudentTake(string id)
        {
            DataBase.DataReader data = DataReader.Instance();
            string connect = data.connectionStringJunior;
            string query = @"SELECT f.field_name, fc.mark, s.last_name, s.first_name
                     FROM field_comprehensions fc 
                     JOIN fields f ON f.field_id = fc.field 
                     Join students s On s.student_id=fc.student_id
                     WHERE fc.student_id = @id";

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connect))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", int.Parse(id));
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            return table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки данных");
                return null;
            }
        }
        public DataTable SearchByLastName(string name, bool isAdmin,string id)
        {
            DataTable dataTable;
            if (isAdmin)
            {
                dataTable = PrepodTake(id);
            }
            else
            {
                dataTable = StudentTake(id);
            }

            var filteredRows = dataTable.AsEnumerable()
                .Where(row => row["last_name"].ToString().StartsWith(name, StringComparison.OrdinalIgnoreCase));

            return filteredRows.Any() ? filteredRows.CopyToDataTable() : dataTable.Clone();
        }  
        public void UpdateMark(string last_name,string first_name, string subject, string mark)  
        {
            DataBase.DataReader dataReader = DataReader.Instance();
            var connect = dataReader.connectionStringAdmin;
            try
            {
                using var connection = new NpgsqlConnection(connect);
                connection.Open();
                string query_update = "UPDATE field_comprehensions " +
                    "SET mark = @mark " +
                    "WHERE student_id = ( " +
                    "SELECT student_id FROM students WHERE last_name = @last_name AND first_name = @first_name LIMIT 1 " +
                    ") " +
                    "AND field = ( " +
                    "    SELECT field_id FROM fields WHERE field_name = @field_name LIMIT 1" +
                    "); ";
                using var command_add = new NpgsqlCommand(query_update, connection);
                command_add.Parameters.AddWithValue("@mark", int.Parse(mark));
                command_add.Parameters.AddWithValue("@last_name", last_name);
                command_add.Parameters.AddWithValue("@first_name", first_name);
                command_add.Parameters.AddWithValue("@field_name", subject);
                command_add.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось  данные в Бд", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DeleteMark(string last_name, string first_name, string subject, string mark)
        {
            DataBase.DataReader dataReader = DataReader.Instance();
            var connect = dataReader.connectionStringAdmin;
            try
            {
                using var connection = new NpgsqlConnection(connect);
                connection.Open();
                string query_delete = @"
                    DELETE FROM field_comprehensions 
                    WHERE student_id IN (
                        SELECT student_id FROM students WHERE last_name = @last_name AND first_name = @first_name
                    ) 
                    AND field IN (
                        SELECT field_id FROM fields WHERE field_name = @field_name
                    );";
                using var command_add = new NpgsqlCommand(query_delete, connection);
                command_add.Parameters.AddWithValue("@mark", int.Parse(mark));
                command_add.Parameters.AddWithValue("@last_name", last_name);
                command_add.Parameters.AddWithValue("@first_name", first_name);
                command_add.Parameters.AddWithValue("@field_name", subject);
                command_add.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось  данные в Бд", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    