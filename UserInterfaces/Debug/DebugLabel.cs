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
			Text += string.Format("Y: {0}\n", _rocketObject.Position.Y);
			Text += string.Format("X: {0}\n", _rocketObject.Position.X);
			Text += string.Format("Y-Vel: {0}\n", _rocketObject.LinearVelocity.Y);
			Text += string.Format("X-Vel: {0}\n", _rocketObject.LinearVelocity.X);
			Text += string.Format("Acceleration: {0}\n", _rocketObject.Get("acceleration"));

			Text += string.Format("Ang-Vel: {0}\n", _rocketObject.AngularVelocity); // THIS is angualr velocity
			Text += string.Format("Torque: {0}\n", _rocketObject.Get("rotationVelocity")); //@MATZUHER this never was Velocity you aboslute troll
		}
	}
}
