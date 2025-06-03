using Godot;
using System;

public partial class RocketObject : RigidBody2D
{
	private const double accelerationSpeed = 0.01f; //tempo zwiększania się przyspieszenia 
	public double maxAcceleration = 30.0f; //maksymalna moc przyspieszenia rakiety
	public double acceleration = 0.0f; //przyspieszenie rakiety

	public double rotationAcceleration = 0.00004f;
	public double rotationVelocity = 0.0f;

	public override void _PhysicsProcess(double delta)
	{

		//przemieszczanie się rakiety
		Vector2 velocityVector = new Vector2(0.0, -acceleration);        
		LinearVelocity += velocityVector.Rotated(Rotation);

		//obrót rakiety
		Rotation += rotationVelocity;
	}

	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.Right))
		{
			rotationVelocity += rotationAcceleration;
		}
		if (Input.IsKeyPressed(Key.Left))
		{
			rotationVelocity -= rotationAcceleration;
		}

		//zapobieganie bardzo mikroskopijnym precyzjom obrotu
		if (Input.IsActionJustReleased("ui_right") || Input.IsActionJustReleased("ui_left"))
		{
			const double precision = 0.0001;
			if (rotationVelocity < precision && rotationVelocity > -precision)
			{
				rotationVelocity = 0.0;
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
