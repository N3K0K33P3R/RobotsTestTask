using System.Drawing;
using RobotsBackend.Commands;
using RobotsBackend.Field;
using RobotsBackend.InputHandler;
using RobotsBackend.Logger;
using RobotsBackend.OuputHandler;
using RobotsBackend.Robot;

namespace RobotsBackend.ConsoleInput;

public class ConsoleInputHandler : IInputHandler
{
    private IFieldManager _fieldManager;
    private readonly ILogger _logger;
    private readonly IConsoleWorker _consoleWorker;
    private readonly IWorldBorderFromStringParser _worldBorderFromStringParser;
    private readonly IRobotsBuilderDirector<string> _robotsBuilderDirector;
    private readonly ICommandsListFromDataFactory<string> _commandsListFromDataFactory;
    private readonly IOutputHandler _outputHandler;

    internal ConsoleInputHandler(
        IWorldBorderFromStringParser worldBorderFromStringParser,
        IRobotsBuilderDirector<string> robotsBuilderDirector,
        ICommandsListFromDataFactory<string> commandsListFromDataFactory,
        IOutputHandler outputHandler,
        IFieldManager fieldManager,
        ILogger logger,
        IConsoleWorker consoleWorker)
    {
        _worldBorderFromStringParser = worldBorderFromStringParser;
        _robotsBuilderDirector = robotsBuilderDirector;
        _commandsListFromDataFactory = commandsListFromDataFactory;
        _outputHandler = outputHandler;
        _fieldManager = fieldManager;
        _logger = logger;
        _consoleWorker = consoleWorker;
    }

    private Point GetWorldBorder()
    {
        Point parsedBorder = default;

        var border = _consoleWorker.ReadLine();
        while (!_worldBorderFromStringParser.TryParse(border, ref parsedBorder))
        {
            _logger.LogError($"Unable to parse given border: {border}");
            border = Console.ReadLine();
        }

        return parsedBorder;
    }

    private IRobot? InitializeRobot()
    {
        var robotData = _consoleWorker.ReadLine();
        return _robotsBuilderDirector.BuildRobotFromData(robotData);
    }

    private IEnumerable<ICommand> GetRobotCommandsList(IRobot robot)
    {
        var commandsListString = _consoleWorker.ReadLine();
        return _commandsListFromDataFactory.CreateCommandsFromLine(commandsListString, robot, _fieldManager);
    }

    public void Execute()
    {
        var border = GetWorldBorder();
        _fieldManager.SetWorldBorder(border);

        while (true)
        {
            var robot = InitializeRobot();

            if (robot == null)
            {
                break;
            }
            
            _fieldManager.AddRobot(robot);

            var commands = GetRobotCommandsList(robot);
            _fieldManager.ExecuteRobotCommands(commands);
            
            _outputHandler.ShowRobotData(robot);
        }
    }
}