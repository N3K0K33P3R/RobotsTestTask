using System.Drawing;
using RobotsBackend.Commands;
using RobotsBackend.InputHandler;
using RobotsBackend.OuputHandler;
using RobotsBackend.Robot;

namespace RobotsBackend.Field;

internal class FieldManager : IFieldManager
{
    public List<IRobot> RobotsList { get; set; }
    public Point Border { get; set; }

    public FieldManager()
    {
        RobotsList = new List<IRobot>();
    }

    public void SetWorldBorder(Point border)
    {
        Border = border;
    }

    public void AddRobot(IRobot robot)
    {
        RobotsList.Add(robot);
    }

    public void ExecuteRobotCommands(IEnumerable<ICommand> commands)
    {
        foreach (var command in commands)
        {
            command.Execute();
        }
    }
}