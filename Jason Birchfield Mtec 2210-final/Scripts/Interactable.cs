using Godot;
using System;

public partial class Interactable : StaticBody3D
{
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

        public void Interact(object body)
        {
            if (body is Node node)
            {
                GD.Print(node.Name + " interacted");
            }
            else
            {
                GD.Print("Interacted with a non-Node body or null.");
            }
        }
}