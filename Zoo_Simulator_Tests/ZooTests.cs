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

            // Assert
            using (var consoleOutput = new ConsoleOutput())
            {
                // Act
                Zoo.Simulate();

                // Assert
                List<string> list = consoleOutput.GetOuPut().Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                Assert.True(list.Count(p => p == $"Type: {AnimalType.Monkey}, Health: 100%") == 5 , $"Zoo should have Has 5 {AnimalType.Monkey}'s with 100% health");
                Assert.True(list.Count(p => p == $"Type: {AnimalType.Giraffe}, Health: 100%") == 5, $"Zoo should have Has 5 {AnimalType.Giraffe}'s with 100% health");
                Assert.True(list.Count(p => p == $"Type: {AnimalType.Elephant}, Health: 100%") == 5, $"Zoo should have Has 5 {AnimalType.Monkey}'s with 100% health");
            }
        }
    }
}
