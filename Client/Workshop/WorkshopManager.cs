using Godot;
using Godot.Collections;
using System;

public partial class WorkshopManager : Node
{
	[Signal]
	public delegate void ItemSelectedEventHandler(string objectName);

	public TileMapLayer grid;
	public int carriedObjectsCount = 0;
	public override void _Ready()
	{
		Connect("ItemSelected", new Callable(this, "ItemSelect"));
	}

	/// <summary>
	/// Metoda tworzy obiekt StaticBody2D na Scenie
	/// </summary>
	/// <param name="objectName">nazwa obiektu (!!Katalog obiektu musi nazywać się tak samo jak jego folder!!)</param>
	/// <param name="nextObjectIndexNumber">identyfikator obiektu </param>
	public void ItemSelect(string objectName, int nextObjectIndexNumber)
	{
		string path = string.Format("res://Objects/{0}/{0}.tscn", objectName);
        CollisionPolygon2D workshopObject = GD.Load<PackedScene>(path).Instantiate<CollisionPolygon2D>();
		GetTree().CallGroup("OfficeGroup", "PlaceObject", workshopObject);
		workshopObject.Name = string.Format(objectName, nextObjectIndexNumber);
		GD.Print("Utworzono obiekt	", workshopObject.GetName());
		carriedObjectsCount = 1;
	}
}
