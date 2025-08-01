using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class AssembleRocket : Button
{
    List<CollisionPolygon2D> workshopObjects;

    public override void _Ready()
	{
		Pressed += ButtonPressed;
	}

	private new void ButtonPressed()
	{
        workshopObjects = GetNode<Node>("../../../").GetChildren().OfType<CollisionPolygon2D>().ToList();
        List<RigidBody2D> newBodies = new List<RigidBody2D>();
		while(workshopObjects.Count > 0)
		{
			var workshopObject = workshopObjects.FirstOrDefault();
			RigidBody2D newBody = new RigidBody2D();
			ConnectionComponent objectsConnectionComponent = workshopObject.GetNode<ConnectionComponent>("ConnectionComponent");
			List<CollisionPolygon2D> allConnectedObjects = new List<CollisionPolygon2D>();

			objectsConnectionComponent.GetAllConnectedObjects(allConnectedObjects);

			workshopObjects = workshopObjects.Except(allConnectedObjects).ToList();

			foreach(CollisionPolygon2D connectedObject in allConnectedObjects)
			{
				Node newObject = connectedObject.Duplicate();
				WorkshopMovementComponent newObjectsMovementComponent = newObject.GetNode<WorkshopMovementComponent>("WorkshopMovementComponent");
				newObject.RemoveChild(newObjectsMovementComponent);
				newBody.AddChild(newObject);
			}
			newBodies.Add(newBody);
		}

		foreach (RigidBody2D newBody in newBodies)
		{
			//var a = GetNode("/root/Node2D/WorldLayer/Viewports/WorldViewport/World").GetChildren();
			Globals.Instance.GetNode<Node2D>(Globals.Instance.worldScenePath).AddChild(newBody);
            newBody.Scale = new Vector2(0.5, 0.5);
            newBody.Skew = 90;

        }
		GD.Print("Materialized ", newBodies.Count, " Bodies");
        Globals.Instance.currentViewport = Globals.Viewport.World;
    }
}
