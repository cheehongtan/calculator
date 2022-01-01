using Calculator.Calculator;
using Calculator.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.BusinessLogic
{
    public class CalculateBiz
    {
        public static double Calculate(string sum)
        {
            const string dataStart = "( ";
            const string dataEnd = " )";
            const char separator = ' ';
            double calculateValue = 0;
            List<string> tempOperation = null;
            bool replaceString;

            while (sum.Split(separator).Length >= 3)
            {
                int operationStartIndex = 0;
                int operationEndIndex = 0;
                replaceString = false;

                if (sum.Contains(dataStart) && sum.Contains(dataEnd))
                {
                    replaceString = true;
                    operationStartIndex = sum.IndexOf(dataStart, 0);
                    operationEndIndex = sum.LastIndexOf(dataEnd);
                    tempOperation = sum.Substring(operationStartIndex + dataStart.Length, operationEndIndex - (operationStartIndex + dataStart.Length)).Split(separator).ToList();
                }
                else
                {
                    tempOperation = sum.Split(separator).ToList();
                }

                int pos = -1;
                do
                {
                    // higher priority to calculate by '*' or '/'  
                    pos = tempOperation.FindIndex(x => x.Contains("*") || x.Contains("/"));

                    if (pos != -1)
                    {
                        ICalculator calculator = CalculatorFactory.GetCalculateType(tempOperation[pos]);
                        calculateValue = calculator.Calculate(Convert.ToDouble(tempOperation[pos - 1]), Convert.ToDouble(tempOperation[pos + 1]));
                        tempOperation.RemoveRange(pos - 1, 3);
                    }
                    else
                    {
                        ICalculator calculator = CalculatorFactory.GetCalculateType(tempOperation[1]);
                        calculateValue = calculator.Calculate(Convert.ToDouble(tempOperation[0]), Convert.ToDouble(tempOperation[2]));
                        tempOperation.RemoveRange(0, 3);
                    }
                    tempOperation.Insert((pos == -1 ? 0 : (pos - 1)), calculateValue.ToString());

                } while (tempOperation.Count >= 3);

                if (replaceString)
                {
                    sum = sum.Replace(sum.Substring(operationStartIndex, operationEndIndex - operationStartIndex + dataEnd.Length), calculateValue.ToString());
                }
                else
                {
                    sum = calculateValue.ToString();
                }

            }

            return calculateValue;
        }
    }
}
