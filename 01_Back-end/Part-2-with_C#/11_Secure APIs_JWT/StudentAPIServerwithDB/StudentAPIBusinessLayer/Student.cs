using System.Data;
using StudentDataAccessLayer;

namespace StudentAPIBusinessLayer
{
    // Remember the original passwords for the following students:
    //            new { Id = 2, Name = "Salma", Password = "Admin1" },
    //            new { Id = 3, Name = "Maher Khalid", Password = "password2" },
    //            new { Id = 4, Name = "Suha Hadid", Password = "password3" },
    //            new { Id = 5, Name = "loay", Password = "password4" },
    //            new { Id = 6, Name = "Huda", Password = "password5" },
    //            new { Id = 7, Name = "Majida", Password = "password6" },
    //            new { Id = 8, Name = "Majda 3", Password = "password7" },
    //            new { Id = 11, Name = "Mazen Abdullah", Password = "Admin2" },
    public class Student
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public StudentDTO SDTO {
            get { return (new StudentDTO(this.ID, this.Name, this.Age, this.Grade, this.Email, this.PasswordHash,this.Role)); }
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }


        public Student(StudentDTO SDTO, enMode cMode =enMode.AddNew )

        {
            this.ID = SDTO.Id ;
            this.Name =SDTO.Name; 
            this.Age =SDTO.Age;
            this.Grade = SDTO.Grade;
            this.Email = SDTO.Email;
            this.PasswordHash = SDTO.PasswordHash;
            this.Role = SDTO.Role;
            Mode = cMode;
        }

        private bool _AddNewStudent()
        {
            //call DataAccess Layer 

            this.ID = StudentData.AddStudent(SDTO);

            return (this.ID != -1);
        }

        private bool _UpdateStudent()
        {
            return StudentData.UpdateStudent(SDTO);
        }

        public static List<StudentDTO> GetAllStudents()
        {
            return StudentData.GetAllStudents();
        }


        public static List<StudentDTO> GetPassedStudents()
        {
            return StudentData.GetPassedStudents();
        }

        public static double GetAverageGrade()
        {
            return StudentData.GetAverageGrade();
        }

        public static Student? Find(string email)
        {
            StudentDTO? SDTO = StudentData.GetStudentByEmail(email);
            if (SDTO != null)
                
                return new Student(SDTO, enMode.Update);
            else
                return null;
        }
        public static Student? Find(int ID)
            {  

               StudentDTO? SDTO = StudentData.GetStudentById(ID);

            if (SDTO != null)
            //we return new object of that student with the right data
            {
                
                return new Student(SDTO, enMode.Update);
            }
            else
                return null;
            }

            public bool Save()
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewStudent())
                        {

                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateStudent();

                }

                return false;
            }

            public static bool DeleteStudent(int ID)
            {
                return StudentData.DeleteStudent(ID);
            }

        }
    }

