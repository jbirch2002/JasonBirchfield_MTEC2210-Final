using Godot;
using System;

public partial class FallingDoor : StaticBody3D
{
	[Export] NodePath animationPlayerPath;
	[Export] NodePath audioStreamPlayer3DPath;
	AnimationPlayer animationPlayer;
	AudioStreamPlayer3D audioStreamPlayer3D;
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>(animationPlayerPath);
		audioStreamPlayer3D = GetNode<AudioStreamPlayer3D>(audioStreamPlayer3DPath);
	}

	public void PlayFallingAnimation()
	{
		animationPlayer.Play("Fall");
		audioStreamPlayer3D.Play();
	}

	public void Interact()
	{
		PlayFallingAnimation();
	}
}
