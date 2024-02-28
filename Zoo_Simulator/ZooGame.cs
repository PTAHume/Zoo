using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Zoo_Simulator
{
    public static class ZooGame
    {
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Required for running consle application")]
        private static void Main(string[] args)
        {
            Console.WriteLine("Wecome To Zoo Simulator v1.02 \n");

            Zoo.InitializeZoo();
            int time = 0;

            while (true)
            {
                if (!Console.IsOutputRedirected) Console.Clear();
                Console.WriteLine($"Current time: {time} hours");

                Zoo.GetAnimalStatues();

                if (!Zoo.GetGroupedAnimals().Any())
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("All animals have died. Game over! Press any key to close");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Do you want to feed the animals? Press Y for yes, Press any key for No or Press X to exit the game");
                string input = Console.ReadLine();
                if (input.ToLower() == "yes" || input.ToLower() == "y")
                {
                    if (!Console.IsOutputRedirected) Console.Clear();
                    Console.WriteLine("Feeding animlas ....");
                    Zoo.FeedAnimals();
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Animals have been fed....");
                }
                if (input.ToLower() == "x")
                {
                    break;
                }

                Zoo.UpdateAnimalsHealth();

                Console.WriteLine("Waiting for next check up, please wait ....");
                time++;
                System.Threading.Thread.Sleep(20000);
            }
        }
    }
}
