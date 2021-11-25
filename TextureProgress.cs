using Godot;
using System;

public class TextureProgress : Godot.TextureProgress
{   
	public override void _PhysicsProcess(float delta)
	{
		Value = Player.life;
	}

}
