using NUnit.Framework;
using Calculator.Core;

namespace Calculator.Tests;

[TestFixture]
public class CalculatorTests
{
    private Calculator.Calculator _calculator;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator.Calculator();
    }

    [Test]
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        Assert.AreEqual(5, _calculator.Add(2, 3));
    }

    [Test]
    public void Add_NegativeAndPositive_ReturnsCorrectSum()
    {
        Assert.AreEqual(-1, _calculator.Add(-3, 2));
    }

    [Test]
    public void Subtract_TwoNumbers_ReturnsCorrectDifference()
    {
        Assert.AreEqual(2, _calculator.Subtract(5, 3));
    }

    [Test]
    public void Subtract_NegativeResult_ReturnsCorrectDifference()
    {
        Assert.AreEqual(-2, _calculator.Subtract(3, 5));
    }

    [Test]
    public void Multiply_TwoNumbers_ReturnsCorrectProduct()
    {
        Assert.AreEqual(6, _calculator.Multiply(2, 3));
    }

    [Test]
    public void Multiply_ByZero_ReturnsZero()
    {
        Assert.AreEqual(0, _calculator.Multiply(5, 0));
    }

    [Test]
    public void Divide_TwoNumbers_ReturnsCorrectQuotient()
    {
        Assert.AreEqual(2, _calculator.Divide(6, 3));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
    }

    [Test]
    public void Power_PositiveExponent_ReturnsCorrectResult()
    {
        Assert.AreEqual(8, _calculator.Power(2, 3));
    }

    [Test]
    public void SquareRoot_PositiveNumber_ReturnsCorrectResult()
    {
        Assert.AreEqual(3, _calculator.SquareRoot(9));
    }

    [Test]
    public void SquareRoot_NegativeNumber_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(-4));
    }
}