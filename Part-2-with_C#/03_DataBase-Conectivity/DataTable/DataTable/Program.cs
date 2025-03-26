using System;
using System.Linq;
using System.Data;

namespace DataTableEx
{
    class Program
    {
         public static void Main()
        {
            DataTable EmpDT=new DataTable();

            EmpDT.Columns.Add("ID", typeof(int));
            EmpDT.Columns.Add("Name", typeof(string));
           
            //you Can Add Columns In More Effecient  Way.
            DataColumn dtColumn;
            dtColumn = new DataColumn();

            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Country";//The Real Name
            dtColumn.Caption = "Country Name";//Alias name Will Be just Shown The End User
            dtColumn.ReadOnly=false; // if Yes You'll Not Be Able To Modify it Leter On.
            dtColumn.AutoIncrement = true;
            dtColumn.AutoIncrementSeed = 1; //Start On
            dtColumn.AutoIncrementStep = 1;

            EmpDT.Columns.Add(dtColumn); /// Add The Column to The dataTable
            
            
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Double);
            dtColumn.ColumnName = "Salary";//The Real Name
            dtColumn.Caption = "Emp Salary";//Alias name Will Be just Shown The End User
            dtColumn.ReadOnly=false; // if Yes You'll Not Be Able To Modify it Leter On.
            dtColumn.AutoIncrement = true;
            dtColumn.AutoIncrementSeed = 1; //Start On
            dtColumn.AutoIncrementStep = 1;

            EmpDT.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(DateTime);
            dtColumn.ColumnName = "Date";//The Real Name
            dtColumn.Caption = "";//Alias name Will Be just Shown The End User
            dtColumn.ReadOnly = false; // if Yes You'll Not Be Able To Modify it Leter On.
            dtColumn.AutoIncrement = true;
            dtColumn.AutoIncrementSeed = 1; //Start On
            dtColumn.AutoIncrementStep = 1;

            EmpDT.Columns.Add(dtColumn);

            //Make a PrimaryKey
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];/// DataColumn[Set How Many Keys You Want]
            PrimaryKeyColumns[0] = EmpDT.Columns["ID"];
            EmpDT.PrimaryKey = PrimaryKeyColumns;
            //---------------
            //We Add Null To The ID Field Because it's AutoIncrement 
            EmpDT.Rows.Add(null, "Chouaib Hadadi", "Morocco",90000, DateTime.Now);
            EmpDT.Rows.Add(null, "Ali Maher", "Egypt",300, DateTime.Now);
            EmpDT.Rows.Add(null, "Mohamed Gani", "Morocco", 200, DateTime.Now);
            EmpDT.Rows.Add(null, "Mobarak Hadadi", "Morocco", 2000, DateTime.Now);
            EmpDT.Rows.Add(null, "Mohammed Abu-Hadhoud", "Jordan",90000, DateTime.Now);



            Console.WriteLine("Employees List:\n");
            foreach(DataRow row in EmpDT.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]} || Name: {row["Name"]} || Country: {row["Country"]} || Salary: {row["Salary"]} || Date: {row["Date"]} ");
            }

            int NumOfEmployees = 0;
            double TotalSalaries = 0;
            double AVGSalaries = 0;
            double MaxSalary = 0;
            double MinSalary = 0;

            NumOfEmployees = EmpDT.Rows.Count;
            TotalSalaries = Convert.ToDouble(EmpDT.Compute("SUM(Salary)", string.Empty));
            AVGSalaries = Convert.ToDouble(EmpDT.Compute("AVG(Salary)", string.Empty));
            MaxSalary = Convert.ToDouble(EmpDT.Compute("Max(Salary)", string.Empty));
            MinSalary = Convert.ToDouble(EmpDT.Compute("Min(Salary)", string.Empty));

            Console.WriteLine($"Number Of Employees:<< {NumOfEmployees} >>");
            Console.WriteLine($"Total Salaries:     << {TotalSalaries} >>");
            Console.WriteLine($"Salaries Average:   << {AVGSalaries} >>");
            Console.WriteLine($"Max Salary:         << {MaxSalary} >>");
            Console.WriteLine($"Min Salary:         << {MinSalary} >>");

            //Sorting // But This Method Not The Fastest One. !!!
            EmpDT.DefaultView.Sort = "ID desc";
            EmpDT = EmpDT.DefaultView.ToTable();

            Console.WriteLine("\n\nSorting Data With ID desc\n");
            foreach (DataRow row in EmpDT.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]} || Name: {row["Name"]} || Country: {row["Country"]} || Salary: {row["Salary"]} || Date: {row["Date"]} ");
            }
            EmpDT.DefaultView.Sort = "Name ASC";
            EmpDT = EmpDT.DefaultView.ToTable();

            Console.WriteLine("\nSorting Data With Name ASC\n");
            foreach (DataRow row in EmpDT.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]} || Name: {row["Name"]} || Country: {row["Country"]} || Salary: {row["Salary"]} || Date: {row["Date"]} ");
            }


            //Filtering Data Table
            Console.WriteLine("\n\nFilter DataTable:\n");
            int ResultCount = 0;
            DataRow[] resultRows;
            Console.WriteLine("Countries With Morocco Name:\n");

            string FilterCondition = "Country = 'Morocco'";

            resultRows = EmpDT.Select(FilterCondition);
            foreach (DataRow row in resultRows)
            {
                Console.WriteLine($"ID: {row["ID"]} || Name: {row["Name"]} || Country: {row["Country"]} || Salary: {row["Salary"]} || Date: {row["Date"]} ");
            }

            ResultCount = resultRows.Count();
            TotalSalaries = Convert.ToDouble(EmpDT.Compute("SUM(Salary)", FilterCondition));
            AVGSalaries = Convert.ToDouble(EmpDT.Compute("AVG(Salary)", FilterCondition));
            MaxSalary = Convert.ToDouble(EmpDT.Compute("Max(Salary)", FilterCondition));
            MinSalary = Convert.ToDouble(EmpDT.Compute("Min(Salary)", FilterCondition));

            Console.WriteLine($"Number Of Employees:<< {ResultCount} >>");
            Console.WriteLine($"Total Salaries:     << {TotalSalaries} >>");
            Console.WriteLine($"Salaries Average:   << {AVGSalaries} >>");
            Console.WriteLine($"Max Salary:         << {MaxSalary} >>");
            Console.WriteLine($"Min Salary:         << {MinSalary} >>");

            Console.WriteLine("\n\nCountries With Morocco or Jordan Name:\n");

            FilterCondition = "Country = 'Morocco' or Country='Jordan'";

            resultRows = EmpDT.Select(FilterCondition);
            foreach (DataRow row in resultRows)
            {
                Console.WriteLine($"ID: {row["ID"]} || Name: {row["Name"]} || Country: {row["Country"]} || Salary: {row["Salary"]} || Date: {row["Date"]} ");
            }

            ResultCount = resultRows.Count();
            TotalSalaries = Convert.ToDouble(EmpDT.Compute("SUM(Salary)", FilterCondition));
            AVGSalaries = Convert.ToDouble(EmpDT.Compute("AVG(Salary)", FilterCondition));
            MaxSalary = Convert.ToDouble(EmpDT.Compute("Max(Salary)", FilterCondition));
            MinSalary = Convert.ToDouble(EmpDT.Compute("Min(Salary)", FilterCondition));

            Console.WriteLine($"Number Of Employees:<< {ResultCount} >>");
            Console.WriteLine($"Total Salaries:     << {TotalSalaries} >>");
            Console.WriteLine($"Salaries Average:   << {AVGSalaries} >>");
            Console.WriteLine($"Max Salary:         << {MaxSalary} >>");
            Console.WriteLine($"Min Salary:         << {MinSalary} >>");

            //Deleting ||            To Clear All Data --> EmpDT.Clear();
            Console.WriteLine("\n\nDelete Employee with ID = 3\n");
            DataRow[] MarkForDelete = EmpDT.Select("ID=3");
            foreach(var row in MarkForDelete)
            {
                row.Delete();
            }
            //EmpDT.AcceptChanges(); //This When We Connecte The DataTable With database Apply The Changes Accured To it
            
            foreach (DataRow row in EmpDT.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]} || Name: {row["Name"]} || Country: {row["Country"]} || Salary: {row["Salary"]} || Date: {row["Date"]} ");
            }
            Console.ReadKey();

            //Update
            Console.WriteLine("\n\nUpdate Employee with ID = 4\n");
            DataRow[] MarkForUpdate = EmpDT.Select("ID=4");
            foreach (var row in MarkForUpdate)
            {
                row["Name"]="Omar Boul-Mal";
                row["Salary"] = "20093";
            }
            //EmpDT.AcceptChanges(); //This When We Connecte The DataTable With database Apply The Changes Accured To it

            foreach (DataRow row in EmpDT.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]} || Name: {row["Name"]} || Country: {row["Country"]} || Salary: {row["Salary"]} || Date: {row["Date"]} ");
            }
            Console.ReadKey();
        }
    }
}
