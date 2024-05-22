using Godot;
using System;

public partial class PullLever : Node3D
{
	[Export] NodePath wallPath;
	[Export] NodePath wallAnimationPath;
	[Export] NodePath leverAnimationPath;
	AnimationPlayer wallAnimation;
	AnimationPlayer leverAnimation;
	CsgBox3D wall;
	public override void _Ready()
	{
		leverAnimation = GetNode<AnimationPlayer>(leverAnimationPath);
		if (wallPath != null)
		{
			wall = GetNode<CsgBox3D>(wallPath);
			wallAnimation = GetNode<AnimationPlayer>(wallAnimationPath);
		}
	}

	public void PlayLeverAnimation()
	{
		leverAnimation.Play("PullDown");
		wallAnimation.Play("MoveUp");
	}

	public void Interact()
	{
		PlayLeverAnimation();
	}
}
