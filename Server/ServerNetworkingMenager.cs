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

        //error handling for ENet
        Error ENetConectionError = Peer.CreateServer(Globals.Settings.serverPortUDP, 32);
        switch (ENetConectionError)
        {
            case Error.Ok:
                break;
            default:
                GD.Print("ENetMultiplayerPeer swhile trying to createhost for the server: " + ENetConectionError.ToString());
                break;
        }

        Multiplayer.MultiplayerPeer = Peer;
        
    }

    [Signal]
    public delegate void MultiplayerPeerConnectedEventHandler();

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }
}
