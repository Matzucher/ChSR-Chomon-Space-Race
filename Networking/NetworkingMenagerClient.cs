using Godot;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
public partial class NetworkingMenagerClient : Node2D
{
    private ENetMultiplayerPeer _peer;
    private int _playerId;

    public override void _Ready()
    {
        Multiplayer.PeerConnected += PlayerConnected;
        Multiplayer.PeerDisconnected += PlayerDisconnected;
        Multiplayer.ConnectedToServer += ConnectionSuccessful;
        Multiplayer.ConnectionFailed += ConnectionFailed;
        ConnectToServer();
    }

    private void ConnectionFailed()
    {
        Globals.Print("Connection FAILED.");
        Globals.Print("Could not connect to server.");
    }

    private void ConnectionSuccessful()
    {
        Globals.Print("Connection SUCCESSFULL.");

        _playerId = Multiplayer.GetUniqueId();

        Globals.Print(_playerId.ToString() + "Sending player information to server.");
        Globals.Print(_playerId.ToString() + $"Id: {_playerId}");
        
        RpcId(1, "SendPlayerInformation", _playerId);
    }

    private void PlayerConnected(long id)
    {
        Globals.Print(_playerId.ToString() + $"Player <{id}> connected.");
    }

    private void PlayerDisconnected(long id)
    {
        Globals.Print(_playerId.ToString() + $"Player <${id}> disconnected.");
    }

    public void ConnectToServer()
    {
        _peer = new ENetMultiplayerPeer();
        var status = _peer.CreateClient(Globals.Settings.serverIP, Globals.Settings.serverPortUDP);
        if (status != Error.Ok)
        {
            Globals.Print("Creating client FAILED.");
            return;
        }

        Multiplayer.MultiplayerPeer = _peer;
    }
}
