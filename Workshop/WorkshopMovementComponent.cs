using Godot;
using System;

public partial class WorkshopMovementComponent : Area2D
{
	WorkshopManager workshopManager;
	StaticBody2D workshopObject;
	Node2D workshopScene;
	bool dragging = false;

	public override void _Ready()
	{
		workshopScene = GetNode<Node2D>("/root/Workshop");
		workshopManager = GetNode<WorkshopManager>("/root/Workshop/WorkshopManager");
		workshopObject = GetParent<StaticBody2D>();
		GD.Print("MovementComponent ", GetParent().GetName());
        dragging = true;
    }

	public override void _Process(double delta)
	{
		if (Input.IsMouseButtonPressed(MouseButton.Left) && dragging)
		{

			var mouseTile = workshopManager.grid.LocalToMap(workshopManager.grid.ToLocal(workshopScene.GetGlobalMousePosition()));
			var localPosition = workshopManager.grid.MapToLocal(mouseTile);
			var worldPosition = workshopManager.grid.ToGlobal(localPosition);

			workshopObject.GlobalPosition = worldPosition;
		}
	}


	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		if (@event is InputEventMouseButton mouseEvent)
		{
            if (workshopManager.carriedObjectsCount != 1)
            {
                if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
				{
					dragging = true;
					workshopManager.carriedObjectsCount = 1;
					workshopObject.ZIndex++;
				}
			}
			if (!mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
			{
				dragging = false;
				workshopManager.carriedObjectsCount = 0;
			}
		}
	}
}
