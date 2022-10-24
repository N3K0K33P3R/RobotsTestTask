using RobotsBackend.InputHandler;

namespace RobotsBackend.ConsoleInput;

public interface IEnvironmentFactory
{
    IInputHandler Build(IConsoleWorker consoleWorker);
}