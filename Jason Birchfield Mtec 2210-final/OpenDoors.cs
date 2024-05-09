using Godot;
using System;

public partial class OpenDoors : Node3D
{
    [Export] NodePath animationPlayerPath;
    [Export] NodePath openDoorAudioPath;
    [Export] NodePath closeDoorAudioPath;
    AnimationPlayer animationPlayer;
    AudioStreamPlayer3D audioStreamPlayer3D;
    AudioStreamPlayer3D audioStreamPlayer3D2;
    bool isDoorOpen = false;

    public override void _Ready()
    {
        animationPlayer = GetNode<AnimationPlayer>(animationPlayerPath);
        audioStreamPlayer3D = GetNode<AudioStreamPlayer3D>(openDoorAudioPath);
        audioStreamPlayer3D2 = GetNode<AudioStreamPlayer3D>(closeDoorAudioPath);
    }

    public void ToggleDoor()
    {
        if (!isDoorOpen)
        {
            animationPlayer.Play("Open");
            isDoorOpen = true;
            audioStreamPlayer3D.Play();
        }
        else
        {
            animationPlayer.Play("Close");
            isDoorOpen = false;
            audioStreamPlayer3D2.Play();
        }
    }

    public void Interact()
    {
        GD.Print("Interact method called");
        ToggleDoor();
    }
}
