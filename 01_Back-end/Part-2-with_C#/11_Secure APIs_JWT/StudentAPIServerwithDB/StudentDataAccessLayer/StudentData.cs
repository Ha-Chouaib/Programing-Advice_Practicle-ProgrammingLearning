using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace StudentDataAccessLayer
{
    public class StudentDTO
    {
        public StudentDTO(int id, string name, int age, int grade, string email, string Passwordhash,string role)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
            this.Email = email;
            this.PasswordHash = Passwordhash;
            this.Role = role;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }


    }

    public class StudentData
    {
        static string _connectionString = "Server=localhost;Database=StudentsDB;User Id=sa;Password=sa123456;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";

        public static List<StudentDTO> GetAllStudents()
        {
            var StudentsList = new List<StudentDTO>();
           try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllStudents", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentsList.Add(new StudentDTO
                                (
                                    reader.GetInt32(reader.GetOrdinal("Id")),
                                    reader.GetString(reader.GetOrdinal("Name")),
                                    reader.GetInt32(reader.GetOrdinal("Age")),
                                    reader.GetInt32(reader.GetOrdinal("Grade")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    reader.GetString(reader.GetOrdinal("Role"))

                                ));
                            }
                        }
                    }


                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"DAL GetAllStudents() -> SQL Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error GetAllStudents(): {ex.Message}");
            }   
           return StudentsList;

        }
        public static List<StudentDTO> GetPassedStudents()
        {
            var StudentsList = new List<StudentDTO>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetPassedStudents", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentsList.Add(new StudentDTO
                                (
                                    reader.GetInt32(reader.GetOrdinal("Id")),
                                    reader.GetString(reader.GetOrdinal("Name")),
                                    reader.GetInt32(reader.GetOrdinal("Age")),
                                    reader.GetInt32(reader.GetOrdinal("Grade")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    reader.GetString(reader.GetOrdinal("Role"))
                                ));
                            }
                        }
                    }

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"DAL GetPassedStudents() -> SQL Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error GetPassedStudents(): {ex.Message}");
            }

           return StudentsList;

        }
        public static double GetAverageGrade()
        {
            double averageGrade = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAverageGrade", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();

                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            averageGrade = Convert.ToDouble(result);
                        }
                        else
                            averageGrade = 0;

                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"DAL GetAverageGrade() -> SQL Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error GetAverageGrade(): {ex.Message}");
            }
           
            return averageGrade;
        }
        public static StudentDTO? GetStudentById(int studentId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("SP_GetStudentById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StudentDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("Id")),
                                reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetInt32(reader.GetOrdinal("Age")),
                                reader.GetInt32(reader.GetOrdinal("Grade")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetString(reader.GetOrdinal("PasswordHash")),
                                reader.GetString(reader.GetOrdinal("Role"))
                            );
                        }
                        
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"DAL Add Student -> SQL Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving student by ID: {ex.Message}");
            }
            return null;
        }
        
        public static StudentDTO? GetStudentByEmail(string email)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("SP_GetStudentByEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StudentDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("Id")),
                                reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetInt32(reader.GetOrdinal("Age")),
                                reader.GetInt32(reader.GetOrdinal("Grade")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetString(reader.GetOrdinal("PasswordHash")),
                                reader.GetString(reader.GetOrdinal("Role"))
                            );
                        }
                        
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"DAL GetStudentByEmail() -> SQL Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving student by email: {ex.Message}");
            }
            return null;
        }
        public static int AddStudent(StudentDTO StudentDTO)
        {
            int id = -1;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("SP_AddStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", StudentDTO.Name);
                    command.Parameters.AddWithValue("@Age", StudentDTO.Age);
                    command.Parameters.AddWithValue("@Grade", StudentDTO.Grade);
                    command.Parameters.AddWithValue("@Email", StudentDTO.Email);
                    command.Parameters.AddWithValue("@PasswordHash", StudentDTO.PasswordHash);
                    command.Parameters.AddWithValue("@Role", StudentDTO.Role);

                    var outputIdParam = new SqlParameter("@NewStudentId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    connection.Open();
                    command.ExecuteNonQuery();

                    id = (int)outputIdParam.Value;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"DAL Add Student -> SQL Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DAL Error adding student: {ex.Message}");
            }
           return id;
        }
        public static bool UpdateStudent(StudentDTO StudentDTO)
        {
            bool success = false;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("SP_UpdateStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@StudentId", StudentDTO.Id);
                    command.Parameters.AddWithValue("@Name", StudentDTO.Name);
                    command.Parameters.AddWithValue("@Age", StudentDTO.Age);
                    command.Parameters.AddWithValue("@Grade", StudentDTO.Grade);
                    command.Parameters.AddWithValue("@Email", StudentDTO.Email);
                    command.Parameters.AddWithValue("@PasswordHash", StudentDTO.PasswordHash);
                    command.Parameters.AddWithValue("@Role", StudentDTO.Role);
                    connection.Open();
                    command.ExecuteNonQuery();
                    int rowsAffected = (int)command.ExecuteNonQuery();
                    success = (rowsAffected == 1);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"DAL Update Student -> SQL Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DAL Error updating student: {ex.Message}");
            }
            return success;  
        } 
        public static bool DeleteStudent(int studentId)
        {

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SP_DeleteStudent", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentId", studentId);

                connection.Open();

                int rowsAffected = (int)command.ExecuteNonQuery();
                return (rowsAffected==1);


            }
        }
    }
}
