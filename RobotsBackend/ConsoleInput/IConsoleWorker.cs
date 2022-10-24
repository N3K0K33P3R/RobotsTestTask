namespace RobotsBackend.ConsoleInput;

public interface IConsoleWorker
{
    string ReadLine();
    void WriteLine(string output);
    void WriteLine();
    void Write(string output);
}