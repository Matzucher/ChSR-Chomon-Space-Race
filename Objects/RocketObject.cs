using Godot;
using System;

public partial class RocketObject : RigidBody2D
{
	public double maxAcceleration = 1000.0; //maksymalna moc przyspieszenia rakiety
	public double acceleration = 0.0; //przyspieszenie rakiety

	public double rotationAcceleration = 0.0;

	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		Vector2 valocityVector = new Vector2(0.0, -acceleration);
		state.ApplyForce(valocityVector.Rotated(Rotation));

		state.ApplyTorque(rotationAcceleration);
	}

	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.Right))
		{
			rotationAcceleration = 2000.0;
            if (rotationAcceleration > 20000.0)
            {
                rotationAcceleration = 20000.0;
            }
        }
		if (Input.IsKeyPressed(Key.Left))
		{
			rotationAcceleration = -2000.0;
			if (rotationAcceleration < -20000.0)
			{
				rotationAcceleration = -20000.0;
			}
		}
		if (!(Input.IsKeyPressed(Key.Left) || Input.IsKeyPressed(Key.Right)))
		{
            rotationAcceleration = -0;
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
