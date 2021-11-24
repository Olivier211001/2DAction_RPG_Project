using Godot;
using System;

public class TextureProgress : Godot.TextureProgress
{   
	Player player;
	int val = 10;
	public override void _Ready()
	{
	
	}
	public override void _PhysicsProcess(float delta)
	{
		Value = Player.life;
	}

}
