using System;
using System.Collections.Generic;
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

            testUpdateContact(12, contInf);
        }
    }
}
