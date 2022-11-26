
namespace _3._Heroes_of_Code_N_Logic
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

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> heroesHP = new Dictionary<string, int>();
            Dictionary<string, int> heroesMP = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] heroes = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);//Solmyr 85 120
                string heroName = heroes[0];
                int hitPoints = int.Parse(heroes[1]);
                int manaPoints = int.Parse(heroes[2]);

                if (!heroesHP.ContainsKey(heroName) && !heroesMP.ContainsKey(heroName))
                {
                    heroesHP.Add(heroName, hitPoints);
                    heroesMP.Add(heroName, manaPoints);
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] inputParameters = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = inputParameters[0];
                string heroName = inputParameters[1];

                if (commandType == "CastSpell")
                {
                    int neededManaPoints = int.Parse(inputParameters[2]);
                    string spellName = inputParameters[3];

                    if(heroesMP[heroName] >= neededManaPoints)
                    {
                        heroesMP[heroName] -= neededManaPoints;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroesMP[heroName]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }

                }
                else if (commandType == "TakeDamage")
                {
                    int damageAmount = int.Parse(inputParameters[2]);
                    string attackerName = inputParameters[3];
                    heroesHP[heroName] -= damageAmount;

                    if(heroesHP[heroName] >= 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damageAmount} HP by {attackerName} and now has {heroesHP[heroName]} HP left!");
                    }
                    else
                    {
                        heroesMP.Remove(heroName);
                        heroesHP.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attackerName}!");
                    }
                }
                else if (commandType == "Recharge")
                {
                    int rechargeAmount = int.Parse(inputParameters[2]);                

                    if((heroesMP[heroName] + rechargeAmount) > 200)
                    {
                        Console.WriteLine($"{heroName} recharged for {200 - heroesMP[heroName]} MP!");
                        heroesMP[heroName] = 200;
                    }
                    else
                    {
                        heroesMP[heroName] += rechargeAmount;
                        Console.WriteLine($"{heroName} recharged for {rechargeAmount} MP!");
                    }

                }
                else if (commandType == "Heal")
                {
                    int healAmount = int.Parse(inputParameters[2]);//10
                    
                    if ((heroesHP[heroName] + healAmount) > 100)
                    {
                        Console.WriteLine($"{heroName} healed for {100 - heroesHP[heroName]} HP!");
                        heroesHP[heroName] = 100;
                    }
                    else
                    {
                        heroesHP[heroName] += healAmount;
                        Console.WriteLine($"{heroName} healed for {healAmount} HP!");
                    }

                }
            }

            foreach (var (heroName, manaPoints) in heroesMP)
            {
                Console.WriteLine($"{heroName}");
                Console.WriteLine($"  HP: {heroesHP[heroName]}");
                Console.WriteLine($"  MP: {manaPoints}");
            }
        }
    }
}
