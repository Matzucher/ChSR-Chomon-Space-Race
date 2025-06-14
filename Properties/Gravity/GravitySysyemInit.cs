using Godot;
using System;
using System.Drawing;

public partial class GravitySysyemInit : Node2D
{
    //the minimum distance that objects are alowed to symulate as their gravitational pull
    private static double minDistance = 0.1; //avoiding the infinite acceleration glich

    private struct Quad
    {
        //the center of the Quad
        Vector2 center;

        //the size of the Quad
        double size;
    }

    private struct Node
    {
        //Position and size of the node
        Quad quad;

        unsafe fixed UInt32 children[4];
    }
    

}
