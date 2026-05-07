
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using  _01_TrainingCenter.Data;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Query;
using _01_TrainingCenter.Entities;


//Build Configuration
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string?  connectionString = configuration.GetConnectionString("DefaultConnection");
if(string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("Connection string is not found.");
    return;
}

//Configure EF Core

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information) // Log SQL queries to the console
    .EnableSensitiveDataLogging()// Include parameter values in logs (use with caution in production)
    .Options;
//Create DbContext instance
using var context = new AppDbContext(options);

//test connection

Console.WriteLine("Testing database connection...");
Console.WriteLine(context.Database.CanConnect() ? "Connection successful!" : "Connection failed.");


//=================================Execute Methods

//RetrieveAndDisplayStudents(context);
//GetActiveStudentsCount(context);
//GetActiveStudents(context);

//Exemple_First(context);
//Exemple_FirstOrDefault(context);
//Exemple_Single(context);
//Exemple_SingleOrDefault(context);


//GetStudentByIDUsing_Find(context, 1);
//GetStudentByIDUsing_Find(context, 1);// The second call will demonstrate the caching behavior of Find().
//GetStudentByIDUsing_FirstOrDefault(context, 1);


//GetActiveStudentsNames(context);//Projection -> Select

//GetFilteredStudents(context);//Chaining Multiple LINQ Methods At One Query

//CheckStudentExistence(context);//Check Existence of Records with Any() and All()

//GetActiveStudentsCountWithAggregate(context);//Aggregate Functions (Count, Sum, Average, Min, Max)
//GetAverageStudentAge(context);
//GetMinMaxStudentAge(context);
//GetTotalCourseDuration(context);


//GetDistinctStudentStatuses(context);//Distinct()
//GetStudentsPerStatusReport(context);//GroupBy()

//GetStatusesWithMoreThanXStudents(context, 6);//GroupBy() with HAVING-like filter

//CompareApproaches(context);//N+1 Problem Demonstration vs Include() vs Projection

//ShowStudentsWithEnrollmentsAndCourses(context);

//ShowCourseReport(context);//Join() = Inner Join In DB, you can pick nedded Fields Only

//ShowStudentsWithProfiles(context);//LeftJoin() -> Keep Left side Records And Get Only Matching Records from Right side

//ShowStudentEnrollments(context);//SelectMany() for Flattening Collections

//ShowExpensiveCourses(context);//Subqueries and Nested Queries

//ComparePagination(context);//Pagination with Skip() and Take()

CompareTracking(context);// AsNotracking() vs normal tracking way for readOnly Records





//----------------------------------------------

//=================================Method Definitions ====================================
static void RetrieveAndDisplayStudents(AppDbContext context)
{
    var Query = context.Students.OrderBy(s => s.StudentId);

    // Display the generated SQL query
    PrintGeneratedSql("Students",Query.ToQueryString());

    var students = Query.ToList();
    
    if(students.Count == 0)
    {
        Console.WriteLine("No students found.\n");
        return;
    }

    Console.WriteLine("Students List:");
    Console.WriteLine("--------------");

    foreach (var student in students)
    {
        Console.WriteLine($"ID: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Email: {student.Email}");
    }
     Console.WriteLine();
    Console.WriteLine("Total Students: " + students.Count);
    Console.WriteLine(new string('=', 40));//this will print a line of 40 dashes to separate the output
    Console.WriteLine();

}

//This Method Shows that ToQueryString() Not Always Reflects Final SQL for Count() and similar aggregate methods, as they generate different SQL than the initial SELECT query.
static void GetActiveStudentsCount( AppDbContext context)
{
    Console.WriteLine("Example 2 - Count Comparison");
    Console.WriteLine("============================");
    Console.WriteLine();


    // Build query first
    var query = context.Students
        .Where(s => s.Status == "Active");


    // Preview SQL before Count()
    Console.WriteLine("Preview SQL using ToQueryString():");
    Console.WriteLine("----------------------------------");
    Console.WriteLine(query.ToQueryString());
    Console.WriteLine();


    Console.WriteLine(
        "Now executing Count()...");
    Console.WriteLine(
        "Watch logging output above / below.");
    Console.WriteLine();


    // Actual execution
    int total = query.Count();


    Console.WriteLine(
        $"Total Active Students: {total}");


    Console.WriteLine();
    Console.WriteLine(
        "Important Note:");
    Console.WriteLine(
        "ToQueryString() previewed SELECT rows query.");
    Console.WriteLine(
        "But logging shows final executed COUNT(*) query.");


    Console.WriteLine();
    Console.WriteLine(new string('=', 70));
    Console.WriteLine();
}


// Here we Use Where() to filter results In DB then retrieve just needed data with ToList() and display it.
// This is more efficient than retrieving all students and filtering in memory.
static void GetActiveStudents( AppDbContext context)
{
    var Query = context.Students.Where(s => s.Status == "Active").OrderBy(s => s.StudentId);

    PrintGeneratedSql("Active Students", Query.ToQueryString());

    Console.WriteLine("Active Students List:"); Console.WriteLine();
    var activeStudents = Query.ToList();
    foreach(var student in activeStudents)
    {
        Console.WriteLine($"ID: {student.StudentId}," +
            $" Name: {student.FirstName} {student.LastName}," +
            $" Email: {student.Email}," +
            $" Phone: {student.PhoneNumber}," +
            $" Registered At: {student.RegisteredAt}," +
            $" Status: {student.Status}");
    }
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
    Console.WriteLine($"Total Active Students: {activeStudents.Count}");
    Console.WriteLine();
}


//##---- Retrive Single Records Exemples --------
static void Exemple_First( AppDbContext context)// This will [ throw an exception ] if no active students are found.And Ignnore If There duplicates exist, it will return the first one based on the order specified.
{
    Console.WriteLine("\nExample - Get The Top 1 Record by [ First() ]");

    var Query = context.Students.Where(s => s.Status == "Active");
    
    PrintGeneratedSql("First Active Student", Query.ToQueryString());

    try
    {
        var student = Query.First();
        Console.WriteLine("First Active Student:");
        Console.WriteLine();
        Console.WriteLine($"ID: {student.StudentId}," +
            $" Name: {student.FirstName} {student.LastName}," +
            $" Email: {student.Email}," +
            $" Phone: {student.PhoneNumber}," +
            $" Registered At: {student.RegisteredAt}," +
            $" Status: {student.Status}");
        Console.WriteLine();
        Console.WriteLine(new string('=', 45));

    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("Error: " + ex.Message);
        Console.WriteLine("This exception occurs if no active students are found");
        Console.WriteLine();
        Console.WriteLine(new string('=', 45));
        return;
    }
}
static void Exemple_FirstOrDefault( AppDbContext context)// This will return [ null ] if no students are found, And Ignnore If There duplicates exist, it will return the first one based on the order specified.
{
    Console.WriteLine("\nExample - Get The Top 1 Record by [ FirstOrDefault() ]");

    var Query = context.Students.Where(s => s.Email == "notfount@gmail.com");

    PrintGeneratedSql("Get Student By Email", Query.ToQueryString());

    var student = Query.FirstOrDefault();
    Console.WriteLine("First Student By Email: notfount@gmail.com");
    Console.WriteLine();
    if (student != null)
    {
        Console.WriteLine($"ID: {student.StudentId}," +
            $" Name: {student.FirstName} {student.LastName}," +
            $" Email: {student.Email}," +
            $" Phone: {student.PhoneNumber}," +
            $" Registered At: {student.RegisteredAt}," +
            $" Status: {student.Status}");
    }
    else
    {
        Console.WriteLine("No student found by email: notfount@gmail.com .");
    }
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
}

static void Exemple_Single( AppDbContext context)// This will [ throw an exception ] if no active students are found, or if more than one active student exists. Use this when you expect exactly one record to match the criteria.
{
    Console.WriteLine("\nExample - Get The Top 1 Record by [ Single() ]");

    var Query = context.Courses.Where(s => s.Code == "EF-101");

    PrintGeneratedSql("First Course With Code: EF-101", Query.ToQueryString());
    try
    {
        var course = Query.Single();
        Console.WriteLine("First Course With Code: EF-101");
        Console.WriteLine();
        Console.WriteLine($"ID: {course.CourseId}," +
            $" Instructor: {course.Instructor}," +
            $" Code: {course.Code}," +
            $" Description: {course.Description}," +
            $" Duration Hours: {course.DurationHours}," +
            $" Status: {course.Status}");
        Console.WriteLine();
        Console.WriteLine(new string('=', 45));

    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("Error: " + ex.Message);
        Console.WriteLine("This exception occurs if no course is found, or if more than one course exists with the same code.");
        Console.WriteLine("Use Single() when you expect exactly one record to match the criteria.");
        Console.WriteLine();
        Console.WriteLine(new string('=', 45));
        return;
    }
   

}
static void Exemple_SingleOrDefault( AppDbContext context )// This will return [ null ] if no active students are found, And [ throw an exception ] if more than one active student exists. Use this when you expect zero or one record to match the criteria.
{
    Console.WriteLine("\nExample - Get The Top 1 Record by [ SingleOrDefault() ]");

    var Query = context.Students.Where(s => s.Status == "Active").OrderBy(s => s.StudentId);

    PrintGeneratedSql("First Active Student", Query.ToQueryString());

    try
    {
        var student = Query.SingleOrDefault();

        if (student != null)
        {
            Console.WriteLine($"ID: {student.StudentId}," +
                $" Name: {student.FirstName} {student.LastName}," +
                $" Email: {student.Email}," +
                $" Phone: {student.PhoneNumber}," +
                $" Registered At: {student.RegisteredAt}," +
                $" Status: {student.Status}");
        }
        else
        {
            Console.WriteLine("No active student found.");
        }
        Console.WriteLine();
        Console.WriteLine(new string('=', 45));

    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("Error: " + ex.Message);
        Console.WriteLine("This exception occurs if more than one active student exists.");
        Console.WriteLine("Use SingleOrDefault() when you expect zero or one record to match the criteria.");
        Console.WriteLine();
        Console.WriteLine(new string('=', 45));
        return;
    }
}



//##----------------- FirstOrDefault() vs Find() Comparison -----------------

// The Find() method is optimized for retrieving entities by their primary key. It first checks the context's cache for the entity, and if not found, it queries the database.
// It does not support filtering or ordering and is more efficient for primary key lookups.
static void GetStudentByIDUsing_Find(AppDbContext context, int studentId)
{
    Console.WriteLine($"\nExample - Get Student By ID using [ Find() ] with ID: {studentId}");
    var student = context.Students.Find(studentId);
    Console.WriteLine($"Find(), does not support filtering or ordering. It only works with primary keys.");

    if (student != null)
    {
        PrintStudent(student);
    }
    else
    {
        Console.WriteLine($"No student found with ID: {studentId}");
        Console.WriteLine();
        Console.WriteLine(new string('=', 45));
    }
}

// The FirstOrDefault() method can be used to retrieve an entity based on any condition, not just the primary key.
// It supports filtering and ordering, but it is less efficient for primary key lookups compared to Find() because it always generates a query to the database.
static void GetStudentByIDUsing_FirstOrDefault(AppDbContext context, int studentId)
{
    Console.WriteLine($"\nExample - Get Student By ID using [ FirstOrDefault() ] with ID: {studentId}");
    var student = context.Students.Where(s => s.StudentId == studentId).FirstOrDefault();
    Console.WriteLine($"FirstOrDefault(), supports filtering and ordering, but is less efficient for primary key lookups compared to Find().");
    if (student != null)
    {
        PrintStudent(student);
    }
    else
    {
        Console.WriteLine($"No student found with ID: {studentId}");
        Console.WriteLine();
        Console.WriteLine(new string('=', 45));
    }
}


//##------------------ Projection->  Select() -----------------
static void GetActiveStudentsNames(AppDbContext context)
{
    Console.WriteLine("\n\nExample - Get Active Students Names using Projection with [ Select() ]");

    var Query = context.Students.Where(s => s.Status == "Active").Select(s => new { s.FirstName, s.LastName });
    
    PrintGeneratedSql("Active Students Names", Query.ToQueryString());
    Console.WriteLine("Active Students Names:");
    Console.WriteLine();
    
    var activeStudentsNames = Query.ToList();
    
    foreach (var student in activeStudentsNames)
    {
        Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
    }
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
    Console.WriteLine($"Total Active Students: {activeStudentsNames.Count}");
    Console.WriteLine();
}


//##------------------ Chaining Multiple LINQ Methods At One Query-----------------
static void GetFilteredStudents(AppDbContext context)
{
    Console.WriteLine("\n\nExample - Get Filtered Students by chaining multiple LINQ methods");
    var Query = context.Students
        .Where(s => s.Status == "Active") // Filter active students
        .Select(s => new { s.FirstName, s.LastName, s.Email }) // Project to anonymous type
        .OrderBy(s => s.LastName) // Order by last name
        .ThenBy(s => s.FirstName); // Then order by first name
       
    
    PrintGeneratedSql("Filtered Students", Query.ToQueryString());
    
    var filteredStudents = Query.ToList();
    
    Console.WriteLine("Filtered Students:");
    Console.WriteLine();
    
    foreach (var student in filteredStudents)
    {
        Console.WriteLine($"Name: {student.FirstName} {student.LastName}, Email: {student.Email}");
    }
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
    Console.WriteLine($"Total Filtered Students: {filteredStudents.Count}");
    Console.WriteLine();
}


//##------------------ Check Existence of Records with Any() + All () -----------------
static void CheckStudentExistence(AppDbContext context)
{
    Console.WriteLine("\n\nExample - Check Existence of Students using Any() and All()");

    // Any() checks if there is at least one student with Status "Active"
    bool anyActiveStudents = context.Students.Any(s => s.Status == "Active");

    // All() checks if all students have Status "Active"
    bool allActiveStudents = context.Students.All(s => s.Status == "Active");

    Console.WriteLine($"Any Active Students: {anyActiveStudents}");
    Console.WriteLine($"All Active Students: {allActiveStudents}");
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
}


//##------------------ Aggregate Functions (Count, Sum, Average, Min, Max) -----------------
static void GetActiveStudentsCountWithAggregate(AppDbContext context)
{
    Console.WriteLine("\n\nExample - Get Active Students Count using Aggregate Function [ Count() ]");
    
    int activeStudentsCount = context.Students.Count(s => s.Status == "Active");
    
    Console.WriteLine($"Total Active Students: {activeStudentsCount}");
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
}
static void GetAverageStudentAge(AppDbContext context)
{
    Console.WriteLine("\n\nExample - Get Average Student Age using Aggregate Function [ Average() ]");
    double averageAge = context.Students.Average(s => DateTime.Now.Year - s.DateOfBirth.Year);
    Console.WriteLine($"Average Student Age: {averageAge:F2} years");
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
}
static void GetMinMaxStudentAge(AppDbContext context)
{
    Console.WriteLine("\n\nExample - Get Minimum and Maximum Student Age using Aggregate Functions [ Min() and Max() ]");
    int minAge = context.Students.Min(s => DateTime.Now.Year - s.DateOfBirth.Year);
    int maxAge = context.Students.Max(s => DateTime.Now.Year - s.DateOfBirth.Year);
    Console.WriteLine($"Minimum Student Age: {minAge} years");
    Console.WriteLine($"Maximum Student Age: {maxAge} years");
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
}
static void GetTotalCourseDuration(AppDbContext context)
{
    Console.WriteLine("\n\nExample - Get Total Course Duration using Aggregate Function [ Sum() ]");
    int totalDuration = context.Courses.Where(c => c.Status == "Active").Sum(c => c.DurationHours);
    Console.WriteLine($"Total Duration of Active Courses: {totalDuration} hours");
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
}


//##------------------ Distinct() | GroupBy() -------------------------------
static void GetDistinctStudentStatuses(AppDbContext context)
{
    Console.WriteLine("\n\nExample - Get Distinct Student Statuses using [ Distinct() ]");

    var Query = context.Students.Select(s => s.Status ).Distinct();

    PrintGeneratedSql("Distinct Student Statuses", Query.ToQueryString());
    
    var distinctStatuses = Query.ToList();
    
    Console.WriteLine("Distinct Student Statuses:");
    Console.WriteLine();
    foreach (var status in distinctStatuses)
    {
        Console.WriteLine($"Status: {status}");
    }
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
}
static void GetStudentsPerStatusReport(AppDbContext context)
{
    Console.WriteLine("\n\nExample - Get Students Count Per Status using GroupBy()");
    var Query = context.Students
        .GroupBy(s => s.Status)
        .Select(g => new { Status = g.Key, Count = g.Count() });
    PrintGeneratedSql("Students Count Per Status", Query.ToQueryString());
    var report = Query.ToList();
    Console.WriteLine("Students Count Per Status:");
    Console.WriteLine();
    foreach (var item in report)
    {
        Console.WriteLine($"Status: {item.Status}, Count: {item.Count}");
    }
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
}


//##----------------- HAVING() && GROUP BY -----------------
//[Important Note]-> In EF Core, there is no direct equivalent to SQL's HAVING clause.
    //Instead, you can achieve similar results by applying a filter after the GroupBy() operation in your LINQ query.
    //This is done by using a Where() clause on the grouped results to filter groups based on aggregate conditions.
static void GetStatusesWithMoreThanXStudents(AppDbContext context, int minStudentCount)
{
    Console.WriteLine($"\n\nExample - Get Student Statuses with More Than {minStudentCount} Students using GroupBy() and a Filter (HAVING-like)");
    
    var Query = context.Students
        .GroupBy(s => s.Status)
        .Select(g => new { Status = g.Key, Count = g.Count() })
        .Where(g => g.Count > minStudentCount)
        .OrderBy(g => g.Status);
    
    PrintGeneratedSql($"Student Statuses with More Than {minStudentCount} Students", Query.ToQueryString());
    
    var result = Query.ToList();
    
    Console.WriteLine($"Student Statuses with More Than {minStudentCount} Students:");
    Console.WriteLine();
    foreach (var item in result)
    {
        Console.WriteLine($"Status: {item.Status}, Count: {item.Count}");
    }
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
}


//##---------------- N+1 Problem Demonstration vs Include() vs Projection->Select() -----------------
static void ShowBadNPlusOneApproach(AppDbContext context)
{
    Console.WriteLine("BAD APPROACH - N+1 Problem");
    Console.WriteLine("--------------------------");
    Console.WriteLine();

    // Build query first
    var studentsQuery =
        context.Students;

    // Execute first query: load all students
    var students = studentsQuery.ToList();

    Console.WriteLine();

    foreach (var student in students)
    {
        // Build query first for each student
        var enrollmentsQuery =
            context.Enrollments
                   .Where(e => e.StudentId == student.StudentId);

        // Execute Count() for each student
        // ToQueryString previews query shape,
        // runtime logging shows actual executed SQL for Count().
        int enrollmentsCount =
            enrollmentsQuery.Count();

        Console.WriteLine(
            $"{student.FirstName} {student.LastName} - Enrollments: {enrollmentsCount}");
    }

    Console.WriteLine();
    Console.WriteLine("Problem: One query for students + one query per student.");
    Console.WriteLine();
}
static void ShowBetterIncludeApproach(AppDbContext context)
{
    Console.WriteLine("GOOD APPROACH - Include()");
    Console.WriteLine("-------------------------");
    Console.WriteLine();

    // Build query first
    var query =
        context.Students
               .Include(s => s.Enrollments);

   
    // Execute query
    var studentsWithEnrollments = query.ToList();

    Console.WriteLine();
    foreach (var student in studentsWithEnrollments)
    {
        Console.WriteLine(
            $"{student.FirstName} {student.LastName} - Enrollments: {student.Enrollments.Count}");
    }

    Console.WriteLine();
    Console.WriteLine("Result: Related enrollments are loaded with the students.");
    Console.WriteLine();
}
static void ShowBestProjectionApproach(AppDbContext context)
{
    Console.WriteLine("BEST APPROACH - Projection");
    Console.WriteLine("--------------------------");
    Console.WriteLine();

    // Build query first
    var projectionQuery =
        context.Students
               .Select(s => new
               {
                   s.FirstName,
                   s.LastName,
                   EnrollmentsCount = s.Enrollments.Count(),
                   
               });

    // Execute query
    // ToQueryString previews query shape,
    // runtime logging shows actual executed SQL for Count().
    var result = projectionQuery.ToList();

    Console.WriteLine();
    foreach (var student in result)
    {
        Console.WriteLine(
            $"{student.FirstName} {student.LastName} - {student.EnrollmentsCount}");
    }

    Console.WriteLine();
    Console.WriteLine("Result: One query, minimal data, best performance.");
    Console.WriteLine();
}

static void CompareApproaches(AppDbContext context)
{
    ShowBadNPlusOneApproach(context);

    PrintSeparator();

    ShowBetterIncludeApproach(context);

    PrintSeparator();

    ShowBestProjectionApproach(context);
}


//##----------------- Include() vs ThenInclude() for Eager Loading of Related Data -----------------
static void ShowStudentsWithEnrollmentsAndCourses(AppDbContext context)
{
    // Build query first
    var query = context.Students
        .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
        .OrderBy(s => s.StudentId);

   
    // Execute query
    var students = query.ToList();

    Console.WriteLine("\nStudents With Enrollments and Courses:");
    Console.WriteLine("--------------------------------------");

    foreach (var student in students)
    {
        Console.WriteLine($"{student.StudentId} - {student.FirstName} {student.LastName}");

        foreach (var enrollment in student.Enrollments)
        {
            Console.WriteLine(
                $"Course: {enrollment.Course.Title}, " +
                $"Status: {enrollment.Status}, " +
                $"Progress: {enrollment.ProgressPercent}%");
        }

        Console.WriteLine();
    }
}

/*
   Use Include() when you need related entities
   Use Join() when you need custom report data
 */

//##----------------- Join() = Inner Join In DB, you can pick nedded Fields Only----------------------
static void ShowCourseReport(AppDbContext context)
{
    Console.WriteLine("Course Report Using Join()");
    Console.WriteLine("--------------------------");
    Console.WriteLine();

    // Build query first
    var query =
        context.Courses
               .Join(
                   context.Instructors,
                   course => course.InstructorId,
                   instructor => instructor.InstructorId,
                   (course, instructor) => new
                   {
                       course.Title,
                       course.Code,
                       InstructorName =
                           instructor.FirstName + " " + instructor.LastName
                   })
               .OrderBy(x => x.Title);


    // Execute query
    var report = query.ToList();

    // Print readable output
    Console.WriteLine("Courses With Instructors:");
    Console.WriteLine("-------------------------");

    Console.WriteLine();
    foreach (var row in report)
    {
        Console.WriteLine(
            $"{row.Code} - {row.Title} - {row.InstructorName}");
    }

    Console.WriteLine();
    Console.WriteLine($"Total Courses: {report.Count}");
}
//##----------------- LeftJoin() -> Keep Left side Records And Get Only Matching Records from Right side----------------------
static void ShowStudentsWithProfiles(AppDbContext context)
{
    Console.WriteLine("Students With Profiles - Left Join");
    Console.WriteLine("----------------------------------");
    Console.WriteLine();

    // Build query first
    var report =
        from s in context.Students
        join p in context.StudentProfiles
            on s.StudentId equals p.StudentId
            into profileGroup
        from p in profileGroup.DefaultIfEmpty()
        select new
        {
            s.StudentId,
            StudentName = s.FirstName + " " + s.LastName,
            City = p != null ? p.City : "No Profile",
            Country = p != null ? p.Country : "No Profile"
        };

    // Apply sorting
    var query =
        report.OrderBy(x => x.StudentId);

    // Execute query
    var result = query.ToList();

    // Print readable output
    Console.WriteLine("Student Report:");
    Console.WriteLine("---------------");

    Console.WriteLine();
    foreach (var row in result)
    {
        Console.WriteLine(
            $"{row.StudentId} - {row.StudentName} - {row.City} - {row.Country}");
    }

    Console.WriteLine();
    Console.WriteLine($"Total Students: {result.Count}");
}

//##----------------- SelectMany() for Flattening Collections ----------------------
/*
    Use SelectMany() when each row has a collection
    and you want one flat combined result

    Using Select() Here is a bad Practice, because it will return a collection of collections (IEnumerable<IEnumerable<T>>), which is not what we want for reporting.
        -> Nested Foreach loops will be needed to access individual enrollments, and it can lead to more complex and less efficient code.
        ->Analogy: Imagine you have
            Three folders
            Each folder has files
            
            Select()
            → returns folders with files inside
            
            SelectMany()
            → puts all files on one table


    SelectMany() VS Join():
        -> SelectMany() is used to flatten collections, while Join() is used to combine data from two different sources based on a related key. 
        -> In this example, SelectMany() is more appropriate because we want to flatten the enrollments for each student into a single result set, rather than combining two separate entities like students and instructors.
 */
static void ShowStudentEnrollments(AppDbContext context)
{
    Console.WriteLine("Student Enrollments Using SelectMany()");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine();

    // Build query first
    var query =
        context.Students
               .SelectMany(
                   student => student.Enrollments,
                   (student, enrollment) => new
                   {
                       student.StudentId,
                       StudentName =
                           student.FirstName + " " + student.LastName,
                       enrollment.CourseId,
                       enrollment.Status
                   })
               .OrderBy(x => x.StudentId);


    // Execute query
    var report = query.ToList();

    Console.WriteLine("Student Course Registrations:");
    Console.WriteLine("-----------------------------");
    Console.WriteLine();

    foreach (var row in report)
    {
        Console.WriteLine(
            $"{row.StudentId} - {row.StudentName} - Course: {row.CourseId} - {row.Status}");
    }

    Console.WriteLine();
    Console.WriteLine($"Total Registrations: {report.Count}");
}



//##----------------- Subqueries and Nested Queries ----------------------
static void ShowExpensiveCourses(AppDbContext context)
{
    Console.WriteLine("Courses Priced Above Average");
    Console.WriteLine("----------------------------");
    Console.WriteLine();

    // Build query first
    var query =
        context.Courses
               .Where(c =>
                   c.Price >
                   context.Courses.Average(x => x.Price))
               .OrderBy(c => c.Price);

   
    // Execute query
    // ToQueryString previews query shape,
    // runtime logging shows actual executed SQL for Average().
    var courses = query.ToList();

    // Print readable output
    Console.WriteLine("\nExpensive Courses:");
    Console.WriteLine("------------------");


    Console.WriteLine();
    foreach (var course in courses)
    {
        Console.WriteLine(
            $"{course.Code} - {course.Title} - {course.Price}");
    }

    Console.WriteLine();
    Console.WriteLine($"Total Courses: {courses.Count}");
}


//##----------------- Pagination with Skip() and Take() ----------------------
static void ComparePagination(AppDbContext context)
{
    int pageNumber = 2;
    int pageSize = 5;

    ShowBadPaginationApproach(context, pageNumber, pageSize);

    PrintSeparator();

    ShowGoodPaginationApproach(context, pageNumber, pageSize);
}
static void ShowBadPaginationApproach(
    AppDbContext context,
    int pageNumber,
    int pageSize)
{
    Console.WriteLine("BAD APPROACH - Load Everything, Then Paginate");
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine();

    // Build query first
    var badQuery =
        context.Students;

    // Execute query and load ALL students into memory
    var allStudents = badQuery.ToList();

    Console.WriteLine($"Total Loaded Rows: {allStudents.Count}");
    Console.WriteLine("All rows were loaded into memory.");
    Console.WriteLine();

    // Pagination happens in memory here, not in SQL Server
    var badPage =
        allStudents
            .OrderBy(s => s.StudentId)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

    Console.WriteLine($"Page {pageNumber} Results - BAD:");
    Console.WriteLine("--------------------------");

    Console.WriteLine();
    foreach (var student in badPage)
    {
        Console.WriteLine(
            $"{student.StudentId} - {student.FirstName} {student.LastName}");
    }

    Console.WriteLine();
    Console.WriteLine(
        "Only a few records are displayed, but the entire table was loaded first.");
    Console.WriteLine();
}
static void ShowGoodPaginationApproach(
    AppDbContext context,
    int pageNumber,
    int pageSize)
{
    Console.WriteLine("GOOD APPROACH - Paginate In The Database");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine();

    // Build query first
    var goodQuery =
        context.Students
               .OrderBy(s => s.StudentId)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize);

   

    // Execute query and load ONLY the required page
    var goodPage = goodQuery.ToList();

    Console.WriteLine($"Page {pageNumber} Results - GOOD:");
    Console.WriteLine("---------------------------");

    Console.WriteLine();
    foreach (var student in goodPage)
    {
        Console.WriteLine(
            $"{student.StudentId} - {student.FirstName} {student.LastName}");
    }

    Console.WriteLine();
    Console.WriteLine($"Loaded Rows: {goodPage.Count}");
    Console.WriteLine("Only the required page rows were loaded from the database.");
    Console.WriteLine();
}


//##---------------- ReadOnly Operations -> AsNoTracking ---------------
//Only we use NoTracking for ReadOnly Data No Chages required, to avoid changerTracker scanning Overhead
static void CompareTracking(AppDbContext context)
{
    ShowTrackingQuery(context);

    PrintSeparator();

    ShowNoTrackingQuery(context);
}
static void ShowTrackingQuery(AppDbContext context)
{
    Console.WriteLine("TRACKING QUERY - Default Behavior");
    Console.WriteLine("---------------------------------");
    Console.WriteLine();

    // Build query first
    var trackingQuery =
        context.Students;

    
    // Execute query
    var trackedStudents = trackingQuery.ToList();

    Console.WriteLine($"Returned Students Count: {trackedStudents.Count}");
    Console.WriteLine($"Tracked Entities Count : {context.ChangeTracker.Entries().Count()}");
    Console.WriteLine("EF Core is tracking these entities.");
    Console.WriteLine();
}
static void ShowNoTrackingQuery(AppDbContext context)
{
    Console.WriteLine("NO TRACKING QUERY - Read-Only Scenario");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine();

    // Clear previously tracked entities to make the comparison clean
    context.ChangeTracker.Clear();

    // Build query first
    var noTrackingQuery =
        context.Students
               .AsNoTracking();

    // Execute query
    var untrackedStudents = noTrackingQuery.ToList();

    Console.WriteLine($"Returned Students Count: {untrackedStudents.Count}");
    Console.WriteLine($"Tracked Entities Count : {context.ChangeTracker.Entries().Count()}");
    Console.WriteLine("EF Core is NOT tracking these entities.");
    Console.WriteLine();
}



//###------------------Helper Methods -----------------
static void PrintGeneratedSql(string entityName, string sql)
{
    Console.WriteLine($"Generated SQL for {entityName}:");
    Console.WriteLine(sql);
    Console.WriteLine(new string('-', 50));
}
static void PrintStudent(Student student)
{
    Console.WriteLine("Student Details:");
    Console.WriteLine($"ID: {student.StudentId}," +
             $" Name: {student.FirstName} {student.LastName}," +
             $" Email: {student.Email}," +
             $" Phone: {student.PhoneNumber}," +
             $" Registered At: {student.RegisteredAt}," +
             $" Status: {student.Status}");
    Console.WriteLine();
    Console.WriteLine(new string('=', 45));
}
static void PrintSeparator()
{
    Console.WriteLine(new string('-', 60));
    Console.WriteLine();
}











