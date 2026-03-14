using _02_StudentsAPI.Models;

namespace _02_StudentsAPI.DataSimulation
{
    public class StudentData
    {

        public static readonly List<Student> StudentsList = new List<Student>
        {
            new Student{Id = 1, Name ="Ahmed",Age= 30, Grade =30},
            new Student{Id = 2, Name ="Hind",Age= 22, Grade = 70},
            new Student{Id = 3, Name ="Mobarak",Age= 19, Grade =90},
            new Student{Id = 4, Name ="Lahsen",Age= 26, Grade =10},
            new Student{Id = 5, Name ="Kamal",Age=23, Grade =80}
        };
    }
}
