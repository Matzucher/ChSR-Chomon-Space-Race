using Godot;
using System;

public partial class CollapsingButtons : Button
{
    private Button guzik1;
    private Button guzik2;
    private Button guzik3;
    private Control2 rodzic;
    public override void _Ready()
    {
        guzik1 = GetNode<Button>("B1");
        guzik2 = GetNode<Button>("B2");
        guzik3 = GetNode<Button>("B3");
        rodzic = GetParent<Control2>();
    }

    private void _on_pressed()
    {
        rodzic.usun();
        guzik1.Visible = true;
        guzik2.Visible = true;
        guzik3.Visible = true;

    }
}
