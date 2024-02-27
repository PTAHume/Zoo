using System;
using System.Collections.Generic;
using Zoo_Simulator.Animals;

namespace Zoo_Simulator
{
    public static class Zoo
    {
        private static List<Animal> animals;
        private static DateTime startTime;
        private static DateTime currentTime;

        public static void InitializeZoo()
        {
            animals = new List<Animal>();

            // Create 5 monkeys, 5 giraffes, and 5 elephants
            for (int i = 0; i < 5; i++)
            {
                animals.Add(new Monkey(AnimalType.Monkey.ToString() + i));
                animals.Add(new Giraffe(AnimalType.Giraffe.ToString() + i));
                animals.Add(new Elephant(AnimalType.Elephant.ToString() + i));
            }

            startTime = DateTime.Now;
            currentTime = startTime;
        }



        public static void FeedAnimals()
        {
            // TO DO: Complete this
        }

        public static void Simulate()
        {
            Console.WriteLine("Zoo Status:");
            foreach (var animal in animals)
            {
                Console.WriteLine($"Type: {animal.GetType().Name}, Health: {animal.Health}%");
            }

        }
    }
}
