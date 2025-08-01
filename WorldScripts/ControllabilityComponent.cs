using Godot;
using System;

public partial class ControllabilityComponent : Node
{
    public bool controllable { get; set; }
    public uint owner { get; set; }
}
