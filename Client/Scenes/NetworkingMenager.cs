using Godot;
using System;
using System.Collections.Generic;

public partial class NetworkingMenager : Node2D
{
    public static NetworkingMenager Instance { get; private set; }

    ENetMultiplayerPeer Peer;

    //Probably should be moved to a seprate function that will be called when the player goes through a server browser
    //yada yada Thats the problem of the future me and @Iwadiasz when he gets to doing the GPI for that
    public override void _Ready()
    {
        base._Ready();
        NetworkingMenager.Instance = this;
    }

    #region Functions responsible for Creating the Server/Connection to the server and terminating it
    /// <summary>
    /// On Call Network Menager will attempt to connect to the server
    /// </summary>
    /// <param name="serverIP">a correcly formated ip adress (e.g. "127.0.0.1")</param>
    /// <param name="serverPortUDP">UDP port default as of writing is 42069</param>
    public void ConnectToServer(string serverIP, int serverPortUDP)
    {
        Peer = new ENetMultiplayerPeer();
        //error handling for ENet
        Error ENetConectionError = Peer.CreateClient(serverIP, serverPortUDP);
        switch (ENetConectionError)
        {
            case Error.Ok:
                break;
            default:
                GD.Print("Error in ENetMultiplayerPeer while trying to create host: " + ENetConectionError.ToString());
                break;
        }
        Multiplayer.MultiplayerPeer = Peer;
    }
    public void ConnectToServer()
    {
        ConnectToServer(Globals.Settings.serverIP, Globals.Settings.serverPortUDP);
    }

    /// <summary>
    /// On Call Network Menager will attempt to start as a server
    /// </summary>
    /// <param name="serverPortUDP">UDP port of the server, default as of writing: 42069</param>
    /// <param name="maxClients"></param>
    public void StartServer(int serverPortUDP, int maxClients = 32)
    {
        Peer = new ENetMultiplayerPeer();
        //error handling for ENet
        Error ENetConectionError = Peer.CreateServer(serverPortUDP, maxClients);
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
    public void StartServer()
    {
        StartServer(Globals.Settings.serverPortUDP);
    }

    /// <summary>
    /// Call this function if the playr is supposed to leave the server
    /// </summary>
    public void TerminateConnection()
    {
        Peer.Dispose();
        Multiplayer.MultiplayerPeer = null;
    }
    #endregion
}
