namespace Lab.Interfaces;

public interface IColorParser
{
    (int R, int G, int B) HexToRgb(string hex);
    string RgbToHex(int r, int g, int b);
    string GetColorName(int r, int g, int b);
}
