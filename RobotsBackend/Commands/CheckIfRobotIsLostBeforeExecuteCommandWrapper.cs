using RobotsBackend.Robot;

namespace RobotsBackend.Commands;

internal class CheckIfRobotIsLostBeforeExecuteCommandWrapper : ICommand
{
    private readonly ICommand _command;
    public IRobot Robot { get; set; }

    public CheckIfRobotIsLostBeforeExecuteCommandWrapper(ICommand command, IRobot robot)
    {
        _command = command;
        Robot = robot;
    }
    
    public void Execute()
    {
        if (Robot.IsLost)
        {
            return;
        }
        
        _command.Execute();
    }
}