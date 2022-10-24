using RobotsBackend.Logger;

namespace RobotsBackend.ConsoleInput;

internal class ConsoleLogger : ILogger
{
    public void LogError(string message)
    {
        Console.WriteLine(message);
    }
}