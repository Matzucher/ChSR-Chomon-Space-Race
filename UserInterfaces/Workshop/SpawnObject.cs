using Godot;
using System;

public partial class SpawnObject : Area2D
{
	StaticBody2D workshobObject;
	WorkshopManager workshopManager;

	public override void _Ready()
	{
		workshopManager = GetNode<WorkshopManager>("/root/Workshop/WorkshopManager");
	}


	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
		{
			workshopManager.EmitSignal("ItemSelected", GetName());
		}
	}
}
