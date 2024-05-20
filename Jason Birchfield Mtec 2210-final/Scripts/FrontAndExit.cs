using Godot;
using System;

public partial class FrontAndExit : Node3D
{
        [Signal] public delegate void DoorToggledEventHandler(string doorGroup);
        public override void _Ready()
        {

        }

        public void ToggleDoor()
        {
            if (IsInGroup("EntranceDoorPlayerHouse"))
            {
                EmitSignal("DoorToggled", "EntranceDoorPlayerHouse");
                GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Houses/player_house_inside.tscn"));
            }
            if (IsInGroup("ExitDoorPlayerHouse"))
            {
                EmitSignal("DoorToggled", "ExitDoorPlayerHouse");
                GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/World/WorldDay1.tscn"));
            }
            if (IsInGroup("EntranceDoorHouse2"))
            {
                EmitSignal("DoorToggled", "EntranceDoorHouse2");
                GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Houses/house2_inside.tscn"));
            }
            if (IsInGroup("ExitDoorHouse2"))
            {
                EmitSignal("DoorToggled", "ExitDoorHouse2");
                GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://WorldDay1.tscn"));
            }
            if (IsInGroup("ShaftEntrance"))
            {
                EmitSignal("DoorToggled", "ShaftEntrance");
                GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/World/bell_cave.tscn"));
            }
                
        }

    public void Interact()
    {
        ToggleDoor();
    }
}
