using Godot;
using System;

public partial class Grid : TileMapLayer
{
	int gridSize = 50; //wysokość i szerokość grida
	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Disabled;
		CallDeferred(nameof(GenerateTiles));
	}

	/// <summary>
	/// Ustawia pozycje wszystkich komórek w gridzie
	/// </summary>
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
}
