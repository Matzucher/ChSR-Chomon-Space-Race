using Godot;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
public partial class NetworkingMenager : Node2D
{
    [Export]
    public bool isServer;

    private ENetMultiplayerPeer _peer;
    private int _playerId;

    public override void _Ready()
    {
        if (isServer)
        {
            Globals.Print("<<< START SERVER >>>");
            Multiplayer.PeerConnected += PlayerConnected;
            Multiplayer.PeerDisconnected += PlayerDisconnected;

            HostGame();
        }
        else
        {
            Multiplayer.PeerConnected += PlayerConnected;
            Multiplayer.PeerDisconnected += PlayerDisconnected;
        }
    }

    private void HostGame()
    {
        _peer = new ENetMultiplayerPeer();
        var status = _peer.CreateServer(Globals.Settings.serverPortUDP, 10);
        if (status != Error.Ok)
        {
            Globals.Print("Server could not be created:");
            Globals.Print($"Port: {Globals.Settings.serverPortUDP}");
            return;
        }

        //_peer.Host.Compress(ENetConnection.CompressionMode.RangeCoder);
        Multiplayer.MultiplayerPeer = _peer;
        Globals.Print("Server started SUCCESSFULLY.");
        Globals.Print("Waiting for players to connect ...");
    }

    private void PlayerConnected(long id)
    {
        Globals.Print($"Player <{id}> connected.");
    }

    private void PlayerDisconnected(long id)
    {
        Globals.Print($"Player <{id}> disconected.");
    }
}