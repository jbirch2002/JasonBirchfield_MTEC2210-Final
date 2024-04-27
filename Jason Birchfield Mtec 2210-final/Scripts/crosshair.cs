using Godot;
using System;

public partial class Crosshair : CenterContainer
{
	[Export] float dotRadius = 1.0f;
	[Export] Color dotColor = new Color(1, 0, 0);

	public override void _Ready()
	{
		QueueRedraw();
	}

    public override void _Draw()
    {
		DrawCircle(new Vector2(0,0), dotRadius, dotColor);
   	}
}
