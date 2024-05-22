using Godot;
using System;
using System.Diagnostics;

public partial class BellInteract : Node3D
{
	[Export] NodePath animationPlayerPath;
	[Export] NodePath audioStreamPlayer3DPath;
	[Export] NodePath timerPath;
	AnimationPlayer animationPlayer;
	AudioStreamPlayer3D audioStreamPlayer3D;
	Timer timer;
	bool hasBeenRung = false;
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>(animationPlayerPath);
		audioStreamPlayer3D = GetNode<AudioStreamPlayer3D>(audioStreamPlayer3DPath);
		timer = GetNode<Timer>(timerPath);
	}

	public void RingBell()
	{
		if(!hasBeenRung)
		{
			animationPlayer.Play("Ring");
			audioStreamPlayer3D.Play();
			hasBeenRung = true;
			timer.Start(3.0f);
			GD.Print(timer);
		}
	}

	public void Interact()
	{
		RingBell();	
	}

	public void _On_Timer_Timeout()
	{
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/World/end_demo_scene.tscn"));
	}
}
