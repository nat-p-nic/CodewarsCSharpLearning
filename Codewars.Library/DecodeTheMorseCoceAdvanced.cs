using System.Text;

namespace Codewars.Library
{
    public class MorseCodeDecoder
    {
        // https://www.codewars.com/kata/54b72c16cd7f5154e9000457/train/csharp

        public static string DecodeBits(string bits)
        {
            int transmissionRate = GetTransmissionRate(bits);
            bits = RemoveUnwantedBits(bits, transmissionRate);

            string morse = bits.Replace("111", "−");                // Dash
            morse = morse.Replace("1", ".");                        // Dot
            morse = morse.Replace("0000000", "   ");                // Word gap
            morse = morse.Replace("000", " ").Replace("0", "");     // Letter gap

            return morse.Trim();
        }

        public static string DecodeMorse(string morseCode)
        {
            StringBuilder message = new();

            morseCode = morseCode.Replace("   ", " _ "); // Space control sequence
            var splitArray = morseCode.Split(" ");

            foreach (var item in splitArray)
            {
                if (item.Trim() == "_")
                    message.Append(" ");                                                     // Space
                else
                    message.Append(_morseCode.FirstOrDefault(w => w.Value == item).Key);     // Non-space
            }

            return message.ToString();
        }

        private static int GetTransmissionRate(string bits)
        {
            bits = bits.Trim('0');

            var minUnit = int.MaxValue;
            int count = 0;
            char prev = bits[0];

            foreach (char c in bits)
            {
                if (c == prev)
                {
                    count++;
                }
                else
                {
                    if (count > 0)
                        minUnit = Math.Min(minUnit, count);
                    count = 1;
                    prev = c;
                }
            }

            return (count > 0) ? Math.Min(minUnit, count) : minUnit;
        }

        private static string RemoveUnwantedBits(string bits, int transmissionRate)
        {
            string newBits = string.Empty;

            for (int i = 0; i < bits.Length; i = i + transmissionRate)
                newBits += bits[i];

            return newBits;
        }

        private static readonly Dictionary<char, string> _morseCode = new()
        {
            {'A', ".−"}, {'B', "−..."}, {'C', "−.−."}, {'D', "−.."}, {'E', "."}, {'F', "..−."}, {'G', "−−."},
            {'H', "...."}, {'I', ".."}, {'J', ".−−−"}, {'K', "−.−"}, {'L', ".−.."}, {'M', "−−"}, {'N', "−."},
            {'O', "−−−"}, {'P', ".−−."}, {'Q', "−−.−"}, {'R', ".−."}, {'S', "..."}, {'T', "−"}, {'U', "..−"},
            {'V', "...−"}, {'W', ".−−"}, {'X', "−..−"}, {'Y', "−.−−"}, {'Z', "−−.."}, {'.', ".−.−.−"}
        };
    }
}