
namespace _1._Activation_Keys
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] commandParamaters = command.Split(">>>");
                string firstParameter = commandParamaters[0];

                if (firstParameter == "Contains")
                {
                    string substring = commandParamaters[1];

                    if (!activationKey.Contains(substring))
                    {
                        Console.WriteLine($"Substring not found!");
                        continue;
                    }

                    Console.WriteLine($"{activationKey} contains {substring}");
                }
                else if(firstParameter == "Flip" && commandParamaters[1] == "Upper")
                {
                    int startIndex = int.Parse(commandParamaters[2]);
                    int endIndex = int.Parse(commandParamaters[3]);

                    string substring = activationKey.Substring(startIndex, endIndex - startIndex);
                    activationKey = activationKey.Replace(substring, substring.ToUpper());
                    Console.WriteLine(activationKey);
                }
                else if (firstParameter == "Flip" && commandParamaters[1] == "Lower")
                {
                    int startIndex = int.Parse(commandParamaters[2]);
                    int endIndex = int.Parse(commandParamaters[3]);

                    string substring = activationKey.Substring(startIndex, endIndex - startIndex);
                    activationKey = activationKey.Replace(substring, substring.ToLower());
                    Console.WriteLine(activationKey);
                }
                else if(firstParameter == "Slice")
                {
                    int startIndex = int.Parse(commandParamaters[1]);
                    int endIndex = int.Parse(commandParamaters[2]);

                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey);
                }

            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
