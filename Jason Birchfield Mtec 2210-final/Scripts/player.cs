using Godot;	
using System;

public partial class Player : CharacterBody3D
{
 	Node3D head = null;
    float currentSpeed = 5.0f;
    [Export] float walkingSpeed = 5.0f;
    [Export] float runningSpeed = 8.0f;
    [Export] float jumpVelocity = 4.5f;

    public const float mouseSens = 3f;
    public float gravity = 900f;

    
    private AudioStreamPlayer footstepPlayer;
    private AudioStream[] woodFootstepSounds = new AudioStream[9];
    private Vector3 lastPosition;

    public override void _Ready()
    {
        head = GetNode<Node3D>("head");
        Input.MouseMode = Input.MouseModeEnum.Captured;
        footstepPlayer = new AudioStreamPlayer();
        AddChild(footstepPlayer);

		LoadFootstepSounds();
		lastPosition = GlobalTransform.Origin;
    }

    #region PlayerMovement
    public override void _PhysicsProcess(double delta)
    {
        ProcessPlayerInput(delta);
        HandleFootstepSounds();
    }

    public void ProcessPlayerInput(double delta)
    {
        Vector3 velocity = Velocity;
        Vector2 inputDir = Input.GetVector("left", "right", "up", "down");
        Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();

        if (!IsOnFloor())
            velocity.Y -= gravity * (float)delta;

        if (Input.IsActionPressed("jump") && IsOnFloor())
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

        if (Input.IsActionPressed("sprint") && IsOnFloor())
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
        head.RotationDegrees = new Vector3(Mathf.Clamp(head.RotationDegrees.X, - 89, 89), head.RotationDegrees.Y, head.RotationDegrees.Z);
        RotateY(Mathf.DegToRad(-mouse.Relative.X * mouseSens));
    }
    #endregion

	#region Audio
	    private void HandleFootstepSounds()
    {
        if (IsOnFloor() && GlobalTransform.Origin.DistanceTo(lastPosition) > 1.0f)
        {
            PlayFootstepSound();
            lastPosition = GlobalTransform.Origin;
        }
    }

	public void LoadFootstepSounds()
	{
		for(int i = 0; i < woodFootstepSounds.Length; i++)
		{
			woodFootstepSounds[i] = (AudioStream)GD.Load($"res://Sounds/WoodFloorFootsteps/Footstep{i + 1}.wav");
		}
	}
    public void PlayFootstepSound()
    {
		if(IsInGroup("Wood"))
		{
			int index = new Random().Next(woodFootstepSounds.Length);
        	footstepPlayer.Stream = woodFootstepSounds[index];
        	footstepPlayer.Play();
		}
    }
	#endregion
}
