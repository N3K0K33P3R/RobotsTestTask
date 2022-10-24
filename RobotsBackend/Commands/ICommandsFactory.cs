namespace RobotsBackend.Commands;

internal interface ICommandsFactory
{
    ICommand CreateCommandFromChar(char command);
}