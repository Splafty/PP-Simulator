using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals
{
    // Properties
    public required string Description { get; init; }
    public uint Size { get; set; } = 3;


    // Methods
    public string Info => $"{Description} <{Size}>";
}