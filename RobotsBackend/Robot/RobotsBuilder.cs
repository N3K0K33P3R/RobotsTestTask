using System.Drawing;

namespace RobotsBackend.Robot;

internal class RobotsBuilder : IRobotsBuilder
{
    private Robot? _product;

    public RobotsBuilder()
    {
        Reset();
    }
    
    public IRobotsBuilder Reset()
    {
        _product = new Robot();

        return this;
    }

    public IRobotsBuilder SetPosition(int positionX, int positionY)
    {
        _product.Position = new Point(positionX, positionY);

        return this;
    }

    public IRobotsBuilder SetDirection(Direction direction)
    {
        _product.Direction = direction;

        return this;
    }

    public IRobot? GetResult()
    {
        return _product;
    }
}