using Godot;
using System;

public partial class OpenDoors : Node3D
{
    Node3D doorHinge;
	AnimationPlayer animationPlayer;
    bool isOpen = false; 

    public override void _Ready()
    {
		animationPlayer = GetNode<AnimationPlayer>("DoorAnimation");
        doorHinge = GetNode<Node3D>(".");
    }

    public override void _Process(double delta)
    {
		if(Input.IsActionJustPressed("interact") && isOpen == false)
		{
			animationPlayer.Play("OpenDoor");
			isOpen = true;
		}
		else if(Input.IsActionJustPressed("interact") && isOpen == true)
		{
			animationPlayer.PlayBackwards("OpenDoor");
			isOpen = false;
		} 
    }


}