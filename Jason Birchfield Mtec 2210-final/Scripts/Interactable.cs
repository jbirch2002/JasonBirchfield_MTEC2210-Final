using Godot;
using System;

public partial class Interactable : StaticBody3D
{
    public delegate void InteractedWithArguementEventHandler(Variant body);
	[Export] public string promptMessage;
	[Export] public string promptAction = "interact";

    public string GetPrompt()
    {
        string keyName = "";
        foreach (InputEvent action in InputMap.ActionGetEvents(promptAction))
        {
			if (action is InputEventKey inputEvent)
            {
				keyName = "E";
				break;
            }
        }

        return $"{promptMessage} \n [{keyName}]";
    }

        public void Interact(Variant body)
        {
            EmitSignal("Interacted", body);
        }
}