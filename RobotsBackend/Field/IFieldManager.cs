using System.Drawing;
using RobotsBackend.Commands;
using RobotsBackend.Robot;

namespace RobotsBackend.Field;

internal interface IFieldManager
{
    public List<IRobot> RobotsList { get; set; }
    public Point Border { get; set; }

    void SetWorldBorder(Point border);
    void AddRobot(IRobot robot);
    void ExecuteRobotCommands(IEnumerable<ICommand> commands);
}