using Godot;
using System;

public partial class WorkshopTileMap : TileMapLayer
{
	int gridSize = 50;
	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Disabled;
		CallDeferred(nameof(GenerateTiles));
	}

	private void GenerateTiles()
	{
		for (int x = 0; x < gridSize; x++)
		{
			for (int y = 0; y < gridSize; y++)
			{
				SetCell(new Vector2I(x, y), 0, new Vector2I(0, 0), 0);
			}
		}
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
