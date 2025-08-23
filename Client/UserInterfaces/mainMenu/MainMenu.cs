using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class MainMenu : Control
{
    private Button startClient;
    private Button startServer;

    private Button options;
    private Button quit;
    public override void _Ready()
    {
        startClient = GetNode<Button>("VBoxContainer/StartClient");
        startServer = GetNode<Button>("VBoxContainer/StartServer");

        options = GetNode<Button>("VBoxContainer/Options");
        quit = GetNode<Button>("VBoxContainer/Quit");

        startClient.Pressed += startClientPressed;
        startServer.Pressed += startServerPressed;

        options.Pressed += optionsPressed;
        quit.Pressed += quitPressed;
    }

    private void startClientPressed()
    {
        var nextScene = (PackedScene)ResourceLoader.Load("res://Client/MainDisplay.tscn");
        GetTree().ChangeSceneToPacked(nextScene);
        GD.Print("Nacisnieto start!");
    }
    private void startServerPressed()
    {
        var nextScene = (PackedScene)ResourceLoader.Load("res://Server/ServerMain.tscn");
        GetTree().ChangeSceneToPacked(nextScene);
        GD.Print("Nacisnieto start!");
    }

    private void optionsPressed()
    {
        GD.Print("Nacisnieto opcje!");
    }
    private void quitPressed()
    {
        GetTree().Quit();
        GD.Print("Nacisnieto wyjdz!");
    }
}
