using Godot;
using System;

public class Player : KinematicBody2D
{
	private int FRICTION = 100;
	private const int ACCELERATION = 300;
	private const int MAX_SPEED = 400;
	public Vector2 Velocity;
	public bool attacking = false;
	public bool right = true;

	public static int life = 10;
	
	private PackedScene ARROW;
	
	private PackedScene currentScene; 

	private AnimatedSprite currentSprite;

	private Position2D position;

	private Position2D position2;

	public static int Level = 1;

	private Vector2 knockback = Vector2.Zero;


	private AudioStreamPlayer ArrowSound;

	private AudioStreamPlayer HitSound;

	public bool isHurted = false;

	private TextureProgress lifeBar;
	private Label color;
	private bool p = false;

	private ColorRect menuPause;  

	public int nbcible;

	public static float speedX;
	public static float speedY;

	public static Vector2 pos;

	[Export]
	public int Speed = 200;
	Color yellow = new Color(247, 255, 0, 255);
	Color red= new Color(255, 0, 0, 255);
	Color blue = new Color(0, 28, 255, 255);

	Color white = new Color(255,255,255,255);

	public override void _Ready(){	
		currentSprite = GetNode<AnimatedSprite>("Sprite");
		ARROW = (PackedScene)ResourceLoader.Load("res://arrow.tscn");
		position = GetNode<Position2D>("Position2D");
		position2 = GetNode<Position2D>("Position2D2");
		ArrowSound = GetNode<AudioStreamPlayer>("ASound");
		HitSound  = GetNode<AudioStreamPlayer>("hitSound");
		color = GetNode<Label>("Camera2D/CanvasLayer/Interface/Label");
		menuPause = GetNode<ColorRect>("Camera2D/CanvasLayer/Interface/PauseOverlay");
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
		pos = this.GlobalPosition;
		if(life <= 7)
		{
			color.Modulate = yellow;
			color.Text = "Lost energy ...";
		}
		if(life > 7)
		{
			color.SelfModulate = white;
			color.Modulate = blue;
			color.Text = "I'm very healthy";
		}
		if(life <= 4)
		{
			color.Modulate = red;
			color.Text = "*Almost dead*";
		}
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
			speedX = input_vector.x;
			speedY = input_vector.y;
			//GD.Print(this.GlobalPosition);
	    }
		 else
		{
			if(Input.IsActionJustReleased("Attack") && isHurted == false)
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
	private void loseLife(int knock, int lostlife, string ennemy)
	{
		attacking = false;
		HitSound.Play();
		life -= lostlife;
		if(life == 0)
		{
			GetTree().ChangeScene("res://GameOver.tscn");
		}
		else
		{
			isHurted = true;
			currentSprite.Play("Hurt");
			if(ennemy == "death")
			{			
				if(death.direction.x > 0)
				{
					knockback = Vector2.Right * knock;
				}
				else
				{
					knockback = Vector2.Left * knock;
				}
			}
			else
			{
				knockback = Vector2.Left * knock;
			}		
		}	
	}
	private void _on_detectEnnemy_area_entered(Area2D area)
	{
		if(area.IsInGroup("a"))
		{
			loseLife(350, 1, "bees");
		}
		if(area.IsInGroup("death"))
		{
			loseLife(550, 2, "death");
		}
	}
	private void set_menuPause(Boolean value)
	{
		GetTree().Paused = value;
		menuPause.Visible = value;
	}
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey)
			if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Q)
			{
				if(Level == 1)
				{
					//Level = 2;
					GetTree().ChangeScene("res://Level2.tscn");
					Level ++;
				}
				else if(Level == 2) 
				{
					GetTree().ChangeScene("res://Level3.tscn");
					Level ++;
				}
				else if(Level == 3)
				{
					//Level = 3;
					GetTree().ChangeScene("res://EndingScene.tscn");
				}
			}
	}
}












