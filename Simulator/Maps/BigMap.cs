namespace Simulator.Maps;

public abstract class BigMap : Map
{
    // Constructors
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide.");
        }

        if (sizeY > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high.");
        }
    }
}
