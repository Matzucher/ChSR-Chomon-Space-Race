using Godot;
using System;


/// <summary>
/// Debugowe UI, którego nie widać na releasowim buildzie
/// </summary>
public partial class DebugLabel : Label
{
	private RigidBody2D _rocketObject;

	public override void _Process(double delta)
	{
		_rocketObject = GetNode<RigidBody2D>("/root/Node2D/RocketObject");
		if (OS.IsDebugBuild())
		{
			Text = string.Empty;
			Text += string.Format("Y-Velocity: {0}\n", _rocketObject.LinearVelocity.Y);
			Text += string.Format("X-Velocity: {0}\n", _rocketObject.LinearVelocity.X);
			Text += string.Format("Acceleration: {0}\n", _rocketObject.Get("acceleration"));
			Text += string.Format("RotationVelocity: {0}\n", _rocketObject.Get("rotationVelocity"));
		}
	}
}
