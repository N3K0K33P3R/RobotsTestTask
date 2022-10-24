using RobotsBackend.Commands;
using RobotsBackend.Field;
using RobotsBackend.Logger;
using RobotsBackend.Robot;

namespace RobotsBackend.ConsoleInput;

internal class CommandsListFromStringDataFactory : ICommandsListFromDataFactory<string>
{
    private readonly ILogger _logger;

    public CommandsListFromStringDataFactory(ILogger logger)
    {
        _logger = logger;
    }
    
    public IEnumerable<ICommand> CreateCommandsFromLine(string line, IRobot robot, IFieldManager fieldManager)
    {
        var commandsFactory = new CommandsFactory(robot, fieldManager);
        
        var commandsList = new List<ICommand>(line.Length);

        try
        {
            commandsList.AddRange(line.Select(t => commandsFactory.CreateCommandFromChar(t)));
        }
        catch (Exception e)
        {
            _logger.LogError($"Unable to parse commands: {e.Message}");
        }

        return commandsList;
    }
}