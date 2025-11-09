using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsBusinessLayer;

namespace ContactsConsoleApp
{
    public class TestPresentationLayer
    {   
        public struct stContactInf 
        {
            public int contactID { get; set; }
            public string FirstName{ get; set; }
            public string LastName{get; set;}
            public string Email{get; set;}
            public string Phone{get; set;}
            public string Address{get; set; }
            public DateTime DateOfBirth{get; set;}
            public int CountryID{get; set;}
            public string ImagePath{get; set;}
        }

        public static  void testFindContact(int ID)
        {

            clsContacts contact = clsContacts.Find(ID);
            if( contact != null)
            {

                Console.WriteLine($"First Name      |-->{contact.FirstName}");
                Console.WriteLine($"Last Name       |-->{contact.LastName}");
                Console.WriteLine($"Email           |-->{contact.Email}");
                Console.WriteLine($"Phone           |-->{contact.Phone}");
                Console.WriteLine($"Address         |-->{contact.Address}");
                Console.WriteLine($"Date Of birth   |-->{contact.DateOfbirth}");
                Console.WriteLine($"Coutry ID       |-->{contact.CountryID}");
                Console.WriteLine($"Image Path      |-->{contact.ImagePath}");

            }
            else
            {
                Console.WriteLine("Contact Not Fount");
            }

               
        }
            
        public static void testAddNewContact(stContactInf ContactInf)
        {
            clsContacts contact = new clsContacts();
            contact.FirstName =  ContactInf.FirstName;
            contact.LastName =   ContactInf.LastName;
            contact.Email =      ContactInf.Email;
            contact.Phone =      ContactInf.Phone;
            contact.Address =    ContactInf.Address;
            contact.DateOfbirth= ContactInf.DateOfBirth;
            contact.CountryID =  ContactInf.CountryID;
            contact.ImagePath =  ContactInf.ImagePath;

            if(contact.Save())
            {
                Console.WriteLine("Contact Added Successfylly");
            }else
            {
                Console.WriteLine("Error: Cannot Add The Contact ");

            }
        }
        
        public static void testUpdateContact(int ID,stContactInf ContactInf)
        {
            clsContacts contact = clsContacts.Find(ID);
            if(contact != null)
            {
                contact.FirstName = ContactInf.FirstName;
                contact.LastName = ContactInf.LastName;
                contact.Email = ContactInf.Email;
                contact.Phone = ContactInf.Phone;
                contact.Address = ContactInf.Address;
                contact.DateOfbirth = ContactInf.DateOfBirth;
                contact.CountryID = ContactInf.CountryID;
                contact.ImagePath = ContactInf.ImagePath;
                if (contact.Save())
                {
                    Console.WriteLine("Contact Was Updated Successfuly");

                }else
                {
                    Console.WriteLine("Update Operation Fiald");

                }
            }
            else
            {
                Console.WriteLine("Contact not Found");
            }
        }
        
        public static void testIsContactExists(int ID)
        {
            if(clsContacts.ISExist(ID))
            {
                Console.WriteLine("Yes The Contact is Exists");
            }else
            {
                Console.WriteLine("No The Contact Doesn't Exists");

            }
        }
        
        public static void testDeleteContact(int ID)
        {
            if(clsContacts.ISExist(ID))
            {
                if(clsContacts.DeleteContact(ID))
                {
                    Console.WriteLine("The Contact Deleted Successfuly");

                }else
                {
                    Console.WriteLine("The Deletion Faild !");

                }
            }
            else
            {
                Console.WriteLine($"No Contact Exists with ID: {ID} !!");
            }
        }

        public static void ListAllContacts()
        {
            DataTable DT = clsContacts.GetAllContacts();
            foreach(DataRow row in DT.Rows )
            {
                Console.WriteLine($"ID: {row["ContactID"]} //FirstName: {row["FirstName"]} //LastName: {row["LastName"]} //Email: {row["Email"]}" +
                                    $" //Phone: {row["Phone"]} //Address { row["Address"]} //DateOfBirth: {row["DateOfBirth"]} //CountryID: " +
                                    $"{ row["CountryID"]} //ImagePath: {row["ImagePath"]}");
            }
        }


        //------------------------------- Test Countries Methods --------------------

        public static void testFindCountryByID(int ID)
        {

            clsCountries Country = clsCountries.Find(ID);

            if (Country != null)
            {

                Console.WriteLine($"Country Name      |-->{Country.CountryName}");
                Console.WriteLine($"Code       |-->{Country.Code}");
                Console.WriteLine($"Phone Code       |-->{Country.PhoneCode}");

            }
            else
            {
                Console.WriteLine("Country Not Fount");
            }


        }
        public static void testFindCountryByName(string CountryName)
        {

            clsCountries Country = clsCountries.Find(CountryName);

            if (Country != null)
            {

                Console.WriteLine($"Country Name      |-->{Country.CountryID}");
                Console.WriteLine($"Code       |-->{Country.Code}");
                Console.WriteLine($"Phone Code       |-->{Country.PhoneCode}");

            }
            else
            {
                Console.WriteLine("Country Not Fount");
            }


        }

        public static void testAddNewCountry()
        {
            clsCountries Country = new clsCountries();

            Country.CountryName = "Morocco";
            Country.Code = "999";
            Country.PhoneCode = "+212";

            if (Country.Save())
            {
                Console.WriteLine("Cuontry Added Successfylly");
            }
            else
            {
                Console.WriteLine("Error: Cannot Add The Country ");

            }
        }

        public static void testUpdateCountry(int ID)
        {
            clsCountries Country = clsCountries.Find(ID);
            if (Country != null)
            {
                Country.CountryName = "Elmonch";
                Country.Code = "0000";
                Country.PhoneCode = "+111";

                if (Country.Save())
                {
                    Console.WriteLine("Country Updated Successfuly");

                }
                else
                {
                    Console.WriteLine("Update Operation Fiald");

                }
            }
            else
            {
                Console.WriteLine("Country not Found");
            }
        }

        public static void testIsCountryExists(int ID)
        {
            if (clsCountries.ISExist(ID))
            {
                Console.WriteLine("Yes The Country is Exists");
            }
            else
            {
                Console.WriteLine("No The Country Doesn't Exists");

            }
        }

        public static void testDeleteCountry(int ID)
        {
            if (clsCountries.ISExist(ID))
            {
                if (clsCountries.DeleteCountry(ID))
                {
                    Console.WriteLine("The Country Deleted Successfuly");

                }
                else
                {
                    Console.WriteLine("The Country Faild !");

                }
            }
            else
            {
                Console.WriteLine($"No Country Exists with ID: {ID} !!");
            }
        }

        public static void ListAllCountries()
        {
            DataTable DT = clsCountries.GetAllCountries();
            foreach (DataRow row in DT.Rows)
            {
                Console.WriteLine($"CountryID: {row["CountryID"]} //Country Name: {row["CountryName"]}" +
                                        $" //Code: {row["Code"]} //PhoneCode: {row["PhoneCode"]}");
                                
            }
        }




        static void Main()
        {
            //testFindContact(1);

            stContactInf contInf= new stContactInf();
            contInf.FirstName = "Khalil";
            contInf.LastName = "Zyani";
            contInf.Email = "Ha@Gamil.com";
            contInf.Phone = "095542467";
            contInf.Address = "moro 1 Main Street";
            contInf.DateOfBirth = new DateTime(1950, 1, 1);
            contInf.CountryID = 2;
            contInf.ImagePath = "";

            //testAddNewContact(contInf);

            //testUpdateContact(12, contInf);
            //testIsContactExists(2);
            //testDeleteContact(12);
            //ListAllContacts();

            //=================== Country Test ==================
            
            testFindCountryByID(3);
            //testAddNewCountry();
            //testFindCountryByName("Morocco");
            //testUpdateCountry(5);
            //testIsCountryExists(13);
            //testDeleteCountry(13);


        }
    }
}
