using System.Globalization;
using System.Text.RegularExpressions;

namespace ClothingStore.Domain.ValueObjects
{
    public class Color
    {
        private static readonly Regex HexRegex = new(@"^[0-9A-Fa-f]{6}$", RegexOptions.Compiled);
        public string Hexadecimal { get; }
        public byte Red { get; }
        public byte Green { get; }
        public byte Blue { get; }

        private Color(string hexadecimal, byte red, byte green, byte blue)
        {
            this.Hexadecimal = hexadecimal;
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public static Color FromHex(string hexadecimal)
        {
            if (hexadecimal is null)
                throw new ArgumentNullException(nameof(hexadecimal));

            var sanitized = hexadecimal.TrimStart('#');
            if (!HexRegex.IsMatch(sanitized))
                throw new ArgumentException("Hexadecimal must be exactly 6 hex digits.", nameof(hexadecimal));

            byte r = byte.Parse(sanitized.Substring(0, 2), NumberStyles.HexNumber);
            byte g = byte.Parse(sanitized.Substring(2, 2), NumberStyles.HexNumber);
            byte b = byte.Parse(sanitized.Substring(4, 2), NumberStyles.HexNumber);

            var normalizedHex = "#" + sanitized.ToUpperInvariant();
            return new Color(normalizedHex, r, g, b);
        }

        public static Color FromRGB(byte red, byte green, byte blue)
        {
            string hex = $"#{red:X2}{green:X2}{blue:X2}";
            return new Color(hex, red, green, blue);
        }

        public override bool Equals(object? obj) =>
            obj is Color other &&
            Hexadecimal == other.Hexadecimal &&
            Red == other.Red &&
            Blue == other.Blue &&
            Green == other.Green;

        public override int GetHashCode()
        {
            return HashCode.Combine(Hexadecimal, Red, Blue, Green);
        }

        public override string ToString() => $"#{Hexadecimal}";
    }
}
