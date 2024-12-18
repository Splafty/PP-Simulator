namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    // Constructors
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        FNext = MoveLogic.TorusNext;
        FNextDiagonal = MoveLogic.TorusNextDiagonal;
    }
}
