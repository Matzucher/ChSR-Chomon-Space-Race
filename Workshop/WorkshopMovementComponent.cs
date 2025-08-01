using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using static Godot.HttpRequest;

public partial class WorkshopMovementComponent : Area2D
{
	WorkshopManager workshopManager;
	CollisionPolygon2D workshopObject;
	Node2D workshopScene;
	bool dragging = false;
	List<Marker2D> markers = new List<Marker2D>();
	ConnectionComponent connectionComponent;

	public override void _Ready()
	{
		//szukanie wszystkih connecting pointów obiektu i wrzucanie ich do licty
		foreach (Node child in GetChildren())
		{
			if (child is Marker2D marker)
			{
				markers.Add(marker);
			}
		}
		GD.Print("Found " + markers.Count + " Marker2D nodes.");

		workshopScene = GetNode<Node2D>("../../");
		workshopManager = GetNode<WorkshopManager>("../../WorkshopManager");
		workshopObject = GetParent<CollisionPolygon2D>();
		connectionComponent = GetParent().GetNode<ConnectionComponent>("ConnectionComponent");
		GD.Print("MovementComponent ", GetParent().GetName(), " My Parent is ", GetParent().GetParent().GetName());
		dragging = true;
	}

	public override void _Process(double delta)
	{
		//algorytm przesówania obiektu względem kursora
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
					
				}
			}
			if (!mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
			{
				dragging = false;
				workshopManager.carriedObjectsCount = 0;
				workshopObject.GetNode<Sprite2D>("Sprite2D").ZIndex = 2;

				//po upuszczeniu obiektu zapisz wszystkie stykające obiekty
				connectionComponent.oldConnectedObjects = connectionComponent.connectedObjects;
				connectionComponent.connectedObjects = new List<CollisionPolygon2D>();
				///uzupełnianie własnej listy połączonych obiektów
				foreach (Marker2D marker in markers)
				{
					Marker2D? foundMarker = FindMarkerAtPosition(marker.GlobalPosition);
					if(foundMarker != null)
					{
						connectionComponent.connectedObjects.Add(foundMarker.GetParent().GetParent<CollisionPolygon2D>());
					}
				}
				connectionComponent.connectedObjects = connectionComponent.connectedObjects.Distinct().ToList();
				///usuwanie się z list innych obiektów w przypadku odłączenia się od nich
				List<CollisionPolygon2D> disconectedObjects = connectionComponent.oldConnectedObjects.Except(connectionComponent.connectedObjects).ToList();
				foreach(CollisionPolygon2D disconnectedObject in disconectedObjects)
				{
					ConnectionComponent disconnectedObjectsConnectionComponent = disconnectedObject.GetNode<ConnectionComponent>("ConnectionComponent");
					disconnectedObjectsConnectionComponent.connectedObjects.Remove(GetParent<CollisionPolygon2D>());
				}

				///aktualizowanie list połączonych z tym obiektem
				foreach(Node connectedObject in connectionComponent.connectedObjects)
				{
					ConnectionComponent objectsConnectionComponent = connectedObject.GetNode<ConnectionComponent>("ConnectionComponent");
					objectsConnectionComponent.connectedObjects.Add(GetParent<CollisionPolygon2D>());
					objectsConnectionComponent.connectedObjects = objectsConnectionComponent.connectedObjects.Distinct().ToList();
				}

				///DEBUG wypisz wszystkie listy obiektów
				GD.Print("New Iteration________________________________________");
				foreach (Node workshopMovementComponent in GetTree().GetNodesInGroup("WorkshopMovementComponents"))
				{
					GD.Print(workshopMovementComponent.GetParent().GetName(), ":");
					ConnectionComponent objectsConnectionComponent = workshopMovementComponent.GetParent().GetNode<ConnectionComponent>("ConnectionComponent");
					foreach(Node connectedObject in  objectsConnectionComponent.connectedObjects)
					{
						GD.Print("\t",connectedObject.GetName());
					}
				}
			}
		}
	}

	/// <summary>
	/// Funkcja sprawdza czy w pozycji markera nie znajduje się inny marker
	/// </summary>
	/// <param name="position"></param>
	/// <returns>zwraca znaleziony marker lub null</returns>
	private Marker2D FindMarkerAtPosition(Vector2 position)
	{
		double PositionTolerance = 1.0;
		foreach (var workshopMovementComponent in GetTree().GetNodesInGroup("WorkshopMovementComponents"))
		{
			if (workshopMovementComponent.GetParent().GetName() != GetParent().GetName())
			{
				foreach (Marker2D marker in workshopMovementComponent.GetChildren().OfType<Marker2D>())
				{
					if (marker.GlobalPosition.DistanceTo(position) <= PositionTolerance)
					{
						return marker;
					}
				}
			}
		}
		return null; // Nie Znaleziono
	}
}
