using Godot;
using System;

public partial class Camera2d : Camera2D
{
	Vector2 maxZoom = new Vector2(2, 2);
	Vector2 zoomVelocity = new Vector2(0.9, 0.9);

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
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
	}
}
