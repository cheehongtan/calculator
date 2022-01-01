namespace Calculator.Calculator
{
    class DivideCalculator : ICalculator
    {
        public double Calculate(double value1, double value2)
        {
            if (value2 == 0)
            {
                return 0;
            }

            return value1 / value2;
        }
    }
}
