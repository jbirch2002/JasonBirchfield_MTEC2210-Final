using Godot;
using System;

public partial class FlushToilet : StaticBody3D
{
	[Export] NodePath animationPlayerPath;
	[Export] NodePath audioStreamer3DPath;
	AudioStreamPlayer3D audioStreamPlayer3D;
	AnimationPlayer animationPlayer;
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>(animationPlayerPath);
		audioStreamPlayer3D = GetNode<AudioStreamPlayer3D>(audioStreamer3DPath);
	}

	public void PlayFlushAnimation()
	{
		if(!animationPlayer.IsPlaying())
		{
			animationPlayer.Play("FlushToilet");
			audioStreamPlayer3D.Play();
		}
	}

	public void Interact()
	{
		PlayFlushAnimation();
	}
}
