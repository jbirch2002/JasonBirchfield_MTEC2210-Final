using Godot;
using System.Collections.Generic;
using System;

public partial class GameManager : Node
{
    public static GameManager Instance { get; private set; }

    public override void _Ready()
    {
        if (Instance != null)
        {
            GD.Print("An instance of GameManager already exists, removing duplicate.");
            QueueFree();
            return;
        }
        
        Instance = this;
    }
}
