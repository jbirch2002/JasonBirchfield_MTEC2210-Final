using Godot;
using System;

public partial class SpawnManager : Node
{
	CharacterBody3D player;

    public override void _Ready()
    {

    }

    public void FetchPlayer()
    {
        player = GetTree().CurrentScene.GetNodeOrNull<CharacterBody3D>("Player");
    }

    public void TeleportPlayerTo(string markerPath)
    {
        FetchPlayer();
        if (player != null)
        {
            var marker = GetTree().CurrentScene.GetNodeOrNull<Marker3D>(markerPath);
            if (marker != null)
            {
                player.GlobalTransform = marker.GlobalTransform;
            }
        }
    }

    public void PrepareForNewScene()
    {
        FetchPlayer();
    }
}
