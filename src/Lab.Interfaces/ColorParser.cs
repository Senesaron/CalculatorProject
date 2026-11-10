using System;
using System.Text.RegularExpressions;
using Lab.Interfaces;

namespace Lab.Implementations; // Упростили для удобства тестирования в CI

public class ColorParser : IColorParser
{
    public (int R, int G, int B) HexToRgb(string hex)
    {
        if (string.IsNullOrWhiteSpace(hex))
            throw new ArgumentException("HEX строка не может быть пустой или null.", nameof(hex));

        hex = hex.Trim().ToUpperInvariant();
        if (hex.StartsWith("#")) hex = hex.Substring(1);

        if (hex.Length != 3 && hex.Length != 6)
            throw new ArgumentException("Неверная длина HEX строки.", nameof(hex));

        if (hex.Length == 3)
            hex = $"{hex[0]}{hex[0]}{hex[1]}{hex[1]}{hex[2]}{hex[2]}";

        if (!Regex.IsMatch(hex, "^[0-9A-F]{6}$"))
            throw new ArgumentException("HEX строка содержит недопустимые символы.", nameof(hex));

        return (
            Convert.ToInt32(hex.Substring(0, 2), 16),
            Convert.ToInt32(hex.Substring(2, 2), 16),
            Convert.ToInt32(hex.Substring(4, 2), 16)
        );
    }

    public string RgbToHex(int r, int g, int b)
    {
        if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
            throw new ArgumentOutOfRangeException("Значения RGB должны быть в диапазоне от 0 до 255.");
        return $"#{r:X2}{g:X2}{b:X2}";
    }

    public string GetColorName(int r, int g, int b)
    {
        if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
            throw new ArgumentOutOfRangeException("Значения RGB должны быть в диапазоне от 0 до 255.");

        return (r, g, b) switch
        {
            (0, 0, 0) => "Black", (255, 255, 255) => "White", (255, 0, 0) => "Red",
            (0, 255, 0) => "Green", (0, 0, 255) => "Blue", (255, 255, 0) => "Yellow",
            (0, 255, 255) => "Cyan", (255, 0, 255) => "Magenta", (128, 128, 128) => "Gray",
            _ => "Unknown"
        };
    }
}
