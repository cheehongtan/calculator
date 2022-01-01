using Calculator.Calculator;
using System;

namespace Calculator.Factory
{
    public class CalculatorFactory
    {
        public  static ICalculator GetCalculateType(string operatorType)
        {
            switch (operatorType)
            {
                case "+":
                    return new AddCalculator();
                case "-":
                    return new MinusCalculator();
                case "*":
                    return new MultiplyCalculator();
                case "/":
                    return new DivideCalculator();
                default:
                    throw new Exception("Invalid Operator Type!");
            }            
        }
    }
}