using System.Text;
using RobotsBackend.ConsoleInput;

namespace RobotsTests.IntegrationTests;

public class TestConsoleWorker : IConsoleWorker
{
    private Queue<string> inputQueue;
    public readonly StringBuilder outputString;

    public TestConsoleWorker(Queue<string> inputQueue)
    {
        this.inputQueue = inputQueue;

        outputString = new StringBuilder();
    }
    
    public string ReadLine()
    {
        return inputQueue.Dequeue();
    }

    public void WriteLine(string output)
    {
        outputString.AppendLine(output);
    }

    public void WriteLine()
    {
        outputString.AppendLine();
    }

    public void Write(string output)
    {
        outputString.Append(output);
    }
}