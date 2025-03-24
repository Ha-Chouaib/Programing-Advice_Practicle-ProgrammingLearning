using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;


namespace Database_Connectivity
{
    public class Program
    {
        static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456";



        //============================================== Get A single Record
        static bool FindContactByID(int ContactID, ref stContact ContactInf) 
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "Select * from Contacts WHERE ContactID=@ContactID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;
                    ContactInf.ID = (int)reader["ContactID"];
                    ContactInf.FirstName = (string)reader["FirstName"];
                    ContactInf.LastName = (string)reader["LastName"];
                    ContactInf.Email = (string)reader["Email"];
                    ContactInf.Phone = (string)reader["Phone"];
                    ContactInf.Address = (string)reader["Address"];
                    ContactInf.CountryID = (int)reader["CountryID"];
                }
                reader.Close();
                connection.Close();

            }catch(Exception ex) { Console.WriteLine("Error", ex.Message); }
           
            return IsFound;
        }

        public struct stContact
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }

        //##==========================================ExecuteScalar >> Det A Single Value.

        static string  GetFirstName(int ContactID)
        {
            string FirstName = "";
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT FirstName FROM Contacts WHERE ContactID=@ContactID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            try 
            {
                connection.Open();
                object result = command.ExecuteScalar();//We Use Validate the Result Becaus Scalar My return << First Row within The First Column  Of Query Result>> Or Null
                if(result != null)                           //And FirstName=null == Exception Error Strings Not Allow Null
                {
                    FirstName = result.ToString();
                }else
                {
                    FirstName = "";
                }

                connection.Close();

            }catch(Exception ex) { Console.WriteLine("Error", ex.Message); }

            return FirstName;
        }

        //##==========================================Parameterized Query With  << LIKE >>

        //Contains
        static void SearchContactsContains(string Contains)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "Select * From Contacts WHERE FirstName LIKE '%' + @Contains + '%'";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID : {contactID}");
                    Console.WriteLine($"Name : {firstName} {lastName}");
                    Console.WriteLine($"Email : {email}");
                    Console.WriteLine($"Phone : {phone}");
                    Console.WriteLine($"Address : {address}");
                    Console.WriteLine($"Country ID : {countryID}");
                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
        }


        //Ends With
        static void SearchContactsEndsWith(string EndsWith)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "Select * From Contacts WHERE FirstName LIKE '%' + @EndsWith + ''";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@EndsWith", EndsWith);
            try 
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID : {contactID}");
                    Console.WriteLine($"Name : {firstName} {lastName}");
                    Console.WriteLine($"Email : {email}");
                    Console.WriteLine($"Phone : {phone}");
                    Console.WriteLine($"Address : {address}");
                    Console.WriteLine($"Country ID : {countryID}");
                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
        }
       
        //satrt with
        static void SearchContactsStartsWith(string Contains)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = "Select * From Contacts WHERE FirstName LIKE '' + @StartWith + '%'";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@StartWith", Contains);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID : {contactID}");
                    Console.WriteLine($"Name : {firstName} {lastName}");
                    Console.WriteLine($"Email : {email}");
                    Console.WriteLine($"Phone : {phone}");
                    Console.WriteLine($"Address : {address}");
                    Console.WriteLine($"Country ID : {countryID}");
                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
        //------------------------------------------------------------------

        //##=========================================Parameterized Query
        static void PrintAllContactsWithFirstNameAndCountry(string FirstName, int CountryID)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = "Select * From Contacts WHERE FirstName=@FirstName AND CountryID=@CountryID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID : {contactID}");
                    Console.WriteLine($"Name : {firstName} {lastName}");
                    Console.WriteLine($"Email : {email}");
                    Console.WriteLine($"Phone : {phone}");
                    Console.WriteLine($"Address : {address}");
                    Console.WriteLine($"Country ID : {countryID}");
                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
        static void PrintAllContactsWithFirstName(string FirstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = "Select * From Contacts WHERE FirstName=@FirstName";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID : {contactID}");
                    Console.WriteLine($"Name : {firstName} {lastName}");
                    Console.WriteLine($"Email : {email}");
                    Console.WriteLine($"Phone : {phone}");
                    Console.WriteLine($"Address : {address}");
                    Console.WriteLine($"Country ID : {countryID}");
                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        //------------------------------------------------------------------

        static void PrintAllContacts()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * From Contacts";

            SqlCommand command = new SqlCommand(Query, connection);

            try 
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID : {contactID}");
                    Console.WriteLine($"Name : {firstName} {lastName}");
                    Console.WriteLine($"Email : {email}");
                    Console.WriteLine($"Phone : {phone}");
                    Console.WriteLine($"Address : {address}");
                    Console.WriteLine($"Country ID : {countryID}");
                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();
            
            }catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        public static void Main()
        {
            //PrintAllContacts();

            //##-----------------Parameterized Query --------------------##
            //PrintAllContactsWithFirstName("Jane");
            //PrintAllContactsWithFirstNameAndCountry("Jane",1);
            //==========================================

            //##-----------------Parameterized Query  With LIKE--------------------##
            //SearchContactsStartsWith("J");
            //SearchContactsEndsWith("ne");
            //SearchContactsContains("ae");

            //##-----------------(Retrieve a Single Value)--[ ExecuteScalar ==> return The First Row In The First Column Of The Query Result] --------------------##
            //Console.WriteLine(GetFirstName(3));
            
            //-------------Retrieve a Record------------------------
            stContact Contact= new stContact();
            if(FindContactByID(2,ref Contact))
            {

                Console.WriteLine($"Contact ID : {Contact.ID}");
                Console.WriteLine($"Name : {Contact.FirstName} {Contact.LastName}");
                Console.WriteLine($"Email : {Contact.Email}");
                Console.WriteLine($"Phone : {Contact.Phone}");
                Console.WriteLine($"Address : {Contact.Address}");
                Console.WriteLine($"Country ID : {Contact.CountryID}");
                Console.WriteLine();
            }else
            {
                Console.WriteLine("No Result Found");
            }

                Console.ReadLine();
        }
    }
}
