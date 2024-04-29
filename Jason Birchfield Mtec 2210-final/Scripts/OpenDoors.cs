using Godot;
using System;

public partial class OpenDoors : Node3D
{
    [Export] private NodePath animationPlayerPath;  // Set this path in the Godot editor!

    private AnimationPlayer animationPlayer;
    private bool isOpen = false;
    private bool playerIsNear = false;  // Flag to check if player is near

    public override void _Ready()
    {
        animationPlayer = GetNode<AnimationPlayer>(animationPlayerPath);
        var doorArea = GetNode<Area3D>("area3d");
    }

    // Method to be called from InteractRay script or similar interaction script
    public void ToggleDoor()
    {
        if (playerIsNear)  // Only toggle the door if the player is near
        {
            if (!isOpen)
            {
                animationPlayer.Play("OpenDoor");
                isOpen = true;
            }
            else
            {
                animationPlayer.PlayBackwards("OpenDoor");
                isOpen = false;
            }
        }
    }

    public void OnBodyEntered(Node body)
    {
        if (body is Player)  // Check if the player has entered the area
        {
            playerIsNear = true;  // Set playerIsNear to true
        }
    }

    public void OnBodyExited(Node body)
    {
        if (body is Player)  // Check if the player has exited the area
        {
            playerIsNear = false;  // Set playerIsNear to false
        }
    }
}