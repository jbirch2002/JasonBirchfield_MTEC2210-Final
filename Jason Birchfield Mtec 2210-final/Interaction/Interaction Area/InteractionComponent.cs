using Godot;
using System;

public partial class InteractionComponent : Node
{
    [Export] NodePath interactionRaycastPath;
    [Export] NodePath interactionLabelPath;
    [Export] NodePath interactionAudioPath;
    RayCast3D interactionRaycast;
    Label interactionLabel;
    AudioStreamPlayer3D interactionAudio;
    bool isReset = true;

    public override void _Ready()
    {
        interactionRaycast = GetNode<RayCast3D>(interactionRaycastPath);
        interactionLabel = GetNode<Label>(interactionLabelPath);
        interactionAudio = GetNode<AudioStreamPlayer3D>(interactionAudioPath);
    }

    public override void _Process(double delta)
    {
        if (interactionRaycast.IsColliding())
        {
            var interactable = interactionRaycast.GetCollider() as Node;
            isReset = false;
            if(interactable.IsInGroup("Doors") || interactable.IsInGroup("EntranceDoorPlayerHouse") || interactable.IsInGroup("EntranceDoorHouse2"))
            {
                if (interactable != null && interactable.HasMethod("Interact"))
                {
                    interactionLabel.Text = "Enter\n[E]";
                }
            }
            
            if(interactable.IsInGroup("ExitDoorPlayerHouse") || interactable.IsInGroup("ExitDoorHouse2"))
            {
                if (interactable != null && interactable.HasMethod("Interact"))
                {
                    interactionLabel.Text = "Leave\n[E]";
                }
            }
            if(interactable.IsInGroup("ShaftEntrance"))
            {
                if (interactable != null && interactable.HasMethod("Interact"))
                {
                    interactionLabel.Text = "";
                }
            }
            if(interactable.IsInGroup("Bones"))
            {
                if (interactable != null && interactable.HasMethod("Interact"))
                {
                    interactionLabel.Text = "[E]";
                }
            }
            if(interactable.IsInGroup("Bell"))
            {
                if (interactable != null && interactable.HasMethod("Interact"))
                {
                    interactionLabel.Text = "Ring?\n[E]";
                }
            }
        }
        else
        {
            if (!isReset)
            {
                interactionLabel.Text = "";
                isReset = true;
            }
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("interact"))
        {
            if (interactionRaycast.IsColliding())
            {
                var interactable = interactionRaycast.GetCollider() as Node;
                if (interactable != null && interactable.HasMethod("Interact"))
                {
                    interactable.Call("Interact");
                }
            }
        }
    }
}