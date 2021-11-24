using Godot;
using System;

public class death : KinematicBody2D
{
	const int ACCELERATION = 300;
	const int MAX_SPEED = 160;

	private Vector2 direction;

	public Vector2 Velocity;
	
	KinematicBody2D player;

	private AnimatedSprite mort;
	
	public override void _Ready()
	{
		mort = GetNode<AnimatedSprite>("AnimatedSprite");
	}

	public override void _PhysicsProcess(float delta)
	{
	 	player = (GetNode("zoneB") as zoneB).player;
		mort.Play("idle");
		if(player != null)
		{
			 //butterfly.Play("fly");
			direction = (player.GlobalPosition - this.GlobalPosition).Normalized();
			if(direction.x >0)
			{
				mort.FlipH = false;
			}
			else
			{
				mort.FlipH = true;
			}
			Velocity = Velocity.MoveToward(direction * MAX_SPEED, ACCELERATION);
		}
		 Velocity = MoveAndSlide(Velocity);
	}
}
