using System.Drawing;
using System.Numerics;
using RobotsBackend.Robot;

namespace RobotsBackend.Commands;

internal class MoveForwardCommand : ICommand
{
    private readonly Point _borders;
    private readonly IEnumerable<IRobot> _robotsList;
    public IRobot Robot { get; set; }

    public MoveForwardCommand(IRobot robot, Point borders, IEnumerable<IRobot> robotsList)
    {
        _borders = borders;
        _robotsList = robotsList;
        Robot = robot;
    }

    public void Execute()
    {
        var (x, y) = (Robot.Position.X, Robot.Position.Y);

        MoveRobot(ref y, ref x);

        var isIntersectingWithLostRobots = _robotsList
            .Where(r => r.IsLost)
            .Any(r => r.Position == Robot.Position);
        
        if (x < 0 || x > _borders.X || y < 0 || y > _borders.Y)
        {
            if (!isIntersectingWithLostRobots)
            {
                Robot.IsLost = true;
            }

            return;
        }

        Robot.Position = new Point(x, y);
    }

    private void MoveRobot(ref int y, ref int x)
    {
        switch (Robot.Direction)
        {
            case Direction.North:
                y++;
                break;
            case Direction.East:
                x++;
                break;
            case Direction.South:
                y--;
                break;
            case Direction.West:
                x--;
                break;
        }
    }
}