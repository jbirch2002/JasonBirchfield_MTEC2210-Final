using Godot;	
using System;

public partial class player : CharacterBody3D
{
	Node3D head = null;
	float currentSpeed = 5.0f;
	[Export] float walkingSpeed = 5.0f;
	[Export] float runningSpeed = 8.0f;
	float jumpVelocity = 4.5f;

	public const float mouseSens = 3f;

	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _Ready()
	{
		head = GetNode<Node3D>("head");
        Godot.Input.MouseMode = Godot.Input.MouseModeEnum.Captured;
	}

	#region PlayerMovement
	public override void _PhysicsProcess(double delta)
	{
		ProcessPlayerInput(delta);
	}

	public void ProcessPlayerInput(double delta)
	{
		Vector3 velocity = Velocity;
        Vector2 inputDir = Godot.Input.GetVector("left", "right", "up", "down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();

		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

		if (Godot.Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = jumpVelocity;

		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * currentSpeed;
			velocity.Z = direction.Z * currentSpeed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, currentSpeed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, currentSpeed);
		}

		if(Godot.Input.IsActionPressed("sprint") && IsOnFloor())
		{
            currentSpeed = runningSpeed;
		}
		else
		{
            currentSpeed = walkingSpeed;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	#endregion

	#region Inputs
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if (@event is InputEventKey eventKey)
		{
			if (eventKey.Pressed && eventKey.Keycode == Key.Escape)
			{
				GetTree().Quit();
			}
			if(eventKey.Pressed && eventKey.Keycode == Key.E)
			{
			// interact logic here
			}
		}

		if(Input.MouseMode == Godot.Input.MouseModeEnum.Captured)
		{
			InputEventMouseMotion mouseMotion = @event as InputEventMouseMotion;
			if (mouseMotion != null)
			{
				HandleCameraRotation(mouseMotion);
			}
		}
	}

	void HandleCameraRotation(InputEventMouseMotion mouse)
	{
		head.RotateX(Mathf.DegToRad(-mouse.Relative.Y * mouseSens));
		head.RotationDegrees = new Vector3(Mathf.Clamp(head.RotationDegrees.X, - 89, 89), head.RotationDegrees.Y, head.RotationDegrees.Z);
		RotateY(Mathf.DegToRad(-mouse.Relative.X * mouseSens));
	}
	#endregion
}
