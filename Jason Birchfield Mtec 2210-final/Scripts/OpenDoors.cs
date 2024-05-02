using Godot;
using System;

public partial class OpenDoors : Node3D
{
    [Export] AnimationPlayer animationPlayer;
    Timer timer;
    bool isOpen = false;

    public void OpenDoor()
    {
        isOpen = !isOpen;

        if(isOpen == false)
        {
            animationPlayer.Play("OpenDoor");
        }
        if(isOpen == true)
        {
            animationPlayer.PlayBackwards("OpenDoor");
        }
    }

}