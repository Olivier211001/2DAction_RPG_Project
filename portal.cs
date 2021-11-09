using Godot;
using System;

public class portal : KinematicBody2D
{
	int level;
	KinematicBody2D player;
	public override void _Ready()
	{
		//player = GetNode<KinematicBody2D>("Player");
	}
	private void _on_Area2D_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://Level2.tscn");
		}		
	}
}






