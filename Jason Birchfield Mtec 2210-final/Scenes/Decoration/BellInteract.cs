using Godot;
using System;

public partial class BellInteract : Node3D
{
	[Export] NodePath animationPlayerPath;
	[Export] NodePath audioStreamPlayer3DPath;
	AnimationPlayer animationPlayer;
	AudioStreamPlayer3D audioStreamPlayer3D;
	bool hasBeenRung = false;
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>(animationPlayerPath);
		audioStreamPlayer3D = GetNode<AudioStreamPlayer3D>(audioStreamPlayer3DPath);
	}

	public void RingBell()
	{
		if(!hasBeenRung)
		{
			animationPlayer.Play("Ring");
			audioStreamPlayer3D.Play();
			hasBeenRung = true;
		}
	}

	public void Interact()
	{
		RingBell();	
	}
}
