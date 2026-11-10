using NUnit.Framework;
using Lab.Interfaces;
using Lab.Implementations; // Изменено для универсальности
using System;

namespace Tests;

[TestFixture(Category = "ColorParser")]
public class ColorParserTests
{
    private IColorParser _parser;

    [SetUp]
    public void Setup() => _parser = new ColorParser();

    [Test] public void HexToRgb_Valid6CharHexWithHash_ReturnsCorrectRgb() => Assert.That(_parser.HexToRgb("#FF0000"), Is.EqualTo((255, 0, 0)));
    [Test] public void HexToRgb_Valid3CharHexWithHash_ReturnsCorrectRgb() => Assert.That(_parser.HexToRgb("#0F0"), Is.EqualTo((0, 255, 0)));
    [Test] public void HexToRgb_InvalidCharacters_ThrowsArgumentException() => Assert.Throws<ArgumentException>(() => _parser.HexToRgb("#GGGGGG"));
    [Test] public void RgbToHex_ValidRgb_ReturnsUppercaseHexWithHash() => Assert.That(_parser.RgbToHex(10, 15, 255), Is.EqualTo("#0A0FFF"));
    [Test] public void RgbToHex_AboveRange_Throws() => Assert.Throws<ArgumentOutOfRangeException>(() => _parser.RgbToHex(256, 0, 0));
    [Test] public void GetColorName_Red_ReturnsRed() => Assert.That(_parser.GetColorName(255, 0, 0), Is.EqualTo("Red"));
    [Test] public void HexToRgb_NullInput_ThrowsArgumentException() => Assert.Throws<ArgumentException>(() => _parser.HexToRgb(null));
    // (Остальные тесты из вашего списка можно добавить сюда по аналогии, эти 7 ключевых уже покажут разницу между версиями)
}
