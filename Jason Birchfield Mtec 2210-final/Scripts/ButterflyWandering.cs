using Godot;
using System;

public partial class ButterflyWandering : CharacterBody3D
{
    [Export] public float speed = 2;
    [Export] public float accel = 10;
    [Export] NodePath navigationAgent3DPath;
	[Export] NodePath targetPath;

    private NavigationAgent3D nav;

    public override void _Ready()
    {
        nav = GetNode<NavigationAgent3D>(navigationAgent3DPath);
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector3 direction;

        nav.TargetPosition = GetNode<CharacterBody3D>("Global/target").GlobalTransform.Origin;

        direction = nav.GetNextPathPosition() - GlobalTransform.Origin;
        direction = direction.Normalized();

        Velocity = Velocity.Lerp(direction * speed, accel * (float)delta);

        MoveAndSlide();
    }
}
