using Bank_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank_BusinessLayer.Reports.clsAuditUserActions;

namespace Bank_BusinessLayer
{
    public class clsCurrencies
    {
        public int ID { get; private set; }
        public string Country { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public float Rate { get; set; }

        private const string _SectionKey = "CURRENCIES";

        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All { get; } = ("All", "All");
            public static (string valueMember, string DisplayMember) Country { get; } = ("Country", "Country");
            public static (string valueMember, string DisplayMember) Name { get; } = ("Name", "Currency Name");
            public static (string valueMember, string DisplayMember) Code { get; } = ("Code", "Currency Code");
        }

        [Serializable]
        public static class FindBy_Mapping 
        {
            public static (string valueMember, string DisplayMember) ID { get; } = ("ID", " Currency ID");
            public static (string valueMember, string DisplayMember) Name { get; } = ("Name", "Currency Name");
            public static (string valueMember, string DisplayMember) Code { get; } = ("Code", "Currency Code");
        }

        private clsCurrencies()
        {
            ID = -1;
            Country = string.Empty;
            Name = string.Empty;
            Code = string.Empty;
            Rate = 0;
        }

        public static clsCurrencies FindByID(int id)
        {
            string code = string.Empty;
            string country = string.Empty;
            string name = string.Empty;
            float rate = 0;

            if (clsCurrencies_DAL.FindByID(id , ref code , ref country, ref name, ref rate))
            {
                return new clsCurrencies
                {
                    ID = id,
                    Country = country,
                    Name = name,
                    Code = code,
                    Rate = rate
                };
            }
            return null;
        }

        public static clsCurrencies FindByCode(string code)
        {
            int id = -1;
            string country = string.Empty;
            string name = string.Empty;
            float rate = 0;

            if (clsCurrencies_DAL.FindByCode(code, ref id, ref country, ref name, ref rate))
            {
                return new clsCurrencies
                {
                    ID = id,
                    Country = country,
                    Name = name,
                    Code = code,
                    Rate = rate
                };
            }
            return null;
        }
        public static clsCurrencies FindByName(string name)
        {
            int id = -1;
            string country = string.Empty;
            string code = string.Empty;
            float rate = 0;

            if (clsCurrencies_DAL.FindByName(name, ref id, ref country, ref code, ref rate))
            {
                return new clsCurrencies
                {
                    ID = id,
                    Country = country,
                    Name = name,
                    Code = code,
                    Rate = rate
                };
            }

            return null;
        }


        private delegate clsCurrencies  _FindByDelegate (string term);
        static Dictionary<string, _FindByDelegate> FindByActionsRef;
        static Dictionary<string, _FindByDelegate> FindByActions 
        { 
            get 
            {
                if (FindByActionsRef == null)
                {
                    FindByActionsRef = new Dictionary<string, _FindByDelegate>
                    {
                        {FindBy_Mapping.ID.valueMember,(string term)=>
                            {
                                if(int.TryParse(term, out int id))
                                    return FindByID(id);
                                return null;
                            }
                        },
                        {FindBy_Mapping.Code.valueMember,(string term)=> FindByCode(term)},
                        {FindBy_Mapping.Name.valueMember,(string term)=> FindByName(term)},
                    };
                }
                return FindByActionsRef;
            }
        }
        public static clsCurrencies FindBy(string column ,string term)
        {
      
            if(FindByActions.TryGetValue(column , out _FindByDelegate action))
                return action(term.Trim());
            return null;
        }
        public bool UpdateRate()
        {
            var OldRecord = FindByCode(this.Code);
            bool OperationSucceed = clsCurrencies_DAL.UpdateRateByCode(Code, Rate);
            var NewRecord = FindByCode(this.Code);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_SectionKey, $"Update rate for currency [{Code}] to Rate [{Rate}]"), changes.Before, changes.After, this.ID);
            return OperationSucceed;
        }

        public static double CalculateCurrency(double amount, float FromRate, float ToRate)
        {
            double amountInUSD = amount / FromRate;

            return amountInUSD * ToRate;
        }

        public static float GetRate(int id)
        {
            return clsCurrencies_DAL.GetRateByID(id);
        }
        public static float GetRate(string code)
        {
            return clsCurrencies_DAL.GetRateByCode(code);
        }

        private static DataTable _Filter(string country, string name, string code)
        {
            DataTable dt = clsCurrencies_DAL.Filter(country, name, code);
            return dt;
        }

        public static DataTable ListAll()
        {
            DataTable dt = _Filter(null, null, null);
            //AuditingHelper.AuditReadRecordsListOperation(dt != null, (_SectionKey, "List All Currencies"));
            return dt;
        }

        public static DataTable FilterByCountry(string country)
        {
            DataTable dt = _Filter(country, null, null);
            AuditingHelper.AuditReadRecordsListOperation(dt != null, (_SectionKey, $"Filter currencies by country [{country}]"));
            return dt;
        }

        public static DataTable FilterByName(string name)
        {
            DataTable dt = _Filter(null, name, null);
            AuditingHelper.AuditReadRecordsListOperation(dt != null, (_SectionKey, $"Filter currencies by name [{name}]"));
            return dt;
        }

        public static DataTable FilterByCode(string code)
        {
            DataTable dt = _Filter(null, null, code);
            AuditingHelper.AuditReadRecordsListOperation(dt != null, (_SectionKey, $"Filter currencies by code [{code}]"));
            return dt;
        }
        
        private delegate DataTable FilterDelegate(string term);
        private static Dictionary<string, FilterDelegate> _filterActions;
        private static Dictionary<string, FilterDelegate> _FilterActions
        {
            get
            {
                if (_filterActions == null)
                {
                    _filterActions = new Dictionary<string, FilterDelegate>
            {
                { Filter_Mapping.Country.valueMember, (t)=> FilterByCountry(t) },
                { Filter_Mapping.Name.valueMember,    (t)=> FilterByName(t) },
                { Filter_Mapping.Code.valueMember,    (t)=> FilterByCode(t) },
                { Filter_Mapping.All.valueMember,     (t)=> ListAll() }
            };
                }
                return _filterActions;
            }
        }

        public static DataTable Filter(string column, string term)
        {
            term = term?.Trim();

            if (_FilterActions.TryGetValue(column, out FilterDelegate action))
                return action(term);

            return ListAll();
        }
    }
}



