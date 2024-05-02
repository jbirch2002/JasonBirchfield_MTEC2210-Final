using Godot;
using System.Collections.Generic;
using System;

public partial class InteractionManager : Node3D
{
	CharacterBody3D player;
	Label label;
	string text = "[E] to ";
	 private List<InteractionArea> activeAreas = new();
	bool canInteract = true;
	public override void _Ready()
	{
		player = GetNode<CharacterBody3D>("Player");
		player.GetTree().GetFirstNodeInGroup("Player");

		label = GetNode<Label>("Prompt");
	}

	public void registerArea(InteractionArea area)
	{
		activeAreas.Add(area);
	}

	public void unregisterArea(InteractionArea area)
	{
		activeAreas.Remove(area);
	}
}
