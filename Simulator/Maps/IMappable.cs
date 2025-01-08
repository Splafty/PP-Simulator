using System.Text.Json.Serialization;

namespace Simulator.Maps;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Elf), nameof(Elf))]
[JsonDerivedType(typeof(Orc), nameof(Orc))]
[JsonDerivedType(typeof(Animals), nameof(Animals))]
[JsonDerivedType(typeof(Birds), nameof(Birds))]

public interface IMappable
{
    // Properties
    Point Position { get; }
    public char Symbol { get; }


    // Methods
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point point);
    public string ToString();
}
