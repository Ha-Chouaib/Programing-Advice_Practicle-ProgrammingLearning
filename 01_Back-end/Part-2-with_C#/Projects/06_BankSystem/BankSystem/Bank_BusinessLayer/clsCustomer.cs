using Bank_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer
{
    public class clsCustomer
    {
        enum enMode { enAddNew, enUpdate }
        enMode _Mode = enMode.enAddNew;
        public enum enCustomerType { enIndividual = 1, enBusiness = 2, enVIP = 3 }

        public int CustomerID { get; private set; }
        public int PersonID { get; set; }
        public clsPerson PersonalInf { get; set; }
        public string Occupation { get; set; }
        public  enCustomerType CustomerType { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser { get; set; }
        public bool IsActive { get; set; }

       
        public clsCustomer()
        {
            CustomerID = -1;
            PersonID = -1;
            Occupation = string.Empty;
            CustomerType = enCustomerType.enIndividual;
            CreatedDate = DateTime.Now;
            CreatedByUserID = -1;
            IsActive = false;
            _Mode= enMode.enAddNew;
        }
        clsCustomer(int CustomerID,  int PersonID,  string Occupation,  enCustomerType CustomerType,  DateTime CreatedDate,  int CreatedByUserID, bool IsActive)
        {
            this.CustomerID = CustomerID;
            this.PersonID = PersonID;
            this.PersonalInf = clsPerson.Find(this.PersonID);
            this.Occupation = Occupation;
            this.CustomerType = CustomerType;
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID=CreatedByUserID;
            this.CreatedByUser = clsUser.FindUserByID(this.CreatedByUserID);
            this.IsActive = IsActive;

            _Mode = enMode.enUpdate;
        }

        public static clsCustomer FindCustomerByID(int CustomerID)
        {
            int PersonID = -1;
            string Occupation = string.Empty;
            byte CustomerType = 0;
            DateTime CreatedDate = DateTime.Now;
            int CreatedByUserID = -1;
            bool IsActive = false;
           
            if( clsCustomerDataAccess.FindCustomerByID(CustomerID,ref  PersonID,ref Occupation,ref CustomerType ,ref CreatedDate,ref CreatedByUserID,ref IsActive))            
                return new clsCustomer(CustomerID,PersonID,Occupation,(enCustomerType)CustomerType,CreatedDate,CreatedByUserID,IsActive);
            else
                return null;
        }
        public static clsCustomer FindCustomerByPersonID(int PersonID)
        {
            int CustomerID = -1;
            string Occupation = string.Empty;
            byte CustomerType = 0;
            DateTime CreatedDate = DateTime.Now;
            int CreatedByUserID = -1;
            bool IsActive = false;

            if (clsCustomerDataAccess.FindCustomerByPersonID(PersonID, ref CustomerID, ref Occupation, ref CustomerType, ref CreatedDate, ref CreatedByUserID, ref IsActive))
                return new clsCustomer(CustomerID, PersonID, Occupation, (enCustomerType)CustomerType, CreatedDate, CreatedByUserID, IsActive);
            else
                return null;
        }
    
        private bool _AddNewCustomer()
        {
            this.CustomerID= clsCustomerDataAccess.AddNewCustomer(this.PersonID,this.Occupation,Convert.ToByte(this.CustomerType),this.CreatedDate,this.CreatedByUserID,this.IsActive);
            return this.CustomerID != -1;
        }

        private bool _Update()
        {
            return clsCustomerDataAccess.Update(this.CustomerID, this.Occupation, Convert.ToByte(this.CustomerType), this.IsActive);
        }        
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewCustomer())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else return false;

                case enMode.enUpdate:
                    return _Update();

                default:
                    return false;
            }
        }
    
        public static bool IsCustomerExistsByID(int CustomerID)
        {
            return clsCustomerDataAccess.IsCustomerExistsByID(CustomerID);
        }
        public static bool IsCustomerExistsByPersonID(int PersonID)
        {
            return clsCustomerDataAccess.IsCustomerExistsByPersonID((int)PersonID);
        }
        public static bool ChangeCustomerStatus(int CustomerID, bool IsActive)
        {
            return clsCustomerDataAccess.UpdateCustomerStatus(CustomerID, IsActive);
        }
        public bool ChangeCustomerStatus(bool IsActive)
        {
            return ChangeCustomerStatus(this.CustomerID, IsActive);
        }
        public static bool IsCustomerActive(int CustomerID)
        {
            return clsCustomerDataAccess.IsActive(CustomerID);
        }
        public static bool Delete(int CustomerID)
        {
            return clsCustomerDataAccess.Delete(CustomerID);
        }
        public bool Delete()
        {
            return Delete(this.CustomerID);
        }
       
        public static DataTable ListCustomers()
        {
            return clsCustomerDataAccess.GetAllCustomers();
        }
    
        public static bool DepositWithdraw(int AccountID,double Amount)
        {
            return clsCustomerDataAccess.DepositWithdraw(AccountID, Amount);
        }
        public bool DepositWithdraw(double Amount)
        {
            int AccountID = clsAccounts.GetAccountIDByCustomerID(this.CustomerID);
            if(AccountID != -1)
               return DepositWithdraw(AccountID, Amount);
            return false;
        }

        public static bool TransferMoney(int AccountFromID, int AccountToID, double Amount)
        {
            return clsCustomerDataAccess.TransferMoney(AccountFromID, AccountToID, Amount);
        }
        public bool TransferMoney(int AccountToID, double Amount)
        {
            int AccountFromID = clsAccounts.GetAccountIDByCustomerID(this.CustomerID);
            if (AccountFromID != -1)
                return TransferMoney(AccountFromID,AccountToID, Amount);
            return false;
        }
    
    }
}
