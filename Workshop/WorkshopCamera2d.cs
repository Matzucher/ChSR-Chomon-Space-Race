using Godot;

public partial class WorkshopCamera2d : Camera2D
{
	Vector2 maxZoom = new Vector2(2, 2);
	Vector2 zoomVelocity = new Vector2(0.9, 0.9);

	Vector2 mousePreviousPosition = new Vector2(0, 0);
	Vector2 screenStartPosition = new Vector2(0, 0);
	bool dragging = false;

	public override void _Ready()
	{
		GD.Print(IsCurrent());
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			if (Input.IsMouseButtonPressed(MouseButton.Middle))
			{
				mousePreviousPosition = mouseEvent.Position;
				screenStartPosition = Position;
				dragging = true;
			}

			switch (mouseEvent.ButtonIndex)
			{
				case MouseButton.WheelUp:
					if (Zoom / zoomVelocity < maxZoom)
					{
						Zoom = Zoom / zoomVelocity;
					}
					else
					{
						Zoom = maxZoom;
					}
					break;
				case MouseButton.WheelDown:
					Zoom = Zoom * zoomVelocity;
					break;
			}
		}
		else if(@event is InputEventMouseMotion mouseMotion && dragging)
		{
			Position = (mousePreviousPosition - mouseMotion.Position) + screenStartPosition;
		}
		else
		{
			dragging = false;
		}
	}
}
