namespace RobotsBackend.Robot;

internal interface IRobotsBuilder
{
    IRobotsBuilder Reset();
    IRobotsBuilder SetPosition(int positionX, int positionY);
    IRobotsBuilder SetDirection(Direction direction);
    IRobot? GetResult();
}