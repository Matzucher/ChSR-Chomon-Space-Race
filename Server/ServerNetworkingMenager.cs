using Godot;
using System;

/// <summary>
/// A Singleton that menages Server side networking
/// </summary>
public partial class ServerNetworkingMenager : Node
{
    public static ServerNetworkingMenager Instance { get; private set; }

    /// <summary>
    /// The main ENet instance
    /// </summary>
    ENetMultiplayerPeer Peer;

    public override void _Ready()
    {
        base._Ready();
        ServerNetworkingMenager.Instance = this;
        Peer = new ENetMultiplayerPeer();


        
    }

    [Signal]
    public delegate void MultiplayerPeerConnectedEventHandler();

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }
}
