using Godot;
using System;

public partial class RocketObject : RigidBody2D
{
	public double maxAcceleration = 30.0f; //maksymalna moc przyspieszenia rakiety
	public double acceleration = 0.0f; //przyspieszenie rakiety

	public const double rotationAcceleration = 0.0005f;

	public override void _PhysicsProcess(double delta)
	{

		//przemieszczanie się rakiety
		Vector2 velocityVector = new Vector2(0.0, -acceleration);        
		LinearVelocity += velocityVector.Rotated(Rotation);
	}

	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.Right))
		{
			AngularVelocity += rotationAcceleration;
		}
		if (Input.IsKeyPressed(Key.Left))
		{
			AngularVelocity -= rotationAcceleration;
		}

		//zapobieganie bardzo mikroskopijnym precyzjom obrotu
		if (Input.IsActionJustReleased("ui_right") || Input.IsActionJustReleased("ui_left"))
		{
			const double precision = 0.001f;
			if (AngularVelocity < precision && AngularVelocity > -precision)
			{
				AngularVelocity = 0.0;
			}
		}
	}

	/// <summary>
	///	Metoda zajmuje się płynnym wzrostem i spadkiem przyspieszenia rakiety 
	/// </summary>
	/// <param name="newAcceleration">procentowe przyspieszenie</param>
	public void ChangeAcceleration(double newAcceleration)
	{
		acceleration = newAcceleration;

		//zapobieganie błędom precyzji float
		if (acceleration < 0.01)
		{
			acceleration = 0.0;
		}
	}
}
