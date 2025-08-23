using Godot;
using System;

public partial class DebugView : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(!OS.IsDebugBuild())
		{
			Visible = false;
		}
	}
}
