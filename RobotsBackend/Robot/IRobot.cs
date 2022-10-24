using System.Drawing;

namespace RobotsBackend.Robot;

internal interface IRobot
{
    Point Position { get; set; }
    Direction Direction { get; set; }

    bool IsLost { get; set; }
}