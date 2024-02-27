using System;

namespace Zoo_Simulator
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type 'e' and press Enter to close the app \n");
            Zoo.InitializeZoo();
            while (true)
            {
                Zoo.Simulate();
                var command = Console.ReadLine() ?? string.Empty;
                if (string.Equals(command, "e", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

            

                if (string.Equals(command, "f", StringComparison.OrdinalIgnoreCase))
                {
                    //TO DO: Complete this
                }
            }
        }
    }
}
