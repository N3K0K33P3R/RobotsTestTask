using RobotsBackend.Field;
using RobotsBackend.InputHandler;
using RobotsBackend.Robot;

namespace RobotsBackend.ConsoleInput;

public class EnvironmentFactory : IEnvironmentFactory
{
    public IInputHandler Build(IConsoleWorker consoleWorker)
    {
        var consoleLogger = new ConsoleLogger();
        var worldBorderFromStringParser = new WorldBorderFromStringParser();
        var robotsBuilder = new RobotsBuilder();
        var robotsBuilderByStringDirector = new RobotsBuilderByStringDirector(robotsBuilder, consoleLogger);
        var commandsListFromStringDataFactory = new CommandsListFromStringDataFactory(consoleLogger);
        var field = new FieldManager();

        return new ConsoleInputHandler(
            worldBorderFromStringParser,
            robotsBuilderByStringDirector,
            commandsListFromStringDataFactory,
            new ConsoleOutputHandler(consoleWorker),
            field,
            consoleLogger,
            consoleWorker);
    }
}