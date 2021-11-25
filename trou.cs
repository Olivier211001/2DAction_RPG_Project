using Godot;
using System;

public class trou : Node2D
{
	private void _on_trouArea_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://EndingScene.tscn");
		}	
	}
}



