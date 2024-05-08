using Godot;
using System;

public partial class Interactable : StaticBody3D
{
    [Signal] public delegate void InteractedEventHandler(Variant arg);

    [Export] public string promptMessage;
    [Export] public string promptAction = "interact";

    public string GetPrompt()
    {
        return $"{promptMessage}\n[E]";
    }

    public void Interact(Variant body)
    {
        EmitSignal(nameof(Interacted), body);
    }
}