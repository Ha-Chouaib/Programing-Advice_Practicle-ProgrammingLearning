﻿using Bank_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer
{
    public class clsAccounts
    {
        enum enMode { enAddNew, enUpdate }
        enMode _Mode = enMode.enAddNew;

        public enum enAccountType { enIndividual = 1, enBusiness = 2 }
        
        public int AccountID { get; private set; }
        public int CustomerID { get;  set; }
        public clsCustomer CustomerInf { get; set; }
        public string AccountNumber { get; set; }
        public enAccountType AccountType     { get; set; }
        public double Balance { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser    { get; set; }

      

        public clsAccounts()
        {
            AccountID = -1;
            CustomerID = -1;
            AccountNumber = string.Empty;
            AccountType = enAccountType.enIndividual;
            Balance = 0;
            IsActive = false;
            CreatedByUserID = -1;
            CreatedDate = DateTime.MinValue;

            _Mode = enMode.enAddNew;
        }
        private clsAccounts(int AccountID,int CustomerID, string AccountNumber, enAccountType AccountType, double Balance, bool IsActive, DateTime CreatedDate, int CreatedByUserID)
        {
            this.AccountID = AccountID;
            this.CustomerID = CustomerID;
            this.AccountNumber = AccountNumber;
            this.AccountType = AccountType;
            this.Balance = Balance;
            this.IsActive = IsActive;
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID = CreatedByUserID;

            this.CustomerInf = clsCustomer.FindCustomerByID(CustomerID);
            this.CreatedByUser = clsUser.FindUserByID(CreatedByUserID);

            _Mode = enMode.enUpdate;
        }

        public static clsAccounts FindByID(int AccountID)
        {
            int CustomerID = -1;
            string AccountNumber = string.Empty;
            byte AccountType = 0;
            double Balance = 0;
            bool IsActive = false;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            if (clsAccountsDataAccess.FindByID(AccountID, ref CustomerID, ref AccountNumber, ref AccountType, ref Balance, ref IsActive, ref CreatedDate, ref CreatedByUserID))
                return new clsAccounts(AccountID, CustomerID, AccountNumber, (enAccountType)AccountType, Balance, IsActive, CreatedDate, CreatedByUserID);
            else
                return null;
        }
        public static clsAccounts FindByAccountNumber(string AccountNumber)
        {
            int CustomerID = -1;
            int AccountID = -1;
            byte AccountType = 0;
            double Balance = 0;
            bool IsActive = false;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            if (clsAccountsDataAccess.FindByAccountNumber(AccountNumber, ref AccountID, ref CustomerID, ref AccountType, ref Balance, ref IsActive, ref CreatedDate, ref CreatedByUserID))
                return new clsAccounts(AccountID, CustomerID, AccountNumber, (enAccountType)AccountType, Balance, IsActive, CreatedDate, CreatedByUserID);
            else
                return null;
        }
        public static clsAccounts FindByCustomerID(int CustomerID)
        {
            int AccountID = -1;
            string AccountNumber = string.Empty;
            byte AccountType = 0;
            double Balance = 0;
            bool IsActive = false;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            if (clsAccountsDataAccess.FindByCustomerID(CustomerID, ref AccountID, ref AccountNumber, ref AccountType, ref Balance, ref IsActive, ref CreatedDate, ref CreatedByUserID))
                return new clsAccounts(AccountID, CustomerID, AccountNumber, (enAccountType)AccountType, Balance, IsActive, CreatedDate, CreatedByUserID);
            else
                return null;
        }


        private bool _AddNew()
        {
           return ( this.AccountID = clsAccountsDataAccess.AddNewAccount(this.CustomerID,this.AccountNumber,Convert.ToByte( this.AccountType),
                            this.Balance,this.IsActive,this.CreatedDate,this.CreatedByUserID)) != -1;
        }
        private bool _Update()
        {
            return clsAccountsDataAccess.Update(this.AccountID,Convert.ToByte( this.AccountType), this.Balance, this.IsActive);
        }
        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNew())
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

        public static bool UpdateBalance(int AccountID, double Balance)
        {
            return clsAccountsDataAccess.UpdateBalance(AccountID, Balance);
        }
        public static bool UpdateStatus(int AccountID, bool IsActive)
        {
            return clsAccountsDataAccess.UpdateStatus(AccountID, IsActive);
        }
        public static bool UpdateAccountType(int AccountID, enAccountType AccountType)
        {
            return clsAccountsDataAccess.UpdateAccountType(AccountID, (byte)AccountType);
        }

        public static bool Exists(int AccountID)
        {
            return clsAccountsDataAccess.ExistsByID(AccountID);
        }
        public static bool Exists(string AccountNumber)
        {
            return clsAccountsDataAccess.ExistsByAccountNumber(AccountNumber);
        }
        public static bool ExistsByCustomerID(int CustomerID)
        {
            return clsAccountsDataAccess.ExistsByCustomerID(CustomerID);
        }


        public static bool Delete(int AccountID)
        {
            return clsAccountsDataAccess.Delete(AccountID);
        }

        public static bool GetAccountStatus(int AccountID)
        {
            return clsAccountsDataAccess.IsActive(AccountID);
        }

        public static DataTable ListAccounts()
        {
            return clsAccountsDataAccess.ListAccounts();
        }

        
    }
}
