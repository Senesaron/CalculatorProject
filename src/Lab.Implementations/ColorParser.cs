using System;
using Lab.Interfaces;

namespace Lab.Implementations; // Оставляем этот namespace!

public class ColorParser : IColorParser
{
    public (int R, int G, int B) HexToRgb(string hex)
    {
        if (string.IsNullOrEmpty(hex)) throw new ArgumentException("HEX не может быть пустым");
        if (hex.StartsWith("#")) hex = hex.Substring(1);
        if (hex.Length != 6) throw new ArgumentException("Неверная длина. Ожидается 6 символов."); // ОШИБКА: нет поддержки 3 символов
        
        return (Convert.ToInt32(hex.Substring(0, 2), 16), Convert.ToInt32(hex.Substring(2, 2), 16), Convert.ToInt32(hex.Substring(4, 2), 16));
    }
    public string RgbToHex(int r, int g, int b)
    {
        if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255) throw new ArgumentOutOfRangeException();
        return $"#{r:X2}{g:X2}{b:X2}";
    }
    public string GetColorName(int r, int g, int b)
    {
        return (r, g, b) switch { (0, 0, 0) => "Black", (255, 255, 255) => "White", (255, 0, 0) => "Red", (0, 255, 0) => "Green", (0, 0, 255) => "Blue", _ => "Unknown" }; // ОШИБКА: нет Yellow, Cyan и т.д.
    }
}
