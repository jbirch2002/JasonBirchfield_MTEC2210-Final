using Godot;
using System;

public partial class DayNightCycle : Node3D
{
	float time;
	[Export] float dayLength = 10.0f;
	[Export] float startTime = 0.3f;
	double timeRate;
	DirectionalLight3D sun;
	[Export] Gradient sunColor;
	[Export] Curve sunIntensity;

	DirectionalLight3D moon;
	[Export] Gradient moonColor;
	[Export] Curve moonIntensity;

	WorldEnvironment skybox;
	[Export] Gradient skyTopColor;
	[Export] Gradient skyHorizonColor;

public override void _Ready()
{
    timeRate = 1.0f / dayLength;
    time = startTime;
    sun = GetNode<DirectionalLight3D>("sun");
	moon = GetNode<DirectionalLight3D>("moon");
	skybox = GetNode<WorldEnvironment>("Skybox");
}
	public override void _Process(double delta)
	{
		time = (time + (float)(timeRate * delta)) % 1.0f;

		if (time >= 1.0) time = 0f;

		Vector3 sunRotation = sun.RotationDegrees;
		sunRotation.X = time * 360f + 90f;
		sun.RotationDegrees = sunRotation;
		sun.LightColor = sunColor.Sample(time);
		sun.LightEnergy = sunIntensity.Sample(time);
		sun.Visible = sun.LightEnergy > 0;

		Vector3 moonRotation = moon.RotationDegrees;
		moonRotation.X = time * 360f + 270f;
		moon.RotationDegrees = moonRotation;
		moon.LightColor = moonColor.Sample(time);
		moon.LightEnergy = moonIntensity.Sample(time);
		moon.Visible = moon.LightEnergy > 0;

		skybox.Environment.Sky.SkyMaterial.Set("skyTopColor", skyTopColor.Sample(time));
		skybox.Environment.Sky.SkyMaterial.Set("skyHorizonColor", skyHorizonColor.Sample(time));
		skybox.Environment.Sky.SkyMaterial.Set("groundTopColor", skyTopColor.Sample(time));
		skybox.Environment.Sky.SkyMaterial.Set("groundHorizonColor", skyHorizonColor.Sample(time));
	}
}
