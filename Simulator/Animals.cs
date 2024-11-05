using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals
{
    // Properties
    private string description = "Unknown";
    public required string Description
    {
        get => description;
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";


    // Methods
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}