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
		Globals.Instance.currentViewport = Globals.Viewport.Workshop;
        

    }
}
