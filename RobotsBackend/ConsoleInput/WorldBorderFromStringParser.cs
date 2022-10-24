using System.Drawing;
using RobotsBackend.Logger;

namespace RobotsBackend.ConsoleInput;

internal class WorldBorderFromStringParser : IWorldBorderFromStringParser
{
    private readonly ILogger _logger;

    public WorldBorderFromStringParser(ILogger logger)
    {
        _logger = logger;
    }
    
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
            _logger.LogError($"Invalid border format: {borderString}. {e.Message}");
            return false;
        }

        border = new Point(x, y);
        return true;
    }
}