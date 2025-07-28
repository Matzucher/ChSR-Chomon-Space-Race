using Godot;
using System;

public partial class GoToEditorButton : Button
{
	
	public override void _Ready()
	{
		Pressed += ButtonPressed;
	}

	private new void ButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Workshop/Workshop.tscn");
	}
}
