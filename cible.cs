using Godot;
using System;

public class cible : StaticBody2D
{
 
	public static int count;
 	private PackedScene player;
	public override void _Ready()
	{
		player = (PackedScene)ResourceLoader.Load("res://Player.tscn");
	}


	public override void _PhysicsProcess(float delta)
	{
		
	}
	
	private void _on_cibleZone_area_entered(Area2D area)
	{
		if(area.IsInGroup("arrow"))
		{
			count ++;
			QueueFree();
		}
	}
}


