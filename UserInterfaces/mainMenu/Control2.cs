using Godot;
using System;

public partial class Control2 : Control
{
    private Node self;

    public override void _Ready()
    {
        self = this;
        var dzieci = self.GetChildren();
        foreach (var d in dzieci)
        {
            if (d.GetChildCount() == 0)
            {
                Button zmiana = d as Button;
                zmiana.Visible = false;
            }
            else
            {
                var dzieci2 = d.GetChildren();
                foreach (var d2 in dzieci2)
                {
                    Button zmiana = d2 as Button;
                    zmiana.Visible = false;
                }
            }
        }
    }
    public void usun()
    {
        self = this;
        var dzieci = self.GetChildren();
        foreach (var d in dzieci)
        {
            if (d.GetChildCount() == 0)
            {
                Button zmiana = d as Button;
                zmiana.Visible = true;
            }
            else
            {
                var dzieci2 = d.GetChildren();
                foreach (var d2 in dzieci2)
                {
                    Button zmiana = d2 as Button;
                    zmiana.Visible = false;
                }
            }
        }
    }

    public void _zamknij()
    {
        self = this;
        var dzieci = self.GetChildren();
        foreach (var d in dzieci)
        {
            if (d.GetChildCount() == 0)
            {
                Button zmiana = d as Button;
                zmiana.Visible = false;
            }
            else
            {
                var dzieci2 = d.GetChildren();
                foreach (var d2 in dzieci2)
                {
                    Button zmiana = d2 as Button;
                    zmiana.Visible = false;
                }
            }
        }
    }
}
