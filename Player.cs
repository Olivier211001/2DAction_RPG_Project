using Godot;
using System;

public class Player : KinematicBody2D
{
   //bye
	private int FRICTION = 100;
	const int ACCELERATION = 300;
	const int MAX_SPEED = 300;
	public Vector2 Velocity;
	public bool attacking = false;
	public bool right;
	
	AnimatedSprite currentSprite;

	[Export]
	public int Speed = 200;

	public override void _Ready(){	
		currentSprite = GetNode<AnimatedSprite>("Sprite");
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
	    var input_vector = GetInput();
	    if (input_vector != Vector2.Zero) {
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
			//aS.Travel("Run");
	        Velocity = Velocity.MoveToward(input_vector * MAX_SPEED, ACCELERATION);
	    }			
		 else
		{
			if(Input.IsActionJustReleased("Attack"))
			{
					//currentSprite.Stop();
					currentSprite.Play("Attack");
					attacking = true;
			}
			if(currentSprite.Frame == 5)
			{
				attacking = false;
			}
			else if(attacking == false)
			{
				currentSprite.Play("Idle");
			}
			 Velocity = Velocity.MoveToward(Vector2.Zero, FRICTION);
	    }
	    Velocity = MoveAndSlide(Velocity);
	}
}
