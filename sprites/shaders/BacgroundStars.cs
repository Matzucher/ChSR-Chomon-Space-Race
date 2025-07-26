using Godot;
using System;
using static Godot.TextServer;

public partial class BacgroundStars : ColorRect
{
    public override void _Process(double delta)
    {
        Vector2 relativePos = (this.Position);

        relativePos = new Vector2(Math.Abs(relativePos.X + 1048576.0), Math.Abs(relativePos.Y + 1048576.0));
        relativePos = relativePos / 8196.0;



        var material = this.Material;
        ((ShaderMaterial)material).SetShaderParameter("relativePosX", (float)relativePos.X);
        ((ShaderMaterial)material).SetShaderParameter("relativePosY", (float)relativePos.Y);
    }
}
