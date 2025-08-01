using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ConnectionComponent : Node
{
	public List<CollisionPolygon2D> oldConnectedObjects = new List<CollisionPolygon2D>();
	public List<CollisionPolygon2D> connectedObjects = new List<CollisionPolygon2D>();

	public void GetAllConnectedObjects(List<CollisionPolygon2D> allConnectedObjects)
	{
		allConnectedObjects.Add(GetParent<CollisionPolygon2D>());
		foreach (CollisionPolygon2D connectedObject in connectedObjects)
		{
			if(allConnectedObjects.Count(vis => vis == connectedObject) != 1) // jeśli objekt nie znajduje się w tablicy odwiedzonych obiektów
			{
				ConnectionComponent connectedObjectConnectionComponent = connectedObject.GetNode<ConnectionComponent>("ConnectionComponent");
				connectedObjectConnectionComponent.GetAllConnectedObjects(allConnectedObjects);
			}
		}
	}
}
