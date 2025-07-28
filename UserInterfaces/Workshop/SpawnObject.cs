using Godot;
using System;
using System.Threading;

public partial class SpawnObject : Area2D
{
	StaticBody2D workshobObject;
	WorkshopManager workshopManager;

	int nextObjecIndexNumber = 1;

	public override void _Ready()
	{
		workshopManager = GetNode<WorkshopManager>("/root/Workshop/WorkshopManager");
	}


	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
		{
			GD.Print("nacisnieto ", GetName());
			workshopManager.EmitSignal("ItemSelected", GetName(), nextObjecIndexNumber);
			nextObjecIndexNumber++;
		}
	}
}
