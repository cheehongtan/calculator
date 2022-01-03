using Calculator.BusinessLogic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataSource;
            dataSource = "( 11.5 + 15.4 ) + 10.1";
            double result = CalculateBiz.Calculate(dataSource);
        }
    }
}
