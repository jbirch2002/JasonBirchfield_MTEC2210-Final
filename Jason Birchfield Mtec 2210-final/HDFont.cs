using Godot;
using System;

public partial class HDFont : Node
{
	SubViewportContainer viewBox;
	SubViewport viewport;
	Vector2 screenRes;
	Vector2 scaling = new Vector2();

	public override void _Ready()
	{
		viewBox = GetNode<SubViewportContainer>("subViewportContainer");
		viewport = GetNode<SubViewport>("subViewport");
		screenRes = GetViewport().GetVisibleRect().Size;

		scaling = screenRes / viewport.Size;
		viewBox.Size = scaling;
	}
}
