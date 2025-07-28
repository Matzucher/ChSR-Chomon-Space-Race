using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ConnectionComponent : Node
{
    public List<StaticBody2D> oldConnectedObjects = new List<StaticBody2D>();
    public List<StaticBody2D> connectedObjects = new List<StaticBody2D>();

    public void GetAllConnectedObjects(List<StaticBody2D> allConnectedObjects)
    {
        allConnectedObjects.Add(GetParent<StaticBody2D>());
        foreach (StaticBody2D connectedObject in connectedObjects)
        {
            if(allConnectedObjects.Count(vis => vis == connectedObject) != 1) // jeśli objekt nie znajduje się w tablicy odwiedzonych obiektów
            {
                ConnectionComponent connectedObjectConnectionComponent = connectedObject.GetNode<ConnectionComponent>("ConnectionComponent");
                connectedObjectConnectionComponent.GetAllConnectedObjects(allConnectedObjects);
            }
        }
    }
}
