using Godot;
using System;


public partial class EnginePowerSlider : VSlider
{
	private Label _label;
	private RigidBody2D _rocketObject;

	public override void _ValueChanged(double accelerationPercentage)
	{
		_rocketObject = GetNode<RigidBody2D>("/root/Node2D/RocketObject");
		var maxAcceleration = (double)_rocketObject.Get("maxAcceleration");
		_rocketObject.Call("ChangeAcceleration",maxAcceleration*(accelerationPercentage/100));

		_label = GetNode<Label>("EnginePowerSliderLabel");
		_label.Text = Convert.ToString(Math.Round(accelerationPercentage, 1));
		
	}
}
