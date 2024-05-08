using Godot;
using System;

public partial class OpenDoors : Node3D
{
    [Export] NodePath animationPlayerPath;
    AnimationPlayer ap;
    bool isDoorOpen = false;

    public override void _Ready()
    {
        ap = GetNode<AnimationPlayer>(animationPlayerPath);
    }

    public void ToggleDoor()
    {
        if (!isDoorOpen)
        {
            ap.Play("Open");
            isDoorOpen = true; // Set to true when the door opens
        }
        else
        {
            ap.Play("Close");
            isDoorOpen = false; // Set to false when the door closes
        }
    }

    public void Interact()
    {
        GD.Print("Interact method called");
        ToggleDoor();
    }
}
