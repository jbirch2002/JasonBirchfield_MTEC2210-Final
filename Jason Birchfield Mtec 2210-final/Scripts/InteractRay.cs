using Godot;
using System;

public partial class InteractRay : RayCast3D
{
	Label prompt;
	CharacterBody3D player;
	private float timeHeld = 0.0f;
	private const float threshold = 1.0f;
	public override void _Ready()
	{
		prompt = GetNode<Label>("Prompt");
		player = GetNode<CharacterBody3D>("/root/Node3D/CharacterBody3D");
		AddException(player);
	}

    public override void _PhysicsProcess(double delta)
    {
        prompt.Text = "";

        if (IsColliding())
        {
            if (GetCollider() is Interactable detected)
            {
                prompt.Text = detected.GetPrompt();
				if (Input.IsActionPressed(detected.promptAction))
				{
					if (detected.IsInGroup("EntranceDoor"))
					{
						var newScene = (PackedScene)ResourceLoader.Load("res://Scenes/Houses/player_house_inside.tscn"); 
						if (newScene != null)
						{
							GetTree().ChangeSceneToPacked(newScene);
						}
					}
					else if (detected.IsInGroup("Doors"))
					{
						detected.Interact(Owner);
					}
					else if (detected.IsInGroup("NPCs"))
					{
						detected.Interact(Owner);
					}
					else if (detected.IsInGroup("Animals"))
					{
						detected.Interact(Owner);
					}
					else if (detected.IsInGroup("Animals"))
					{
						detected.Interact(Owner);
					}
					else if (detected.IsInGroup("Animals"))
					{
						detected.Interact(Owner);
					}
				}
            }
        }
    }
}
