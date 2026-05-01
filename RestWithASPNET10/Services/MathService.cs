namespace RestWithASPNET10.Services
{
    public class MathService
    {
        public decimal Sum(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public decimal Subtraction(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber - secondNumber;
        }
        public decimal Multiplication(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber * secondNumber;
        }
        public decimal Division(decimal firstNumber, decimal secondNumber)
        {
            if(secondNumber == 0)
            {
                throw new DivideByZeroException("Second number cannot be zero.");
            }
            return firstNumber / secondNumber;
        }
        public decimal Mean(decimal firstNumber, decimal secondNumber)
        {
            return (firstNumber + secondNumber) / 2;
        }
        public decimal SquareRoot(decimal number)
        {
            if(number < 0)
            {
                throw new ArgumentException("Cannot calculate the square root of a negative number.");
            }
            return (decimal)Math.Sqrt((double)number);
        }
    }
}
