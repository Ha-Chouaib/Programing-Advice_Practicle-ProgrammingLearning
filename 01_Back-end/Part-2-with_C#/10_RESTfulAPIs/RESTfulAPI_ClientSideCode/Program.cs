using System.Net.Http.Json;

namespace RESTfulAPI_ClientSideCode
{
     class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static Student NewStudent = new Student
        {
            Name = "Chouaib Hadadi",
            Age = 23,
            Grade = 95
        };

        static async Task Main(string[] args)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7010/api/Students/");
           

            await GetAllStudents();
            await GetPassedStudents();
            await GetAverageGrade();
            await GetStudentByID(1);
            // await GetStudentByID(-1);
            //await GetStudentByID(100);
            await AddNewStudent(NewStudent);
            await GetAllStudents();

        }

        static async Task GetAllStudents()
        {

            try
            {
                Console.WriteLine("\n__________________________________________________");
                Console.WriteLine("\nFetching All Students...\n");
                var Students = await httpClient.GetFromJsonAsync<List<Student>>("All");

                if (Students != null)
                {
                    foreach (var s in Students) Console.WriteLine($"ID:{s.Id} | Name:{s.Name} | Age:{s.Age} | Grade:{s.Grade}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static async Task GetPassedStudents()
        {
            try
            {
                Console.WriteLine("\n\n__________________________________________________");
                Console.WriteLine("\nFetching Passed Students...\n");
                var Students = await httpClient.GetFromJsonAsync<List<Student>>("Passed");

                if (Students != null)
                {
                    foreach (var s in Students) Console.WriteLine($"ID:{s.Id} | Name:{s.Name} | Age:{s.Age} | Grade:{s.Grade}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    
        static async Task GetAverageGrade()
        {
            try
            {
                Console.WriteLine("\n\n__________________________________________________");
                Console.WriteLine("\nFetching Average Grade...\n");
                var AVG = await httpClient.GetFromJsonAsync<double>("AVG");

                Console.WriteLine($"Average Grade: {AVG}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            } 
        }
        
        static async Task GetStudentByID(int ID)
        {
            try
            {
                Console.WriteLine("\n\n__________________________________________________");
                Console.WriteLine($"\nFetching Student By ID {ID}...\n");
                var s = await httpClient.GetFromJsonAsync<Student>($"{ID}");

                Console.WriteLine($"ID:{s.Id} | Name:{s.Name} | Age:{s.Age} | Grade:{s.Grade}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        
        static async Task AddNewStudent(Student student)
        {
            try
            {
                Console.WriteLine("\n\n__________________________________________________");
                Console.WriteLine($"\nAdding a Student ..\n");
                var response = await httpClient.PostAsJsonAsync<Student>("",student);

                if(response.IsSuccessStatusCode)
                {
                    var addedStudent = await response.Content.ReadFromJsonAsync<Student>();
                    Console.WriteLine($"Added Student - ID: {addedStudent.Id}, Name: {addedStudent.Name}, Age: {addedStudent.Age}, Grade: {addedStudent.Grade}");

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine("Bad Request: Invalid student data.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        
        
    }
}
