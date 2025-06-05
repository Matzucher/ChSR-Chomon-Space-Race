using Godot;
using System;

public partial class VectorArrowDrawer : Node2D
{
	private RigidBody2D _rocketObject;

	public override void _Process(double delta)
	{
		QueueRedraw();
	}

	public override void _Draw()
	{
		_rocketObject = GetNode<RigidBody2D>("/root/Node2D/RocketObject");
		var begin = new Vector2(0, 0);
		var end = _rocketObject.LinearVelocity;
		DrawLine(begin, end, Colors.Red , 3);
	}
}
