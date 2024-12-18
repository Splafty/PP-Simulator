namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    // Constructors
    public SmallSquareMap(int size) : base(size, size)
    {
        FNext = MoveLogic.BorderNext;
        FNextDiagonal = MoveLogic.BorderNextDiagonal;
    }
}