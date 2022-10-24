using RobotsBackend.ConsoleInput;

namespace RobotsTests.IntegrationTests;

public class IntegrationTest
{
    private const string TestExpectedOutput = @"1 1 E 
3 3 N LOST
2 3 S 
";
    
    [Test]
    public void Robots_Should_CorrectlyExecuteCommands()
    {
        var inputQueue = new Queue<string>();
        inputQueue.Enqueue("5 3");
        inputQueue.Enqueue("1 1 E");
        inputQueue.Enqueue("RFRFRFRF");
        inputQueue.Enqueue("3 2 N");
        inputQueue.Enqueue("FRRFLLFFRRFLL");
        inputQueue.Enqueue("0 3 W");
        inputQueue.Enqueue("LLFFFLFLFL");
        inputQueue.Enqueue(String.Empty);
        
        var consoleWorker = new TestConsoleWorker(inputQueue);

        var consoleEnvironmentFactory = new EnvironmentFactory();
        var consoleInputHandler = consoleEnvironmentFactory.Build(consoleWorker);
        
        consoleInputHandler.Execute();

        Assert.That(consoleWorker.outputString.ToString(), Is.EqualTo(TestExpectedOutput));
    }
}