namespace Simulator.Maps;


public interface IMappable
{
    // Properties
    Point Position { get; }
    public char Symbol { get; }


    // Methods
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point point);
}
