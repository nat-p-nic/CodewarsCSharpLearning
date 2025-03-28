namespace Codewars.Library
{
    public class Parser
    {
        private static readonly char[] _separator = [' '];

        public static int ParseInt(string s)
        {
            var tokens = s.ToLower().Replace('-', ' ').Split(_separator, StringSplitOptions.RemoveEmptyEntries);

            int total = 0;
            int current = 0;

            foreach (var token in tokens)
            {
                switch (token)
                {
                    case "zero": current += 0; break;
                    case "one": current += 1; break;
                    case "two": current += 2; break;
                    case "three": current += 3; break;
                    case "four": current += 4; break;
                    case "five": current += 5; break;
                    case "six": current += 6; break;
                    case "seven": current += 7; break;
                    case "eight": current += 8; break;
                    case "nine": current += 9; break;
                    case "ten": current += 10; break;
                    case "eleven": current += 11; break;
                    case "twelve": current += 12; break;
                    case "thirteen": current += 13; break;
                    case "fourteen": current += 14; break;
                    case "fifteen": current += 15; break;
                    case "sixteen": current += 16; break;
                    case "seventeen": current += 17; break;
                    case "eighteen": current += 18; break;
                    case "nineteen": current += 19; break;
                    case "twenty": current += 20; break;
                    case "thirty": current += 30; break;
                    case "forty": current += 40; break;
                    case "fifty": current += 50; break;
                    case "sixty": current += 60; break;
                    case "seventy": current += 70; break;
                    case "eighty": current += 80; break;
                    case "ninety": current += 90; break;
                    case "hundred":
                        current *= 100;
                        break;
                    case "thousand":
                        current *= 1000;
                        total += current;
                        current = 0;
                        break;
                    case "million":
                        current *= 1000000;
                        total += current;
                        current = 0;
                        break;
                    default:
                        break;
                }
            }

            return total + current;
        }
    }
}