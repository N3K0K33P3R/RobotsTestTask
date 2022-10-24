using RobotsBackend.OuputHandler;
using RobotsBackend.Robot;

namespace RobotsBackend.ConsoleInput;

internal class ConsoleOutputHandler : IOutputHandler
{
    private readonly IConsoleWorker _consoleWorker;

    public ConsoleOutputHandler(IConsoleWorker consoleWorker)
    {
        _consoleWorker = consoleWorker;
    }
    
    public void ShowRobotData(IRobot robot)
    {
        _consoleWorker.Write($"{robot.Position.X} {robot.Position.Y} {robot.Direction.ToString()[0]} ");

        if (robot.IsLost)
        {
            _consoleWorker.Write("LOST");
        }

        _consoleWorker.WriteLine();
    }
}