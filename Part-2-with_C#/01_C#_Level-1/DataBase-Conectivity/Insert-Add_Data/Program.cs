using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;

namespace Insert_Update_Delete_Data
{
    
    class Program
    {
        static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456";

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

        //=============================== Delete Data ==

        public static void DeleteContact(int ContactID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = @"
                           
                            DELETE FROM [dbo].[Contacts]
                                 WHERE ContactID = @ContactID;
                            ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);
           
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record Deleted Successfully.");
                }
                else
                {
                    Console.WriteLine("Record Deleting Failed.");

                }
                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine("Error", ex.Message); }

        }


        //------------- Handle IN Statement ------------
        public static void DeleteContacts(string ContactIDs)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = @"
                           
                            DELETE FROM [dbo].[Contacts]
                                 WHERE ContactID IN  (" + ContactIDs + ")"; 
                            

            SqlCommand command = new SqlCommand(Query, connection);
           

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record Deleted Successfully.");
                }
                else
                {
                    Console.WriteLine("Record Deleting Failed.");

                }
                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine("Error", ex.Message); }

        }



        //=============================== Update Data ==
        public static void UpdateContact(stContact NewContact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = @"
                            UPDATE Contacts
                               SET FirstName = @FirstName
                                  ,LastName = @LastName
                                  ,Email = @Email
                                  ,Phone = @Phone
                                  ,Address = @Address
                                  ,CountryID = @CountryID
                             WHERE (ContactID = @ContactID)
                            ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", NewContact.FirstName);
            command.Parameters.AddWithValue("@LastName", NewContact.LastName);
            command.Parameters.AddWithValue("@Email", NewContact.Email);
            command.Parameters.AddWithValue("@Phone", NewContact.Phone);
            command.Parameters.AddWithValue("@Address", NewContact.Address);
            command.Parameters.AddWithValue("@CountryID", NewContact.CountryID);
            command.Parameters.AddWithValue("@ContactID", NewContact.ID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record Updated Successfully.");
                }
                else
                {
                    Console.WriteLine("Record Updating Failed.");

                }
                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine("Error", ex.Message); }

        }


        //=============================== Insert Data ==

        //Retrieve ID =Primary Key, With SCOPE_IDENTITY() Using < ExecuteScalar >
        public static void AddNewContactAndGetID(stContact NewContact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = @"INSERT INTO Contacts   ( FirstName, LastName,  Email, Phone, Address, CountryID )
                             VALUES (@FirstName ,@LastName, @Email, @Phone, @Address, @CountryID);
                              SELECT SCOPE_IDENTITY(); ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", NewContact.FirstName);
            command.Parameters.AddWithValue("@LastName", NewContact.LastName);
            command.Parameters.AddWithValue("@Email", NewContact.Email);
            command.Parameters.AddWithValue("@Phone", NewContact.Phone);
            command.Parameters.AddWithValue("@Address", NewContact.Address);
            command.Parameters.AddWithValue("@CountryID", NewContact.CountryID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null  && int.TryParse(result.ToString(), out int insertedID))
                {
                    Console.WriteLine($"Newly Inserted ID: {insertedID}");
                }
                else
                {
                    Console.WriteLine("Failed To Retrieve The Inserted ID.");

                }

              
                connection.Close();

            }
            catch (Exception ex) { Console.WriteLine("Error", ex.Message); }

        }

        public static void AddNewContact( stContact NewContact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = @"INSERT INTO Contacts   ( FirstName, LastName,  Email, Phone, Address, CountryID )
                             VALUES (@FirstName ,@LastName, @Email, @Phone, @Address, @CountryID )";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName",NewContact.FirstName);
            command.Parameters.AddWithValue("@LastName",NewContact.LastName);
            command.Parameters.AddWithValue("@Email",NewContact.Email);
            command.Parameters.AddWithValue("@Phone",NewContact.Phone);
            command.Parameters.AddWithValue("@Address",NewContact.Address);
            command.Parameters.AddWithValue("@CountryID",NewContact.CountryID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if( rowsAffected > 0)
                {
                    Console.WriteLine("Record Inserted Successfully.");
                }else
                {
                    Console.WriteLine("Record Insertion Failed.");

                }
                connection.Close();
            }
            catch(Exception ex) { Console.WriteLine("Error", ex.Message); }

        }
        public static void Main()
        {
            stContact Contact = new stContact
            {   
                ID= 1,
                FirstName="Mohammed",
                LastName="Abu-Hadhoud",
                Email="Hadadi@Gmail.Com",
                Phone="0605361990",
                Address="123 Main Streat",
                CountryID=1
                
            };
            //AddNewContact(Contact);
            //AddNewContactAndGetID(Contact);
            //UpdateContact(Contact);
            //DeleteContact(6);
            DeleteContacts("1006,1007,1008");
            
            Console.ReadKey();

        }
    }
}
