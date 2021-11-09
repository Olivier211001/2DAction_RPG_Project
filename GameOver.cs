using Godot;
using System;

public class GameOver : Node2D
{
	KinematicBody2D player;

	public override void _Ready()
	{
		player = GetNode<KinematicBody2D>("Player");
	}
	private void _on_Button_pressed()
	{			
		GetTree().ChangeScene("res://Level2.tscn");	
	}
}



