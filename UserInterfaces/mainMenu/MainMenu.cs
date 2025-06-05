using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class MainMenu : Control
{
    private Button start;
    private Button options;
    private Button quit;
    public override void _Ready()
    {
        start = GetNode<Button>("VBoxContainer/Start");
        options = GetNode<Button>("VBoxContainer/Options");
        quit = GetNode<Button>("VBoxContainer/Quit");
        start.Pressed += startPressed;
        options.Pressed += optionsPressed;
        quit.Pressed += quitPressed;
    }

    private void startPressed()
    {
        var nextScene = (PackedScene)ResourceLoader.Load("res://Node2d.tscn");
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
