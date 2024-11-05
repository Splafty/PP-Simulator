namespace Simulator;

public class Birds : Animals
{
    // Properties
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
}