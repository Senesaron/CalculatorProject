using System;
using Lab.Interfaces;

namespace Lab.Implementations; // Оставляем этот namespace!

public class ColorParser : IColorParser
{
    public (int R, int G, int B) HexToRgb(string hex)
    {
        hex = hex.Trim().Replace("#", ""); // ОШИБКА: падает на null (NullReferenceException)
        if (hex.Length == 3) hex = new string(new[] { hex[0], hex[0], hex[1], hex[1], hex[2], hex[2] });
        return (Convert.ToInt32(hex.Substring(0, 2), 16), Convert.ToInt32(hex.Substring(2, 2), 16), Convert.ToInt32(hex.Substring(4, 2), 16));
    }
    public string RgbToHex(int r, int g, int b)
    {
        return $"{r:x2}{g:x2}{b:x2}"; // ОШИБКА: нижний регистр и нет "#"
    }
    public string GetColorName(int r, int g, int b)
    {
        if (r == 0 && g == 0 && b == 0) return "Black";
        if (r == 255 && g == 255 && b == 255) return "White";
        return "Unknown"; // ОШИБКА: только 2 цвета
    }
}
