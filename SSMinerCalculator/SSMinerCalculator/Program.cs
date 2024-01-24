using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMinerCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Mining Skill Level: ");
            float miningSkillLevelBoost = Convert.ToInt32(Console.ReadLine()) * 0.01f;
            Console.WriteLine("Strip Mining Skill Level: ");
            float stripMiningSkillLevelBoost = Convert.ToInt32(Console.ReadLine()) * 0.02f;
            Console.WriteLine("Max Mining Turrets: ");
            float maxMiningTurrets = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Mining Rate Of The Ship: ");
            float miningRateOfTheShip = Convert.ToInt32(Console.ReadLine()) * 0.01f;
            string turretType = "";
            while (true)
            {
                Console.WriteLine("Strip/Precise/Normal/Ice[s/p/n/i]: ");
                turretType = Console.ReadLine().ToLower();
                if (turretType.Length == 1
                    &&
                    (turretType.Contains("s")
                    || turretType.Contains("p")
                    || turretType.Contains("n")
                    || turretType.Contains("n")
                    ))
                {
                    break;
                }
            }

            string turretTier = "";

            while (true)
            {
                Console.WriteLine("Turret Tier [1/2]: ");
                try
                {
                    turretTier = Console.ReadLine();
                }
                catch (Exception ex) { }


                if (turretTier == "1" || turretTier == "2") { break; }

            }



            float iceMinerT1OrePerMinute = 3f;
            float iceMinerT2OrePerMinute = 4f;

            float minerT1OrePerMinute = 3.4f;
            float minerT2OrePerMinute = 3.7f;

            float preciseMinerT1OrePerMinute = 3.5f;
            float preciseMinerT2OrePerMinute = 3.7f;

            float stripMinerT1OrePerMinute = 5.1f;
            float stripMinerT2OrePerMinute = 5.9f;

            float orePerMinute = 0f;

            switch (turretType + turretTier)
            {
                case "i1":
                    orePerMinute = iceMinerT1OrePerMinute;
                    break;
                case "i2":
                    orePerMinute = iceMinerT2OrePerMinute;
                    break;

                case "n1":
                    orePerMinute = minerT1OrePerMinute;
                    break;
                case "n2":
                    orePerMinute = minerT2OrePerMinute;
                    break;

                case "p1":
                    orePerMinute = preciseMinerT1OrePerMinute;
                    break;
                case "p2":
                    orePerMinute = preciseMinerT2OrePerMinute;
                    break;

                case "s1":
                    orePerMinute = stripMinerT1OrePerMinute;
                    break;
                case "s2":
                    orePerMinute = stripMinerT2OrePerMinute;
                    break;
                default: throw new Exception("skillIssue");
            }

            float skillBoost = (turretType == "s" ? miningSkillLevelBoost + stripMiningSkillLevelBoost : miningSkillLevelBoost);//only mining skill if the type isnt strip

            float result = ((orePerMinute * (1 + skillBoost)) * maxMiningTurrets) * (1 + miningRateOfTheShip);

            Console.WriteLine("Ore Per Minute: " + result+"\nPress Enter To Exit");
            Console.ReadLine();


        }
    }
}
