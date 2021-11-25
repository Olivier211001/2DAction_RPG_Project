using Godot;
using System;

public class Butterfly : KinematicBody2D
{
	
	private const int ACCELERATION = 300;
	private const int MAX_SPEED = 300;

	private Vector2 direction;

	public Vector2 Velocity;

	private Vector2 dd;



	private KinematicBody2D player;

	private KinematicBody2D bf;
	public override void _Ready()
	{
		dd.x = 40;
		dd.y = 50;
	}

	public override void _PhysicsProcess(float delta)
	{
	 	player = (GetNode("zoneB") as zoneB).player;
		if(player != null)
		{
			 //butterfly.Play("fly");
			 direction = ((Player.pos) - this.GlobalPosition).Normalized();
			 Velocity = Velocity.MoveToward(direction * MAX_SPEED, ACCELERATION);
		}
		 Velocity = MoveAndSlide(Velocity);
	}

}
