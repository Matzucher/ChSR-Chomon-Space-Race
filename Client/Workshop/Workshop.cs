using Godot;

public partial class Workshop : Node2D
{
	WorkshopManager workshopManager;
	public override void _Ready()
	{
		workshopManager = GetNode<WorkshopManager>("WorkshopManager");
		workshopManager.grid = GetNode<TileMapLayer>("Grid");
	}
	/// <summary>
	/// Dodaje obiekt do sceny 
	/// </summary>
	/// <param name="workshopObject">obiekt wybrany przez użytkownika</param>
	public void PlaceObject(CollisionPolygon2D workshopObject)
	{
		AddChild(workshopObject);
	}
}
