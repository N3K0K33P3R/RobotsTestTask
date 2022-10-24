using RobotsBackend.Field;
using RobotsBackend.Robot;

namespace RobotsBackend.Commands;

internal interface ICommandsListFromDataFactory<T>
{
    IEnumerable<ICommand> CreateCommandsFromLine(string line, IRobot robot, IFieldManager fieldManager);
}