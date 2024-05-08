using Godot;
using System;

public partial class PlayGramophone : Node3D
{
	[Export] NodePath audioStreamPlayer3DPath;
	AudioStreamPlayer3D audioStreamPlayer3D;
	public override void _Ready()
	{
		audioStreamPlayer3D = GetNode<AudioStreamPlayer3D>(audioStreamPlayer3DPath);
		audioStreamPlayer3D.Play();
	}

	public void StopGramophone()
	{
		if(audioStreamPlayer3D.Playing)
		{
			audioStreamPlayer3D.Stop();
		}
	}

	public void Interact()
	{
		StopGramophone();
	}
}
