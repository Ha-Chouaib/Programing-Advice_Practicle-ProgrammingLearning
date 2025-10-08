using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess.People
{
    public class clsPersonDataAccess
    {
        public static bool FindPersonByID(int PersonID ,ref string NationalNo, ref string FirstName, ref string LastName,ref DateTime DateOfBirth, ref byte Gender, 
                                    ref string Email, ref string Phone,ref short CountryID, ref string Address, ref string ImgPath
                                    )
        {
            string Query = "Sp_GetPersonByID";
            bool found = false;
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(Query,connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                NationalNo = reader["NationalNo"] as string ?? string.Empty;
                                FirstName = reader["FirstName"] as string ?? string.Empty;
                                LastName = reader["LastName"] as string ?? string.Empty;
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Email = reader["Email"] as string ?? string.Empty;
                                Phone = reader["Phone"] as string ?? string.Empty;
                                Gender = reader["Gender"] != DBNull.Value ? Convert.ToByte(reader["Gender"]) : (byte) 3 ;
                                CountryID = reader["CountryID"] != DBNull.Value ?  Convert.ToInt16(reader["CountryID"]) : (short)0 ;
                                Address = reader["Address"] as string ?? string.Empty;
                                ImgPath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : string.Empty;
                               

                                found = true;
                            }
                            else
                            {
                                FirstName = LastName = NationalNo = Email = Phone = Address = ImgPath = string.Empty;
                                CountryID = 0; 
                                DateOfBirth =  DateTime.MinValue;
                            }
                        }
                    }
                    catch(SqlException ex)
                    {
                        clsEventLogger.LogError($"[DAL: PeopleDataAccess.FindPersonByID()] (SQL Error: {ex.Number} )-> {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        clsEventLogger.LogError($"[DAL: PeopleDataAccess.FindPersonByID()] ->  {ex.Message}");
                    }
                    return found;
                }
            }


        }
    }
}
