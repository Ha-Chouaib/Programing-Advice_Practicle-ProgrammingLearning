using System;
using System.Linq;
using System.Data;

namespace DataSetEx
{
    class Program
    {
        private static DataColumn _AddColumn<T>(string ColumnName, string ColumnCaption = "", bool ReadOnly = false, bool AutoIncrement = false, short AutoSeed = 1, short AutoStep = 1)
        {

            DataColumn dtColumn = new DataColumn();
            dtColumn.DataType = typeof(T);
            dtColumn.ColumnName = ColumnName;
            dtColumn.Caption = ColumnCaption;
            dtColumn.ReadOnly = ReadOnly;
            if (AutoIncrement)
            {
                dtColumn.AutoIncrement = AutoIncrement;
                dtColumn.AutoIncrementSeed = AutoSeed;
                dtColumn.AutoIncrementStep = AutoStep;
            }


            return dtColumn;
        }

        public static void Main()
        {
            DataTable EmpDT = new DataTable("EmployeeDataTable");

            EmpDT.Columns.Add(_AddColumn<int>("ID", "", true, true, 1, 1));
            EmpDT.Columns.Add(_AddColumn<string>("Name", "Employee Name"));
            EmpDT.Columns.Add(_AddColumn<string>("Country"));
            EmpDT.Columns.Add(_AddColumn<Double>("Salary", "Employee Salary"));
            EmpDT.Columns.Add(_AddColumn<DateTime>("Date"));

            DataColumn[] PrimaryColumns = new DataColumn[1];
            PrimaryColumns[0] = EmpDT.Columns["ID"];
            EmpDT.PrimaryKey = PrimaryColumns;

            EmpDT.Rows.Add(null, "Chouaib Hadadi", "Morocco", 90000, DateTime.Now);
            EmpDT.Rows.Add(null, "Ali Maher", "Egypt", 300, DateTime.Now);
            EmpDT.Rows.Add(null, "Mohamed Gani", "Morocco", 200, DateTime.Now);
            EmpDT.Rows.Add(null, "Mobarak Hadadi", "Morocco", 2000, DateTime.Now);
            EmpDT.Rows.Add(null, "Mohammed Abu-Hadhoud", "Jordan", 90000, DateTime.Now);

            DataTable EmpDepartmentDT = new DataTable("DepartmentDataTable");

            EmpDepartmentDT.Columns.Add(_AddColumn<int>("ID", "Departemnt ID", true, true));
            EmpDepartmentDT.Columns.Add(_AddColumn<string>("Name", "Department Name"));

            EmpDepartmentDT.Rows.Add(1, "HR");
            EmpDepartmentDT.Rows.Add(2, "Archetict");

            DataSet EmpDS = new DataSet();

            EmpDS.Tables.Add(EmpDT);
            EmpDS.Tables.Add(EmpDepartmentDT);

            Console.WriteLine("List Employees Data From DataSet\n");
            foreach (DataRow row in EmpDS.Tables["EmployeeDataTable"].Rows)
            {
                Console.WriteLine($"ID: {row["ID"]} || Name: {row["Name"]} || Country: {row["Country"]} || Salary: {row["Salary"]} || Date: {row["Date"]}");
            }


            Console.WriteLine("\n\nList Departemnts Data From DataSet\n");
            foreach (DataRow row in EmpDS.Tables["DepartmentDataTable"].Rows)
            {
                Console.WriteLine($"ID:{row["ID"]} || Name: {row["Name"]}");
            }




        }
    }
}
