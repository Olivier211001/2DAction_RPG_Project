using Godot;
using System;

public class Player : KinematicBody2D
{
	private int FRICTION = 100;
	const int ACCELERATION = 300;
	const int MAX_SPEED = 400;
	public Vector2 Velocity;
	public bool attacking = false;
	public bool right = true;

	public int life = 10;
	
	PackedScene ARROW;
	
	PackedScene currentScene; 

	AnimatedSprite currentSprite;

	Position2D position;

	Position2D position2;

	public int Level = 1;

	Vector2 knockback = Vector2.Zero;


	AudioStreamPlayer ArrowSound;

	AudioStreamPlayer HitSound;

	public bool isHurted = false;

	TextureProgress lifeBar;

	[Export]
	public int Speed = 200;

	public override void _Ready(){	
		currentSprite = GetNode<AnimatedSprite>("Sprite");
		ARROW = (PackedScene)ResourceLoader.Load("res://arrow.tscn");
		position = GetNode<Position2D>("Position2D");
		position2 = GetNode<Position2D>("Position2D2");
		ArrowSound = GetNode<AudioStreamPlayer>("ASound");
		HitSound  = GetNode<AudioStreamPlayer>("hitSound");
		lifeBar = GetNode<TextureProgress>("Camera2D/CanvasLayer/LifeBar/TextureProgress");
	}
	public Vector2 GetInput()
	{
	    var input_vector = Vector2.Zero;
	    input_vector.x = Input.GetActionStrength("ui_right") 
	                        - Input.GetActionStrength("ui_left");
	    input_vector.y = Input.GetActionStrength("ui_down") 
	                        - Input.GetActionStrength("ui_up");	    
	    input_vector = input_vector.Normalized();
	    return input_vector;
	}

	public void direction(bool drct)
	{
	  if(drct)
	  {
		  currentSprite.FlipH = false;
	  }
	  else
	  {
		  currentSprite.FlipH = true;
	  }
	} 

	public override void _PhysicsProcess(float delta)
	{	
		GD.Print(Level);
		knockback = knockback.MoveToward(Vector2.Zero, 200 * delta);
		knockback = MoveAndSlide(knockback);
	    var input_vector = GetInput();
	    if (input_vector != Vector2.Zero && attacking == false && isHurted == false) {
			if(input_vector.x > 0 || input_vector.y > 0)
			{
				right = true;
			}
			else
			{
			   right = false;
			}
			direction(right);
			currentSprite.Play("Run");
	        Velocity = Velocity.MoveToward(input_vector * MAX_SPEED, ACCELERATION);
	    }			
		 else
		{
			if(Input.IsActionJustReleased("Attack"))
			{				
				currentSprite.Play("Attack");					
				attacking = true;
			}
			if(currentSprite.Frame == 5)
			{
				attacking = false;
			}
			else if(attacking == false  && isHurted == false)
			{
				currentSprite.Play("Idle");
			}
			 Velocity = Velocity.MoveToward(Vector2.Zero, FRICTION);
	    }
	    Velocity = MoveAndSlide(Velocity);
	}
	
	private void _on_Sprite_animation_finished()
	{
	  if(currentSprite.Animation == "Attack")
	  {
		  ArrowSound.Play();
		  var arrow = ARROW.Instance();
		  GD.Print(((Area2D)arrow).Position);
		  GetParent().AddChild(arrow);
		  var pos = position.GlobalPosition;
		  var pos2 = position2.GlobalPosition;
		  if(right)
		  {
			((Area2D)(arrow)).Position = pos;
			((arrow)(arrow)).setArrowDirection(1);
		  }
		  else
		  {
			((Area2D)(arrow)).Position = pos2;
			((arrow)(arrow)).setArrowDirection(-1);
		  }
	  }
	  else if(currentSprite.Animation == "Hurt")
	  {
		  isHurted = false;
	  }
	}
	private void loseLife()
	{
		life--;
		((TextureProgress)(lifeBar)).Value = life;
		if(life == 0)
		{
			GetTree().ChangeScene("res://GameOver.tscn");
		}
		else
		{
			isHurted = true;
			currentSprite.Play("Hurt");
			knockback = Vector2.Left * 350;
		}	
	}
	private void _on_detectEnnemy_area_entered(Area2D area)
	{
		HitSound.Play();
		if(area.IsInGroup("a"))
		{
			loseLife();
		}
	}
}












