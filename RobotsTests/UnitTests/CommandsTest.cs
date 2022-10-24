using System.Drawing;
using RobotsBackend.Commands;
using RobotsBackend.Robot;

namespace RobotsTests.UnitTests;

public class CommandsTest
{
    [Test]
    public void TurnLeftCommand_Should_TurnRobotToLeft()
    {
        var robot = new Robot
        {
            Direction = Direction.South
        };
        var turnLeftCommand = new TurnLeftCommand(robot);

        turnLeftCommand.Execute();

        Assert.That(robot.Direction, Is.EqualTo(Direction.East));
    }

    [Test]
    public void TurnRightCommand_Should_TurnRobotToRight()
    {
        var robot = new Robot
        {
            Direction = Direction.South
        };
        var turnRightCommand = new TurnRightCommand(robot);

        turnRightCommand.Execute();

        Assert.That(robot.Direction, Is.EqualTo(Direction.West));
    }

    [Test]
    public void MoveForwardCommand_Should_MoveRobotForward()
    {
        var robotsList = new List<Robot>();
        var robot = new Robot
        {
            Direction = Direction.North,
            Position = new Point(1, 1)
        };
        var borders = new Point(3, 3);
        var moveForwardCommand = new MoveForwardCommand(robot, borders, robotsList);

        moveForwardCommand.Execute();

        Assert.Multiple(() =>
        {
            Assert.That(robot.Position.X, Is.EqualTo(1));
            Assert.That(robot.Position.Y, Is.EqualTo(2));
        });
    }

    [Test]
    public void MoveForwardCommand_Should_SetRobotIsLost_When_RobotIsMovingOffTheMap()
    {
        var robotsList = new List<Robot>();
        var robotStartPosition = new Point(3, 3);
        var robot = new Robot
        {
            Direction = Direction.North,
            Position = robotStartPosition
        };
        var borders = new Point(3, 3);
        var moveForwardCommand = new MoveForwardCommand(robot, borders, robotsList);
        
        moveForwardCommand.Execute();
        
        Assert.Multiple(() =>
        {
            Assert.That(robot.IsLost, Is.True);
            Assert.That(robot.Position, Is.EqualTo(robotStartPosition));
        });
    }

    [Test]
    public void MoveForwardCommand_Should_NotAffect_When_RobotIsTryingToMoveOffTheMapStandingOnScent()
    {
        var robotsList = new List<Robot>
        {
            new Robot
            {
                Position = new Point(3,3),
                IsLost = true
            }
        };
        var robotStartPosition = new Point(3, 3);
        var robot = new Robot
        {
            Direction = Direction.North,
            Position = robotStartPosition
        };
        var borders = new Point(3, 3);
        var moveForwardCommand = new MoveForwardCommand(robot, borders, robotsList);
        
        moveForwardCommand.Execute();
        
        Assert.Multiple(() =>
        {
            Assert.That(robot.IsLost, Is.False);
            Assert.That(robot.Position, Is.EqualTo(robotStartPosition));
        });
    }

    [Test]
    public void CheckIfRobotIsLostBeforeExecuteCommandWrapper_Should_NotExecuteCommand_When_RobotIsLost()
    {
        var robotStartDirection = Direction.North;
        var robot = new Robot
        {
            Direction = robotStartDirection,
            IsLost = true
        };
        var moveForwardCommand = new TurnLeftCommand(robot);
        var checkIfRobotIsLostBeforeExecuteCommandWrapper = new CheckIfRobotIsLostBeforeExecuteCommandWrapper(moveForwardCommand, robot);
        
        checkIfRobotIsLostBeforeExecuteCommandWrapper.Execute();
        
        Assert.Multiple(() =>
        {
            Assert.That(robot.IsLost, Is.True);
            Assert.That(robot.Direction, Is.EqualTo(robotStartDirection));
        });
    }
}