using Zoo_Simulator;
using Zoo_Simulator.Animals;

namespace Zoo_Simulator_Tests
{
    public class ZooTests
    {
        [Fact]
        public void CanCreateTheZoo()
        {
            // Arrange
            Zoo.InitializeZoo();

            // Act
            using (var consoleOutput = new ConsoleOutput())
            {
                consoleOutput.SetIn("x");
                Zoo.Simulate();

                // Assert
                List<string> list = consoleOutput.GetOuPut().Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                Assert.True(list.Count(p => p.Contains($"Name: {AnimalType.Monkey}") &&  p.Contains($"Health: 100%")) == 5, $"Zoo should have Has 5 {AnimalType.Monkey}'s with 100% health");
                Assert.True(list.Count(p => p.Contains($"Name: {AnimalType.Giraffe}") && p.Contains($"Health: 100%")) == 5, $"Zoo should have Has 5 {AnimalType.Giraffe}'s with 100% health");
                Assert.True(list.Count(p => p.Contains($"Name: {AnimalType.Elephant}") && p.Contains($"Health: 100%")) == 5, $"Zoo should have Has 5 {AnimalType.Elephant}'s with 100% health");
            }
        }

        [Fact]
        
        public void CanFeedAnimals()
        {
            // Arrange
            Zoo.InitializeZoo();
            using var input = new StringReader("Any key");
            Console.SetIn(input);

            // Act
            Zoo.GetGroupedAnimals().ForEach(x => x.Health = 50);
            Zoo.FeedAnimals();

            // Assert
            Assert.DoesNotContain(Zoo.GetGroupedAnimals(), x => x.Health == 50);
        }
    }
}
