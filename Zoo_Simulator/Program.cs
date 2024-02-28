using System;

namespace Zoo_Simulator
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wecome To Zoo Simulator v1.01 \n");

            Zoo.InitializeZoo();
            Zoo.Simulate();
 
        }
    }
}
