using Simulator.Maps;
using Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; }

    /// <summary>
    /// CurrentCreatureIndex
    /// </summary>
    private int CurrentCreatureIndex = 0;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[CurrentCreatureIndex % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            char move = char.ToLower(Moves[CurrentCreatureIndex % Moves.Length]);

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
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("The list of creatures cannot be empty.");
        }

        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("Number of creatures must be equal to the number of starting positions.");
        }

        if (string.IsNullOrEmpty(moves))
        {
            throw new ArgumentException("Moves string cannot be empty.");
        }

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].InitMapAndPosition(map, positions[i]);
            map.Add(creatures[i], positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("The simulation has already finished.");
        }

        var direction = DirectionParser.Parse(CurrentMoveName).First();
        CurrentCreature.Go(direction);

        CurrentCreatureIndex++;

        if (CurrentCreatureIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}