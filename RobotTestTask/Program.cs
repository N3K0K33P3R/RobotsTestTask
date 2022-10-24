using RobotsBackend.ConsoleInput;

var consoleWorker = new ConsoleWorker();

var consoleEnvironmentFactory = new EnvironmentFactory();
var consoleInputHandler = consoleEnvironmentFactory.Build(consoleWorker);
    
consoleInputHandler.Execute();