using Godot;
using System;

public partial class WorkshopLayer : CanvasLayer
{
	public override void _Process(double delta)
	{
		if (Globals.Instance.currentViewport == Globals.Viewport.Workshop)
		{
			Layer = 1;
		}
		else
		{
			Layer = 0;
		}
	}
}
