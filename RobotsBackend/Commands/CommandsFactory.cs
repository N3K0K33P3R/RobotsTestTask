using RobotsBackend.Field;
using RobotsBackend.Robot;

namespace RobotsBackend.Commands;

internal class CommandsFactory : ICommandsFactory
{
    private readonly IRobot _robot;
    private readonly IFieldManager _fieldManager;

    public CommandsFactory(IRobot robot, IFieldManager fieldManager)
    {
        _robot = robot;
        _fieldManager = fieldManager;
    }
    
    public ICommand CreateCommandFromChar(char command)
    {
        ICommand commandObject = command switch
        {
            'L' => new TurnLeftCommand(_robot),
            'R' => new TurnRightCommand(_robot),
            'F' => new MoveForwardCommand(_robot, _fieldManager.Border, _fieldManager.RobotsList),
            _ => throw new NotImplementedException($"Command {command} is not implemented")
        };

        return new CheckIfRobotIsLostBeforeExecuteCommandWrapper(commandObject, _robot);
    }
}