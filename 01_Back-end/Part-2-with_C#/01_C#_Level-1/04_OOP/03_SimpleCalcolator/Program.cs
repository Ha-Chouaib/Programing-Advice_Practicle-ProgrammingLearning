using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace _03_SimpleCalcolator
{
    class clsCalculator
    {
        private float _Result=0;
        private float _CurrentResult=0;
        private string _operator="No Operation Yet";

        public float Number
        {
            get;
            set;
        }

        private float _Calc(char Operator)
        {
            switch (Operator)
            {
                case '+':
                    _operator = "Add";
                    _CurrentResult = _Result;
                    return _Result += Number;
                    
                case '-':
                    _operator = "Subetruct";
                    _CurrentResult = _Result;

                    return _Result -= Number;
                    
                case '*':
                    _CurrentResult = _Result;
                    _operator = "Multiply";
                    return _Result *= Number;
                    
                case '/':
                    _CurrentResult = _Result;
                    _operator = "Divide";
                    if (Number == 0) Number = 1;
                    return _Result /= Number;
                    
                default:
                    _CurrentResult = _Result;
                    _operator = "No Peration Yet";
                    return 0;
            }
            ;
        }
        public void Add(float Number)
        {
            this.Number = Number;
             _Calc('+');
        }
        public void Substruct(float Number)
        {
            this.Number = Number;

             _Calc('-');
        }
        public void Multiply(float Number)
        {
            this.Number = Number;

             _Calc('*');
        }
        public void Divide(float Number)
        {
            this.Number = Number;

             _Calc('/');
           
        }
        public void Clear()
        {
            _Result = 0;
            _CurrentResult = 0;
            Number = 0;
            _operator = "No Operation Yet";
        }
        public void PrintResult()
        {
            Console.WriteLine($"The Result After {_operator} {Number} To {_CurrentResult} is: {_Result}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            clsCalculator Calc1 =new clsCalculator();
            Calc1.Add(100);
            Calc1.PrintResult();

            Calc1.Substruct(50);
            Calc1.PrintResult();


        }
    }
}
