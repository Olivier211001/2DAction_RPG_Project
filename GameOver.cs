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
		Player.life = 10;
		if(Player.Level == 1)
		{
			GetTree().ChangeScene("res://Level1.tscn");	
		}
		else if(Player.Level == 2)
		{
			GetTree().ChangeScene("res://Level2.tscn");	
		}
		else
		{
			GetTree().ChangeScene("res://Level3.tscn");	
		}		
	}
}



