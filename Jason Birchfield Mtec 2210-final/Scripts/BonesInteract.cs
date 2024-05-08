using Godot;
using System;

public partial class BonesInteract : Node3D
{
    [Export] NodePath audioStreamPlayerPath;
    AudioStreamPlayer3D audioStreamPlayer;
    bool isDoorOpen = false;

    public override void _Ready()
    {
        audioStreamPlayer = GetNode<AudioStreamPlayer3D>(audioStreamPlayerPath);
    }

    public void PlayAudio()
    {
		var newAudio = ResourceLoader.Load<AudioStream>("res://Sounds/Bones sound.mp3");
		if (newAudio != null)
		{
			audioStreamPlayer.Stream = newAudio;
			audioStreamPlayer.Play();
		}
    }

    public void Interact()
    {
        PlayAudio();
    }
}
