using Godot;
using System;

public class Butterfly : KinematicBody2D
{
	
	const int ACCELERATION = 300;
	const int MAX_SPEED = 300;

	private Vector2 direction;

	public Vector2 Velocity;

	private Vector2 dd;


	//private AnimatedSprite butterfly;

	KinematicBody2D player;

	KinematicBody2D bf;
	public override void _Ready()
	{
		dd.x = 40;
		dd.y = 50;
		//butterfly = GetNode<AnimatedSprite>("AnimatedSprite");
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
