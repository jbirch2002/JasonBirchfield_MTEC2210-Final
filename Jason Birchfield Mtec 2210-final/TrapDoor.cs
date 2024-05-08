using Godot;
using System;

public partial class TrapDoor : Node3D
{
	[Export] NodePath animationPlayerPath;
	[Export] NodePath trapDoorFloor1Path;
	[Export] NodePath trapDoorFloor2Path;
	[Export] NodePath caveSectionPath;
	CsgBox3D trapDoorFloor1;
	CsgBox3D trapDoorFloor2;
	CsgSphere3D caveSection;
	AnimationPlayer animationPlayer;
	bool isActivated = false;
	public override void _Ready()
	{
		trapDoorFloor1 = GetNode<CsgBox3D>(trapDoorFloor1Path);
		trapDoorFloor2 = GetNode<CsgBox3D>(trapDoorFloor2Path);
		caveSection = GetNode<CsgSphere3D>(caveSectionPath);
		animationPlayer = GetNode<AnimationPlayer>(animationPlayerPath);
	}

	public void ActivateTrapDoor()
	{
		if(!isActivated && !animationPlayer.IsPlaying())
		{
			animationPlayer.Play("Activate");
			isActivated = true;
		}
	}

	public void Interact()
	{
		ActivateTrapDoor();
	}
}
