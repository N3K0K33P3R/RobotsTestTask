using System.Drawing;
using Moq;
using RobotsBackend.ConsoleInput;
using RobotsBackend.Logger;
using RobotsBackend.Robot;

namespace RobotsTests.UnitTests;

public class RobotsBuilderFromStringTests
{
    [Test]
    public void RobotsBuilderByStringDirector_Should_CreateRobotByString_When_DataIsValid()
    {
        const string data = "1 1 E";
        var robotBuilder = new RobotsBuilder();
        var logger = Mock.Of<ILogger>();
        var robotsBuilderByStringDirector = new RobotsBuilderByStringDirector(robotBuilder, logger);

        var robot = robotsBuilderByStringDirector.BuildRobotFromData(data);

        Assert.That(robot, Is.Not.Null);
    }
    
    [Test]
    public void RobotsBuilderByStringDirector_Should_ReturnNull_When_DataIsInvalid()
    {
        const string data = "11432324";
        var robotBuilder = new RobotsBuilder();
        var logger = Mock.Of<ILogger>();
        var robotsBuilderByStringDirector = new RobotsBuilderByStringDirector(robotBuilder, logger);

        var robot = robotsBuilderByStringDirector.BuildRobotFromData(data);

        Assert.That(robot, Is.Null);
    }

    [Test]
    public void RobotsBuilderByStringDirector_Should_CreateValidRobotByString_When_DataIsValid()
    {
        const int x = 12;
        const int y = 10;
        const Direction direction = Direction.West;

        var data = BuildStringFromData(x, y, direction);
        var robotBuilder = new RobotsBuilder();
        var logger = Mock.Of<ILogger>();
        var robotsBuilderByStringDirector = new RobotsBuilderByStringDirector(robotBuilder, logger);

        var robot = robotsBuilderByStringDirector.BuildRobotFromData(data);
        
        Assert.Multiple(() =>
        {
            Assert.That(robot.Position, Is.EqualTo(new Point(x, y)));
            Assert.That(robot.Direction, Is.EqualTo(direction));
        });
    }
    
    [Test]
    public void RobotsBuilderByStringDirector_Should_LogAnError_When_CoordinatesAreInvalid()
    {
        var data = "O I E";
        var robotBuilder = new RobotsBuilder();
        var logger = Mock.Of<ILogger>();
        var robotsBuilderByStringDirector = new RobotsBuilderByStringDirector(robotBuilder, logger);

        robotsBuilderByStringDirector.BuildRobotFromData(data);

        Mock.Get(logger).Verify(l => l.LogError(It.IsAny<string>()), Times.AtLeastOnce);
    }

    [Test]
    public void RobotsBuilderByStringDirector_Should_ThrowAnException_When_DirectionIsInvalid()
    {
        var data = "0 1 P";
        var robotBuilder = new RobotsBuilder();
        var logger = Mock.Of<ILogger>();
        var robotsBuilderByStringDirector = new RobotsBuilderByStringDirector(robotBuilder, logger);

        robotsBuilderByStringDirector.BuildRobotFromData(data);

        Mock.Get(logger).Verify(l => l.LogError(It.IsAny<string>()), Times.AtLeastOnce);
    }

    private string BuildStringFromData(int x, int y, Direction direction)
    {
        return $"{x} {y} {direction.ToString()[0]}";
    }
}