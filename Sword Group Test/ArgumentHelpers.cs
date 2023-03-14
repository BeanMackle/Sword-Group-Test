using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword_Group_Test
{
    internal class ArgumentHelpers
    {
        public static string[] ParseFile(string filePath) 
		{
			try
			{			
				return File.ReadAllLines(filePath);
			}
			catch (Exception e)
			{
				string error = $"Failed to parse file: {e.Message}";
				Console.WriteLine(error);
				return new string[0];
			}
        }

		public static bool GetCaseSensitiveValue(string caseSensitiveString) 
		{

			if (bool.TryParse(caseSensitiveString, out bool caseSensitive))
			{
				return caseSensitive;
			}
			else {
				Console.WriteLine("Failed to parse case sensitive argument. Setting to default of true.");
				return true;
			}
        }
    }
}
