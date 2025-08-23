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
		if (OS.IsDebugBuild())
		{
			Text = string.Empty;
			Text += string.Format("Y: {0}\n", Globals.Instance.playerShipPosition.Y);
			Text += string.Format("X: {0}\n", Globals.Instance.playerShipPosition.X);

			Text += string.Format("Y-Vel: {0}\n", Globals.Instance.playerShipLinearVelocity.Y);
			Text += string.Format("X-Vel: {0}\n", Globals.Instance.playerShipLinearVelocity.X);

			Text += string.Format("Acceleration: {0}\n", Globals.Instance.playerShipAcceleration);
			Text += string.Format("Ang-Vel: {0}\n", Globals.Instance.playerShipAngularValocity);
		}
	}
}
