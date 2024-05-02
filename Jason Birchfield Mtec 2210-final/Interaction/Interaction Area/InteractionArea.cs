using Godot;
using System;

public partial class InteractionArea : Area3D
{
	[Export] string actionName = "interact";


	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
