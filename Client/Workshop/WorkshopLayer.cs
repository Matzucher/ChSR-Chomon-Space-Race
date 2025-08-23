using Godot;
using System;

public partial class WorkshopLayer : CanvasLayer
{
    public override void _Process(double delta)
    {
        if (Globals.Instance.currentViewport == Globals.Viewport.Workshop)
        {
            Visible = true;
        }
        else
        {
            Visible = false;
        }
    }
}
