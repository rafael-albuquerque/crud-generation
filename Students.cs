using APIRafael.Models;
using MySqlConnector;

namespace APIRafael
{
    public static class Students
    {
        private static string connectionString = "server=localhost;user=root;database=banco;password=teste";

        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM alunos";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2),
                            FirstSemesterGrade = reader.GetInt32(3),
                            SecondSemesterGrade = reader.GetInt32(4),
                            ProfessorName = reader.GetString(5),
                            RoomNumber = reader.GetInt32(6)
                        });
                    }
                }
            }
            return students;
        }
        public static Student AddStudent(Student student)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO alunos (nome, idade, nota_1, nota_2, professor, sala) VALUES (@name, @age, @firstSemesterGrade, @secondSemesterGrade, @professorName, @roomNumber)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", student.Name);
                command.Parameters.AddWithValue("@age", student.Age);
                command.Parameters.AddWithValue("@firstSemesterGrade", student.FirstSemesterGrade);
                command.Parameters.AddWithValue("@secondSemesterGrade", student.SecondSemesterGrade);
                command.Parameters.AddWithValue("@professorName", student.ProfessorName);
                command.Parameters.AddWithValue("@roomNumber", student.RoomNumber);
                command.ExecuteNonQuery();
            }
            return student;
        }


        public static Student UpdateStudent(int id, Student student)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE alunos SET nome = @name, idade = @age, nota_1 = @firstSemesterGrade, nota_2 = @secondSemesterGrade, professor = @professorName, sala = @roomNumber WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", student.Name);
                command.Parameters.AddWithValue("@age", student.Age);
                command.Parameters.AddWithValue("@firstSemesterGrade", student.FirstSemesterGrade);
                command.Parameters.AddWithValue("@secondSemesterGrade", student.SecondSemesterGrade);
                command.Parameters.AddWithValue("@professorName", student.ProfessorName);
                command.Parameters.AddWithValue("@roomNumber", student.RoomNumber);
                command.ExecuteNonQuery();
            }
            return student;
        }
        
        public static bool DeleteStudent(int id)
        {
            var success = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"DELETE FROM alunos WHERE id = {id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                success = true;
            }
            return success;
        }
    }
}
