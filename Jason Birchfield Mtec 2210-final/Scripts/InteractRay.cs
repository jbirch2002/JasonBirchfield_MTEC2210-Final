using Godot;
using System;
using System.IO.IsolatedStorage;

public partial class InteractRay : RayCast3D
{
	Label prompt;
	CharacterBody3D player;
	AudioStreamPlayer3D audioStreamPlayer3D;
	private AudioStream openAudio;
    private AudioStream closeAudio;
	OpenDoors openDoors;
	private float timeHeld = 0.0f;
	private const float threshold = 1.0f;
	bool isOpen = false;
	public override void _Ready()
	{
		audioStreamPlayer3D = GetNode<AudioStreamPlayer3D>("audioStreamPlayer3d");
		prompt = GetNode<Label>("Prompt");
		player = GetNode<CharacterBody3D>("../..");
		AddException(player);

	}

    public override void _PhysicsProcess(double delta)
    {
        prompt.Text = "";

        if (IsColliding())
        {
			GD.Print("Colliding with something.");
            if (GetCollider() is Interactable detected)
            {
                prompt.Text = detected.GetPrompt();
				if (Input.IsActionJustPressed(detected.promptAction))
				{
					if (detected.IsInGroup("PlayerHouseEntranceDoor"))
					{
						var newScene = (PackedScene)ResourceLoader.Load("res://Scenes/Houses/player_house_inside.tscn"); 
						if (newScene != null)
						{
							GetTree().ChangeSceneToPacked(newScene);
						}
					}

					if (detected.IsInGroup("House2EntranceDoor"))
					{
						var newScene = (PackedScene)ResourceLoader.Load("res://Scenes/Houses/house2_inside.tscn"); 
						if (newScene != null)
						{
							GetTree().ChangeSceneToPacked(newScene);
						}
					}

					if (detected.IsInGroup("ExitDoor"))
					{
						var newScene = (PackedScene)ResourceLoader.Load("res://WorldDay1.tscn"); 
						if (newScene != null)
						{
							GD.Print("Exiting");
							GetTree().ChangeSceneToPacked(newScene);
						}
					}

					if (detected.IsInGroup("Doors"))
					{
						// openDoors.OpenDoor();  // Call ToggleDoor on interaction button press
					}
					else if (detected.IsInGroup("NPCs"))
					{
						detected.Interact(Owner);
					}
					else if (detected.IsInGroup("Animals"))
					{
						detected.Interact(Owner);
					}
					else if (detected.IsInGroup("Bones"))
					{
						var newAudio = ResourceLoader.Load<AudioStream>("res://Sounds/Bones sound.mp3");
						if (newAudio != null)
						{
							audioStreamPlayer3D.Stream = newAudio;
							audioStreamPlayer3D.Play();
							detected.Interact(Owner);
						}
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
