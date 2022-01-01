namespace Calculator.Calculator
{
    class AddCalculator : ICalculator
    {
        public double Calculate(double value1, double value2)
        {
            return (value1 + value2);
        }
    }
}
