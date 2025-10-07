using Godot;
using System;

// This is still a work in progres as it relies on graphics and I shouldn't start doing graphics stuff befpore finnishing everything else

public partial class ClientMaterial : Node
{
    [Export]
    Globals.SpriteSet Material;

    //temp
    public override void _Ready()
    {
        Globals.Print("_Ready in ClientMaterial");
        //Sprite2D temp = ResourceLoader.Load<Sprite2D>(Globals.pathToTheTextureAtlasSprite);

        ////Globals.TheTextureAtlas.Region = Globals.SpriteSetToAtlasRect(Globals.SpriteSet.PlaceHolder);
        ////GD.Print(Globals.SpriteSetToAtlasRect(Globals.SpriteSet.PlaceHolder));
        ////temp.Texture = Globals.TheTextureAtlas;
        ////AddChild(temp);
        //GD.Print("test");

        //AddChild(temp);
        //base._EnterTree();
    }
}