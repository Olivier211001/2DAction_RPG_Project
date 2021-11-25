using Godot;
using System;

public class zoneB : Area2D
{
	
	public KinematicBody2D player;
	public override void _Ready()
	{
		player = null;
	}

	private void _on_zoneB_body_entered(KinematicBody2D body)
	{
		//GD.Print("allo");
		player = body;
	}

	
	private void _on_zoneB_body_exited(object body)
	{
		player = null;
	}

}






