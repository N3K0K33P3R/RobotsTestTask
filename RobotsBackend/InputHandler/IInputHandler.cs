using System.Drawing;
using RobotsBackend.Commands;
using RobotsBackend.Field;
using RobotsBackend.Robot;

namespace RobotsBackend.InputHandler;

public interface IInputHandler
{
    public void Execute();
}