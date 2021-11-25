using Godot;
using System;

public class death : KinematicBody2D
{
	private const int ACCELERATION = 300;
	private const int MAX_SPEED = 180;

	public static Vector2 direction;

	public Vector2 Velocity;

	private bool isattacking = false;	
	private KinematicBody2D player;

	private AnimatedSprite mort;

	private Sprite heart1;

	private Sprite heart2;

	private Sprite heart3;
	private bool isHurting = false;

	private int life = 9;
	private bool isDying = false;

	private CollisionShape2D zone1;
	private CollisionShape2D body;
	private CollisionShape2D zone2;
	private CollisionShape2D riskZone;
	
	public override void _Ready()
	{
		mort = GetNode<AnimatedSprite>("AnimatedSprite");
		heart1 = GetNode<Sprite>("AnimatedSprite/Heart");
		heart2 = GetNode<Sprite>("AnimatedSprite/Heart2");
		heart3 = GetNode<Sprite>("AnimatedSprite/Heart3");
		zone1 = GetNode<CollisionShape2D>("attackZone/CollisionShape2D");
		zone2 = GetNode<CollisionShape2D>("attackZone/CollisionShape2D2");
		riskZone = GetNode<CollisionShape2D>("riskZone/CollisionShape2D");
		body = GetNode<CollisionShape2D>("CollisionShape2D");
	}

	public override void _PhysicsProcess(float delta)
	{
	 	player = (GetNode("zoneB") as zoneB).player;
		if(!isattacking && !isHurting && !isDying)
		{
			mort.Play("idle");
		}		
		if(player != null)
		{
			 //butterfly.Play("fly");
			direction = (Player.pos - this.GlobalPosition).Normalized();
			if(direction.x >0)
			{
				mort.FlipH = false;
			}
			else
			{
				mort.FlipH = true;
			}
			Velocity = Velocity.MoveToward(direction * MAX_SPEED, ACCELERATION);
			//GD.Print($"player: {player.Position} \t death: {this.GlobalPosition}");
		}
		if(life != 0)
		{
			 Velocity = MoveAndSlide(Velocity);
		}
	}
	
	private void _on_attackZone_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			if(isHurting == false)
			{
				isattacking = true;
				mort.Play("attack");
			}
		}
	}
	private void _on_attackZone_area_exited(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			isattacking = false;
		}
	}
	
	private void _on_riskZone_area_entered(Area2D area)
	{
		if(area.IsInGroup("arrow"))
		{
			area.QueueFree();
			isattacking = false;
			isHurting = true;
			mort.Play("hurt");
			loseLife();
		}
	}
	private void _on_AnimatedSprite_animation_finished()
	{
		if(mort.Animation == "hurt")
		{
			isHurting = false;
		}
		if(mort.Animation == "die")
		{
			GetTree().ChangeScene("res://EndingScene.tscn");
		}
	}
	private void loseLife()
	{
		life--;
		if(life == 6)
		{
			heart1.QueueFree();
		}
		if(life == 3)
		{
			heart2.QueueFree();
		}
		if(life == 0)
		{
			heart3.QueueFree();
			deathDie();
		}
	}
	private void deathDie()
	{
		isDying = true;
		body.QueueFree();
		zone1.QueueFree();
		zone2.QueueFree();
		riskZone.QueueFree();
		mort.Play("die");
	}
}














