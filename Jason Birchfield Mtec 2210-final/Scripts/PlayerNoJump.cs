using Godot;
using System;

public partial class PlayerNoJump : CharacterBody3D
{
	Node3D head = null;
	CollisionShape3D collider = null;
	float currentSpeed = 5.0f;
	[Export] float walkingSpeed = 5.0f;
	[Export] float runningSpeed = 8.0f;
	[Export] float crouchingSpeed = 2.5f;
	float standingHeight;
	[Export] float crouchingHeight = .5f;

	public const float mouseSens = 3f;

	public float gravity = 900f;

	private bool isCrouching = false;

	public override void _Ready()
	{
		head = GetNode<Node3D>("head");
		collider = GetNode<CollisionShape3D>("Collider");
		
		if (collider.Shape is BoxShape3D boxShape)
		{
			standingHeight = boxShape.Size.Y;
			GD.Print("Initial standing height: ", standingHeight);
		}
		else
		{
			GD.PrintErr("Collider shape is not a BoxShape3D!");
		}
		
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	#region PlayerMovement
	public override void _PhysicsProcess(double delta)
	{
		ProcessPlayerInput(delta);
	}

	public void ProcessPlayerInput(double delta)
	{
		Vector3 velocity = Velocity;
		Vector2 inputDir = Input.GetVector("left", "right", "up", "down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();

		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

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

		if (Input.IsActionPressed("sprint") && IsOnFloor() && !isCrouching)
		{
			currentSpeed = runningSpeed;
		}
		else if (isCrouching)
		{
			currentSpeed = crouchingSpeed;
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

			if (eventKey.Pressed && eventKey.Keycode == Key.C)
			{
				ToggleCrouch();
			}
		}

		if (Input.MouseMode == Input.MouseModeEnum.Captured)
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
		head.RotationDegrees = new Vector3(Mathf.Clamp(head.RotationDegrees.X, -89, 89), head.RotationDegrees.Y, head.RotationDegrees.Z);
		RotateY(Mathf.DegToRad(-mouse.Relative.X * mouseSens));
	}

	private void ToggleCrouch()
	{
		if (collider == null || collider.Shape == null)
		{
			GD.PrintErr("Cannot toggle crouch because the collider or its shape is not properly assigned.");
			return;
		}

		isCrouching = !isCrouching;
		
		if (collider.Shape is BoxShape3D boxShape)
		{
			Vector3 size = boxShape.Size;
			size.Y = isCrouching ? crouchingHeight : standingHeight;
			boxShape.Size = size;
			head.Position = new Vector3(head.Position.X, isCrouching ? crouchingHeight / 2 : standingHeight / 2, head.Position.Z);
		}
		else
		{
			GD.PrintErr("Collider shape is not a BoxShape3D!");
		}
	}
	#endregion

	#region Spawns

	#endregion
}

