using System.Drawing;
using RobotsBackend.Logger;

namespace RobotsBackend.ConsoleInput;

internal class WorldBorderFromStringParser : IWorldBorderFromStringParser
{
    public bool TryParse(string borderString, ref Point border)
    {
        var borderStringSplitted = borderString.Split(' ');

        int x, y;

        try
        {
            x = int.Parse(borderStringSplitted[0]);
            y = int.Parse(borderStringSplitted[1]);
        }
        catch (Exception e)
        {
            return false;
        }

        border = new Point(x, y);
        return true;
    }
}