using System;
using System.Collections.Generic;
using System.Linq;
using Zoo_Simulator.Animals;

namespace Zoo_Simulator
{
    public static class Zoo
    {
        private static List<Animal> _animals;

        public static List<Animal> GetGroupedAnimals()
        {
            return _animals.GroupBy(a => a.GetType()).SelectMany(x => x.Select(y => y)).ToList();
        }

        public static void InitializeZoo()
        {
            _animals = new List<Animal>();
            for (int i = 1; i < 6; i++)
            {
                _animals.Add(new Monkey($"{AnimalType.Monkey} {i}"));
                _animals.Add(new Giraffe($"{AnimalType.Giraffe} {i}"));
                _animals.Add(new Elephant($"{AnimalType.Elephant} {i}"));
            }
        }

        public static void FeedAnimals()
        {
            var random = new Random();
            float monkeyFeed = random.Next(10, 26);
            float giraffeFeed = random.Next(10, 26);
            float elephantFeed = random.Next(10, 26);

            foreach (var animal in GetGroupedAnimals())
            {
                var h = animal.Health;
                switch (Enum.Parse(typeof(AnimalType), animal.GetType().Name, true))
                {
                    case AnimalType.Monkey:
                        animal.Feed(monkeyFeed);

                        Console.WriteLine($"You have fed: {animal.Name}, {monkeyFeed} bannans(s) helth before: ({h}%), helth after: ({animal.Health}%)");
                        break;

                    case AnimalType.Giraffe:
                        animal.Feed(giraffeFeed);
                        Console.WriteLine($"You have fed: {animal.Name}, {giraffeFeed} shrub(s) helth before: ({h}%), helth after: ({animal.Health}%)");
                        break;

                    case AnimalType.Elephant:
                        animal.Feed(elephantFeed);
                        Console.WriteLine($"You have fed: {animal.Name}, {elephantFeed} peanut(s) helth before: ({h}%), helth after: ({animal.Health}%)");
                        break;
                }
            }
        }

        public static void GetAnimalStatues()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Current status of animals:");

            foreach (Animal animal in GetGroupedAnimals())
            {
                if (animal.GetType() == typeof(Elephant) && !((Elephant)animal).CanWalk() && !animal.IsDead())
                {
                    Console.WriteLine($"Name: {animal.Name} is below 70% ({animal.Health}%). It cannot walk.");
                }

                if (animal.IsDead())
                {
                    Console.WriteLine($"{animal.Name}'s health is below the threshold ({animal.Health}%). It has died.");
                }
                else
                {
                    Console.WriteLine($"Name: {animal.Name}, Health: {animal.Health}%");
                }
            }

            _animals.RemoveAll(animal => animal.IsDead());

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine($"The zoo has ({_animals.Count(x => x.GetType() == typeof(Elephant))}) Elephant's remaining");
            Console.WriteLine($"The zoo has ({_animals.Count(x => x.GetType() == typeof(Monkey))}) Monkey's remaining");
            Console.WriteLine($"The zoo has ({_animals.Count(x => x.GetType() == typeof(Giraffe))}) Giraffe's remaining");
        }

        public static void UpdateAnimalsHealth()
        {
            Random random = new Random();
            _animals.ForEach(x =>
            {
                float percentage = random.Next(0, 21);
                x.UpdateHealth(percentage);
            });
        }
    }
}
