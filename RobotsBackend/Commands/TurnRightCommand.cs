using RobotsBackend.Robot;

namespace RobotsBackend.Commands;

internal class TurnRightCommand : ICommand
{
    public IRobot Robot { get; set; }
    
    public TurnRightCommand(IRobot robot)
    {
        Robot = robot;
    }

    public void Execute()
    {
        
        
        Robot.Direction = Robot.Direction.TurnRight();
    }
}