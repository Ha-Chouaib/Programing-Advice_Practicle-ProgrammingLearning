using System.Net.Http.Json;

namespace RESTfulAPI_ClientSideCode
{
     class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
       


        static async Task Main(string[] args)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7010/api/Students/");
           

            await GetAllStudents();
            await  GetPassedStudents();
            await GetAverageGrade();
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
                Console.WriteLine("\nFetching AVerage Grade.\n");
                var AVG = await httpClient.GetFromJsonAsync<List<Student>>("AVG");

                Console.WriteLine($"Average Grade: {AVG}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            } 
        }
    }
}
