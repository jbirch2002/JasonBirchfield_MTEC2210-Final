using Godot;
using System;

public partial class BellInteract : Node3D
{
	[Export] NodePath animationPlayerPath;
	AnimationPlayer animationPlayer;
	bool hasBeenRung = false;
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>(animationPlayerPath);
	}

	public void RingBell()
	{
		if(!hasBeenRung)
		{
			animationPlayer.Play();
			hasBeenRung = true;
		}
	}

	public void Interact()
	{
		RingBell();	
	}
}
