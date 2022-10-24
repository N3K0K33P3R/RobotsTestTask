namespace RobotsBackend.Robot;

internal interface IRobotsBuilderDirector<T>
{
    IRobot? BuildRobotFromData(T robotData);
}