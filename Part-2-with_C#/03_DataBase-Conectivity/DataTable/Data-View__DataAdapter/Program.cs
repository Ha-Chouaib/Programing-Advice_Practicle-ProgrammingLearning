using System;
using System.Linq;
using System.Data;

namespace DataView__DataAdapter
{
    class Program
    {   
        private static DataColumn _AddColumn<T>(string ColumnName,string ColumnCaption="",bool ReadOnly=false,bool AutoIncrement=false,short AutoSeed=1,short AutoStep=1)
        {

            DataColumn dtColumn = new DataColumn();
            dtColumn.DataType = typeof(T);
            dtColumn.ColumnName = ColumnName;
            dtColumn.Caption = ColumnCaption;
            dtColumn.ReadOnly = ReadOnly;
            if(AutoIncrement)
            {
                dtColumn.AutoIncrement = AutoIncrement;
                dtColumn.AutoIncrementSeed = AutoSeed;
                dtColumn.AutoIncrementStep = AutoStep;
            }
           

            return dtColumn;
        }
        public static void Main()
        {
            DataTable EmpDT = new DataTable();

            EmpDT.Columns.Add(_AddColumn<int>("ID","",true,true,1,1));
            EmpDT.Columns.Add(_AddColumn<string>("Name","Employee Name"));
            EmpDT.Columns.Add(_AddColumn<string>("Country"));
            EmpDT.Columns.Add(_AddColumn<Double>("Salary","Employee Salary"));
            EmpDT.Columns.Add(_AddColumn<DateTime>("Date"));

            DataColumn[] PrimaryColumns = new DataColumn[1];
            PrimaryColumns[0] = EmpDT.Columns["ID"];
            EmpDT.PrimaryKey = PrimaryColumns;

            EmpDT.Rows.Add(null, "Chouaib Hadadi", "Morocco", 90000, DateTime.Now);
            EmpDT.Rows.Add(null, "Ali Maher", "Egypt", 300, DateTime.Now);
            EmpDT.Rows.Add(null, "Mohamed Gani", "Morocco", 200, DateTime.Now);
            EmpDT.Rows.Add(null, "Mobarak Hadadi", "Morocco", 2000, DateTime.Now);
            EmpDT.Rows.Add(null, "Mohammed Abu-Hadhoud", "Jordan", 90000, DateTime.Now);


            Console.WriteLine("List With DataTable\n");
            foreach (DataRow row in EmpDT.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]} || Name: {row["Name"]} || Country: {row["Country"]} || Salary: {row["Salary"]} || Date: {row["Date"]}");
            }

            Console.WriteLine("\n\nList With DataView\n");

            DataView EmpDV1 = new DataView();
            EmpDV1 = EmpDT.DefaultView;

            for(int i=0; i < EmpDV1.Count; i++)
            {
                for (int j = 0; j < EmpDV1.Count; j++)
                {
                    Console.WriteLine($"{EmpDV1[i][j]}, ");
                }
                
            }
            //Filtering
            Console.WriteLine("\n\nFilter Data List Just Rows With Morocco Or Jordan\n");

            EmpDV1.RowFilter = "Country= 'Morocco' or Country='Jordan'";

            for (int i = 0; i < EmpDV1.Count; i++)
            {
                for (int j = 0; j < EmpDV1.Count; j++)
                {
                    Console.Write($"{EmpDV1[i][j]}, ");
                }

                Console.WriteLine("");
            }
            //Sorting

            Console.WriteLine("\n\nSorte DataView By name ASC\n");
            EmpDV1.Sort= "Name ASC";

            for (int i = 0; i < EmpDV1.Count; i++)
            {
                for (int j = 0; j < EmpDV1.Count; j++)
                {
                    Console.Write($"{EmpDV1[i][j]}| ");
                }

                Console.WriteLine("");
            }
        }
    }
}
