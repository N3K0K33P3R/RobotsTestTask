namespace RobotsBackend.ConsoleInput;

public class ConsoleWorker : IConsoleWorker
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }

    public void WriteLine()
    {
        Console.WriteLine();
    }

    public void Write(string output)
    {
        Console.Write(output);
    }
}