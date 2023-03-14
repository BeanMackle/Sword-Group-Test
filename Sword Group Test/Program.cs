using System.Text.RegularExpressions;

namespace Sword_Group_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args is null || !args.Any()) 
            {
                Console.WriteLine("Mandatory file location paramater not provided! Stopping process.....");
                Environment.Exit(0);
            }

            string filePath = args[0];
            string[] lines = ArgumentHelpers.ParseFile(filePath);

            if (!lines.Any()) 
            {
                Console.WriteLine("Stopping process.....");
                Environment.Exit(0);
            }

            bool caseSensitive = args.Length > 1 ? ArgumentHelpers.GetCaseSensitiveValue(args[1]) : true;

            var charCountDictionary = BuildCharDictionary(lines, caseSensitive);
            PrintResults(charCountDictionary);
            Console.ReadKey();
        }

        static void PrintResults(Dictionary<char, int> charCountDictionary)
        {
            int totalCharacters = 0;
            foreach(int count in charCountDictionary.Values)
            {
                totalCharacters += count;
            }

            Console.WriteLine($"Total Characters: {totalCharacters}");
            var topCharacters = charCountDictionary.OrderByDescending(c => c.Value).Take(10).ToDictionary(d => d.Key, d=> d.Value);
            foreach(char character in topCharacters.Keys)
            {
                Console.WriteLine($"{character} ({topCharacters.GetValueOrDefault(character)})");
            }
        }

        static Dictionary<char, int> BuildCharDictionary(string[] lines, bool caseSensitive) 
        {
            Dictionary<char, int> charCountDictionary = new Dictionary<char, int>();

            foreach (string line in lines)
            {
                string cleanLine = Regex.Replace(line, @"\p{C}+", String.Empty);
                cleanLine = cleanLine.Replace(" ", String.Empty);
                if(!caseSensitive)
                {
                    cleanLine = cleanLine.ToLower();
                }

                char[] chars = cleanLine.ToCharArray();

                foreach(char character in chars) 
                {
                   if(charCountDictionary.TryGetValue(character, out int count))
                    {
                        charCountDictionary[character] = count + 1;
                    }
                    else
                    {
                        charCountDictionary.Add(character, 1);
                    }
                }
            }
            return charCountDictionary;
        }
    }
}