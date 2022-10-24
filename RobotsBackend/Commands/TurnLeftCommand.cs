using RobotsBackend.Robot;

namespace RobotsBackend.Commands;

internal class TurnLeftCommand : ICommand
{
    public IRobot Robot { get; set; }
    
    public TurnLeftCommand(IRobot robot)
    {
        Robot = robot;
    }

    public void Execute()
    {
        Robot.Direction = Robot.Direction.TurnLeft();
    }
}