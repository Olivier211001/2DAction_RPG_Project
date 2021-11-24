using Godot;
using System;

public class WinLife : StaticBody2D
{

	private void _on_giveLife_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			Player.life += 2;
			if(Player.life > 10)
			{
				Player.life = 10;
			}
			QueueFree();
		}
	}

}



