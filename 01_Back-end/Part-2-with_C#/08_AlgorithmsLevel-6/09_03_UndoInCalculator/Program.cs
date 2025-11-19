using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_03_UndoInCalculator
{
    internal class Program
    {
        public class Calculator
        {
            private double _value1 { get; set; }
            private double _value2 { get; set; }
            private double _result { get; set; }
            public enum enOperations {
                Addition,
                Subtraction,
                Multiplication,
                Division
            }
            private enOperations _Operation;
            Stack<(double value1,double value2,double result,enOperations operation)> CalcHistory = new Stack<(double value1, double value2, double result, enOperations operation)> ();
            public  double Calculate(double value1, double value2 ,enOperations Operation)
            { 
                _value1 = value1;
                _value2 = value2;
                _Operation = Operation;
                switch(_Operation)
                {
                    case enOperations.Addition:
                        _result = _value1 + _value2;
                        CalcHistory.Push((_value1, _value2, _result, Operation));
                        _DrawCalculation();
                        return _result ;

                    case enOperations.Subtraction:
                        _result = _value1 - _value2;
                        CalcHistory.Push((_value1, _value2, _result, Operation));
                        _DrawCalculation();
                        return _result;

                    case enOperations.Multiplication:
                        _result = _value1 * _value2;
                        CalcHistory.Push((_value1, _value2, _result, Operation));
                        _DrawCalculation();
                        return _result;

                    case enOperations.Division:
                        _result = _value1 / _value2;
                        CalcHistory.Push((_value1, _value2, _result, Operation));
                        _DrawCalculation();
                        return _result;

                    default:
                        return 0;
                }
            }
            private (string Symbol, string Name) GetOperator(enOperations Operation)
            {
                switch (Operation)
                {
                    case enOperations.Addition:return ("+","Addition");
                    case enOperations.Subtraction: return ("-","Substruction");
                    case enOperations.Multiplication: return ("*","Multiplication");
                    case enOperations.Division: return ("/","Division");

                    default: return ("","");
                    
                }
            }
            public void Undo()
            {
                if (CalcHistory.Count > 0)
                {
                    var Hist = CalcHistory.Pop();
                    _value1 = Hist.value1;
                    _value2 = Hist.value2;
                    _result = Hist.result;
                    _Operation = Hist.operation;
                    _DrawCalculation();
                }
            }

            private void _DrawCalculation()
            {
                //Console.Clear();
                var Operation = GetOperator(_Operation);
                Console.WriteLine($"=============[ {Operation.Name} ]==============\n");
                Console.WriteLine($"<< {_value1} {Operation.Symbol} {_value2} = {_result} >>");
                Console.WriteLine("\n=================================\n\n");
            }
        }
       
        static void Main(string[] args)
        {
           Calculator calculation1 = new Calculator();
            calculation1.Calculate(1, 2, Calculator.enOperations.Addition);
            calculation1.Calculate(1, 2, Calculator.enOperations.Subtraction);
            calculation1.Calculate(1, 2, Calculator.enOperations.Multiplication);
            Console.WriteLine("\nRedo ---------------\n");
            calculation1.Undo();
            calculation1.Undo();

        }
    }
}
