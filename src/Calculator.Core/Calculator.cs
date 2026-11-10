namespace Calculator.Core;

public class Calculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Деление на ноль невозможно");
        }
        return a / b;
    }

    public double Power(double baseValue, double exponent)
    {
        return Math.Pow(baseValue, exponent);
    }

    public double SquareRoot(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Нельзя извлечь квадратный корень из отрицательного числа");
        }
        return Math.Sqrt(value);
    }
}