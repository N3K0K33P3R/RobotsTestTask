using RobotsBackend.Logger;
using RobotsBackend.Robot;

namespace RobotsBackend.ConsoleInput;

internal class RobotsBuilderByStringDirector : IRobotsBuilderDirector<string>
{
    private readonly IRobotsBuilder _robotsBuilder;
    private readonly ILogger _logger;

    public RobotsBuilderByStringDirector(
        IRobotsBuilder robotsBuilder,
        ILogger logger)
    {
        _robotsBuilder = robotsBuilder;
        _logger = logger;
    }

    public IRobot? BuildRobotFromData(string robotData)
    {
        _robotsBuilder.Reset();

        try
        {
            var (x, y, direction) = ParseRobotDataFromString(robotData);

            return _robotsBuilder
                .SetPosition(x, y)
                .SetDirection(direction)
                .GetResult();
        }
        catch (Exception e)
        {
            _logger.LogError($"Unable to create robot form given data: {robotData}. {e.Message}");
            return null;
        }
    }

    private (int x, int y, Direction direction) ParseRobotDataFromString(string robotData)
    {
        var splittedRobotData = robotData.Split();

        int x, y;

        try
        {
            x = int.Parse(splittedRobotData[0]);
            y = int.Parse(splittedRobotData[1]);
        }
        catch (FormatException e)
        {
            _logger.LogError($"Invalid coordinates format: {robotData}. {e.Message}");
            throw;
        }

        Direction direction;

        try
        {
            direction = DirectionExt.GetDirectionFromShortName(splittedRobotData[2]);
        }
        catch (FormatException e)
        {
            _logger.LogError($"Invalid direction format: {robotData}. {e.Message}");
            throw;
        }

        return (x, y, direction);
    }
}