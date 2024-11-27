using Simulator.Maps;
using Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> IMappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; }

    /// <summary>
    /// CurrentIMappableIndex
    /// </summary>
    private int CurrentMappableIndex = 0;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable => IMappables[CurrentMappableIndex % IMappables.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            char move = char.ToLower(Moves[CurrentMappableIndex % Moves.Length]);

            // Different parser???
            switch (move)
            {
                case 'u':
                    return "up";
                case 'r':
                    return "right";
                case 'd':
                    return "down";
                case 'l':
                    return "left";
                default:
                    return "";
            }
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables == null || mappables.Count == 0)
        {
            throw new ArgumentException("The list of mappables cannot be empty.");
        }

        if (mappables.Count != positions.Count)
        {
            throw new ArgumentException("Number of mappables must be equal to the number of starting positions.");
        }

        if (string.IsNullOrEmpty(moves))
        {
            throw new ArgumentException("Moves string cannot be empty.");
        }

        Map = map;
        IMappables = mappables;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].InitMapAndPosition(map, positions[i]);
            map.Add(mappables[i], positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("The simulation has already finished.");
        }

        var direction = DirectionParser.Parse(CurrentMoveName).First();
        CurrentMappable.Go(direction);

        CurrentMappableIndex++;

        if (CurrentMappableIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}