namespace Simulator;

public class Birds : Animals
{
    // Properties
    public override char Symbol => CanFly ? 'B' : 'b';

    private bool canFly = true;
    public bool CanFly
    {
        get => canFly;
        init
        {
            canFly = value;
        }
    }

    public override string Info => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";


    // Constructors
    public Birds(string description, int size = 3, bool canFly = true) : base(description, size)
    {
        CanFly = canFly;
    }

    public Birds() { }


    // Methods
    public override void Go(Direction direction)
    {
        if (Map == null)
        {
            return;
        }

        Point nextPosition;
        if (CanFly)
        {
            nextPosition = Map.Next(Map.Next(Position, direction), direction);
        }
        else
        {
            nextPosition = Map.NextDiagonal(Position, direction);
        }

        Map.Move(this, Position, nextPosition);
        Position = nextPosition;
    }
}