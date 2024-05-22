using Godot;
using System;

public partial class EndDemoScene : Control
{
    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Visible;
    }
    public void _On_Restart_Button_Pressed()
	{
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Houses/player_house_inside.tscn"));
	}

	public void _On_Quit_Button_Pressed()
	{
		GetTree().Quit();
	}
}
