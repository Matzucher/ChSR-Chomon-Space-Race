using Godot;
using System;

public partial class RocketObject : RigidBody2D
{
    const double precision = 0.005f;
    public static double maxAcceleration = 30.0f; //maksymalna moc przyspieszenia rakiety
	public double acceleration = 0.0f; //przyspieszenie rakiety

	public const double rotationAccelerationStep = 0.005f;
    public const double rotationAccelerationMax = 0.005f;
    public double rotationAcceleration = 0.0000f;


    public override void _Ready()
    {
		Globals.Instance.playerShipMaxAcceleration = maxAcceleration;
	}
	public override void _PhysicsProcess(double delta)
	{
		//update accelaration from slider
		acceleration = Globals.Instance.playerShipNewAcceleration;


        //przemieszczanie się rakiety
        Vector2 velocityVector = new Vector2(0.0, -acceleration);        
		LinearVelocity += velocityVector.Rotated(Rotation);
		

        Globals.Instance.playerShipPosition = Position; //FIX ME: this is laging 1 frame behind the accual position
        Globals.Instance.playerShipLinearVelocity = LinearVelocity;
		Globals.Instance.playerShipAcceleration = acceleration;
		Globals.Instance.playerShipAngularValocity = AngularVelocity; 
    }

    public override void _Process(double delta)
	{
        if (!(Input.IsKeyPressed(Key.Right) || Input.IsKeyPressed(Key.Left)))
        {
            rotationAcceleration = 0.0;
        }
        if (Input.IsKeyPressed(Key.Right))
		{
			rotationAcceleration += rotationAccelerationStep;
        }
		else if (Input.IsKeyPressed(Key.Left))
		{
			rotationAcceleration -= rotationAccelerationStep;
        }

        if (AngularVelocity < precision && AngularVelocity > -precision)
        {
            AngularVelocity = 0.0;
        }



		AngularVelocity += rotationAcceleration;
        rotationAcceleration = rotationAcceleration * 0.3;
	}

    /// <summary>
    ///	Metoda zajmuje się płynnym wzrostem i spadkiem przyspieszenia rakiety 
    /// </summary>
    /// <param name="newAcceleration">procentowe przyspieszenie</param>
    private void ChangeAcceleration(double newAcceleration)
	{
		acceleration = newAcceleration;

		//zapobieganie błędom precyzji float
		if (acceleration < 0.01)
		{
			acceleration = 0.0;
		}
	}
}
