using RobotsBackend.Robot;

namespace RobotsTests.UnitTests;

public class DirectionTests
{
    [TestCase(Direction.East, Direction.North)]
    [TestCase(Direction.North, Direction.West)]
    [TestCase(Direction.South, Direction.East)]
    [TestCase(Direction.West, Direction.South)]
    public void DirectionExt_Should_TurnLeft(Direction actualDirection, Direction expectedDirection)
    {
        var directionAfterTurn = actualDirection.TurnLeft();
        
        Assert.That(directionAfterTurn, Is.EqualTo(expectedDirection));
    }

    [TestCase(Direction.East, Direction.South)]
    [TestCase(Direction.North, Direction.East)]
    [TestCase(Direction.South, Direction.West)]
    [TestCase(Direction.West, Direction.North)]
    public void DirectionExt_Should_TurnRight(Direction actualDirection, Direction expectedDirection)
    {
        var directionAfterTurn = actualDirection.TurnRight();
        
        Assert.That(directionAfterTurn, Is.EqualTo(expectedDirection));
    }

    [TestCase("s", Direction.South)]
    [TestCase("n", Direction.North)]
    [TestCase("e", Direction.East)]
    [TestCase("w", Direction.West)]
    public void DirectionExt_Should_ConvertCharToEnum(string directionName, Direction expectedDirectionEnum)
    {
        var convertedDirection = DirectionExt.GetDirectionFromShortName(directionName);
        Assert.That(convertedDirection, Is.EqualTo(expectedDirectionEnum));
    }

    [Test]
    public void DirectionExt_Should_ThrowsAnException_When_IncorrectDirectionString()
    {
        const string wrongDirection = "A";

        Assert.Throws<FormatException>(() => DirectionExt.GetDirectionFromShortName(wrongDirection));
    }
}