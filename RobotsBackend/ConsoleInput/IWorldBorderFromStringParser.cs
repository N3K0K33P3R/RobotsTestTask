using System.Drawing;

namespace RobotsBackend.ConsoleInput;

internal interface IWorldBorderFromStringParser
{
    bool TryParse(string borderString, ref Point border);
}