using RobotsBackend.Robot;

namespace RobotsBackend.OuputHandler;

internal interface IOutputHandler
{
    void ShowRobotData(IRobot robot);
}