using RobotsBackend.Robot;

namespace RobotsBackend.Commands;

internal interface ICommand
{
    IRobot Robot { get; set; }
    void Execute();
}