using Zoo_Simulator;
using Zoo_Simulator.Animals;

namespace Zoo_Simulator_Tests;

public class ZooTests
{
    [Fact]
    public void CanCreateTheZoo()
    {
        // Arrange
        Zoo.InitializeZoo();

        // Acert
        Assert.True(Zoo.GetGroupedAnimals().Count == 15, "There should be 15 animals to to start with");
        Assert.True(Zoo.GetGroupedAnimals().Count(x => x.Health == 100) == 15, "All animlas should start with 100% health");
        Assert.True(Zoo.GetGroupedAnimals().OfType<Monkey>().Count() == 5, "There should be 5 Monkeys start with");
        Assert.True(Zoo.GetGroupedAnimals().OfType<Elephant>().Count() == 5, "There should be 5 Elephants start with");
        Assert.True(Zoo.GetGroupedAnimals().OfType<Giraffe>().Count() == 5, "There should be 5 Giraffes start with");
    }

    [Fact]
    public void CanRunZooSimulation()
    {
        // Arrange
        Zoo.InitializeZoo();

        // Act
        using var consoleOutput = new ConsoleOutput();
        Zoo.GetAnimalStatues();

        // Assert
        List<string> list = [.. consoleOutput.GetOuPut().Split(new string[] { Environment.NewLine }, StringSplitOptions.None)];
        Assert.True(list.Count(p => p.Contains($"Name: {AnimalType.Monkey}") && p.Contains($"Health: 100%")) == 5, $"Zoo should have Has 5 {AnimalType.Monkey}'s with 100% health");
        Assert.True(list.Count(p => p.Contains($"Name: {AnimalType.Giraffe}") && p.Contains($"Health: 100%")) == 5, $"Zoo should have Has 5 {AnimalType.Giraffe}'s with 100% health");
        Assert.True(list.Count(p => p.Contains($"Name: {AnimalType.Elephant}") && p.Contains($"Health: 100%")) == 5, $"Zoo should have Has 5 {AnimalType.Elephant}'s with 100% health");
    }

    [Fact]
    public void CanFeedAnimals()
    {
        // Arrange
        Zoo.InitializeZoo();
        Zoo.GetGroupedAnimals().ForEach(x => x.Health = 50);

        // Act
        Zoo.GetAnimalStatues();
        Zoo.FeedAnimals();
        Zoo.GetAnimalStatues();

        // Assert
        Assert.DoesNotContain(Zoo.GetGroupedAnimals(), x => x.Health == 50);
    }

    [Fact]
    public void CanKillAllAnimals()
    {
        // Arrange
        Zoo.InitializeZoo();
        Zoo.GetGroupedAnimals().ForEach(x => x.Health = 29);

        // Act
        Zoo.GetAnimalStatues();
        Zoo.UpdateAnimalsHealth();
        //Run twice because elephants have to stop walking before they can die
        Zoo.GetAnimalStatues();
        Zoo.UpdateAnimalsHealth();

        // Assert
        Assert.True(Zoo.GetGroupedAnimals().Count == 0, "All animlas should be dead");
    }

    [Fact]
    public void EnsureElephansCantWalkWhenHumgry()
    {
        // Arrange
        Zoo.InitializeZoo();

        // Act
        Zoo.GetGroupedAnimals().OfType<Elephant>().ToList().ForEach(x => x.Health = 69);

        // Assert
        Assert.DoesNotContain(Zoo.GetGroupedAnimals().OfType<Elephant>(), x => x.CanWalk());
        Assert.DoesNotContain(Zoo.GetGroupedAnimals().OfType<Elephant>(), x => x.IsDead());
        Assert.Equal(5, Zoo.GetGroupedAnimals().OfType<Elephant>().Count());
    }

    [Fact]
    public void EnsureElephansCantWalkBeforeTheyDie()
    {
        // Arrange
        Zoo.InitializeZoo();
        Zoo.GetGroupedAnimals().OfType<Elephant>().ToList().ForEach(x => x.Health = 69);

        // Act
        Zoo.GetAnimalStatues();
        Zoo.UpdateAnimalsHealth();
        Zoo.GetAnimalStatues();

        // Assert
        Assert.False(Zoo.GetGroupedAnimals().OfType<Elephant>().Any(), "All Elephants shoould be dead");
    }

    [Fact]
    public void EnsureElephansCanRecover()
    {
        // Arrange
        Zoo.InitializeZoo();
        Zoo.GetGroupedAnimals().OfType<Elephant>().ToList().ForEach(x => x.Health = 69);

        // Act
        // Smetimes, you have to feed the elephants a few ties to get them back on there feet
        // Safeguard against infinity loop, caped at 20 iterations
        for (var i = 0; i <= 20; i++)
        {
            Zoo.GetAnimalStatues();
            Zoo.FeedAnimals();
            Zoo.GetAnimalStatues();
            Zoo.UpdateAnimalsHealth();
            if ((Zoo.GetGroupedAnimals().OfType<Elephant>().Count(x => x.Health > 95) == 5))
            {
                break;
            }
        }

        // Assert
        Assert.Equal(5, Zoo.GetGroupedAnimals().OfType<Elephant>().Count(x => x.CanWalk()));
        Assert.DoesNotContain(Zoo.GetGroupedAnimals().OfType<Elephant>(), x => x.IsDead());
        Assert.Equal(5, Zoo.GetGroupedAnimals().OfType<Elephant>().Count());
    }
}
