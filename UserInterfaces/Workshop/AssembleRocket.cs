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

		List<RigidBody2D> bodiesToControll = new List<RigidBody2D>();
		foreach (RigidBody2D newBody in newBodies)
		{
			Node controllabillityComponent = new Node();
			controllabillityComponent.Name = "ControllablityComponent";
			controllabillityComponent.SetScript("res://WorldScripts/ControllabilityComponent.cs");
			newBody.AddChild(controllabillityComponent);

			GetNode<Node2D>(Globals.Instance.worldScenePath).AddChild(newBody);
			GD.Print(newBody.GetIndex());
			GD.Print(newBody.GetInstanceId());
			RigidBody2D createdBody = GetNode<RigidBody2D>(string.Format("{0}/{1}", Globals.Instance.worldScenePath, newBody.GetName()));

			if (createdBody.GetChildren().Where(o => Globals.Instance.controlableRocketComponents.Contains(o.GetName())).Count() > 0)
			{
				bodiesToControll.Add(createdBody);
				createdBody.GetNode<ControllabilityComponent>("ControllabilityComponent").controllable = true;
			}

		}
		if (newBodies.Count > 0)
		{
			Camera2D worldCamera = new Camera2D();
			if (Globals.Instance.playerControlledBody[0] == 0)
			{
				worldCamera.Name = "WorldCamera2D";
			}
			else
			{
				var objectwithCamera = GodotObject.InstanceFromId(Globals.Instance.playerControlledBody[0]);
				if (objectwithCamera is RigidBody2D bodyWithCamera)
				{
					worldCamera = bodyWithCamera.GetNode<Camera2D>("WorldCamera2D");
					bodyWithCamera.RemoveChild(GetNode<Camera2D>("WorldCamera2D"));
				}
			}
			

			if (bodiesToControll.Count == 0)
			{
				Globals.Instance.playerControlledBody[0] = newBodies.FirstOrDefault().GetInstanceId();
			}
			else
			{
				Globals.Instance.playerControlledBody[0] = bodiesToControll.FirstOrDefault().GetInstanceId();
			}

			var objectToGetCamera = GodotObject.InstanceFromId(Globals.Instance.playerControlledBody[0]);
			if (objectToGetCamera is RigidBody2D bodyToGetCamera)
			{
				bodyToGetCamera.AddChild(worldCamera);
				worldCamera.Offset = bodyToGetCamera.CenterOfMass;
			}
			GD.Print(worldCamera.IsCurrent());
			worldCamera.MakeCurrent();
			worldCamera.SetScript("res://WorldCamera2d.cs");
		}
		GD.Print("Materialized ", newBodies.Count, " Bodies");
		Globals.Instance.currentViewport = Globals.Viewport.World;
	}
}
