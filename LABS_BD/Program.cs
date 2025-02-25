using LABS_BD.DataBase;
using Npgsql;

namespace LABS_BD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите id студента, чтобы узнать в какой он группе");
                string input = Console.ReadLine();
                DetecInjection(input);
                GetStudentGroup(input);
                GetStudentGroupView(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void GetStudentGroup(string input)
        {
            DataReader data = DataReader.Instance();
            using (var connection = new NpgsqlConnection(data.connectionString))
            {
                connection.Open();
                string query = "SELECT student_id,students_group_number FROM students WHERE student_id=@student_id";
                using (var cmd=new NpgsqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("student_id", int.Parse(input));
                    using (var reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["student_id"]}: {reader["students_group_number"]}");
                        }
                    }
                }
            }
        }
        //student_num_group
        public static void DetecInjection(string input)
        {
            string[] blacklist = { "--", ";--", ";", "/*", "*/", "@@", "@","\'" };
            if(blacklist.Any(s => input.Contains(s)))
            {
                throw new Exception("Давай не балуйся");
            }
        }
        public static void GetStudentGroupView(string input)
        {
            DataReader data = DataReader.Instance();
            using (var connection = new NpgsqlConnection(data.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM student_num_group WHERE student_id=@student_id";
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("student_id", int.Parse(input));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["student_id"]}: {reader["students_group_number"]}");
                        }
                    }
                }
            }
        }
    }
}
