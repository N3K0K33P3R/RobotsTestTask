using System.Drawing;

namespace RobotsBackend.Robot;

internal class Robot : IRobot
{
    public Point Position { get; set; }
    public Direction Direction { get; set; }
    public bool IsLost { get; set; }
}