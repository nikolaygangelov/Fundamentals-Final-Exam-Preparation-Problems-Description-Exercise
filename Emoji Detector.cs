
namespace _2._Emoji_Detector
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            BigInteger threshold = 1;
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i]; 

                if (char.IsDigit(currentChar))
                {
                    threshold *= int.Parse(currentChar.ToString());
                }

            }

            string pattern = @"((::)|(\*\*))(?<emoji>[A-Z][a-z]{2,})\1";
            Regex regex = new Regex(pattern);
            MatchCollection matchCollection = regex.Matches(input);

            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{matchCollection.Count} emojis found in the text. The cool ones are:");
            
            foreach (Match match in matchCollection)//::Smiley:: , **Tigers**, ::Mooning::, **Shy**
            {
                int sumOfAsci = 0;
                foreach (char ch in match.Groups["emoji"].Value)//S
                {
                    sumOfAsci += (int)ch;//83...
                }

                if (sumOfAsci >= threshold)
                {
                    Console.WriteLine(match);
                }

            }
        }
    }
}
