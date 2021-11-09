using Godot;
using System;

public class arrow : Area2D
{
	
	const int SPEED = 1000;
	public Vector2 Velocity;

	public string patate = "patate";
	public int direction = 1;

	public void setArrowDirection(int dir)
	{
		direction = dir;
		if(dir == -1)
		{
			GetNode<AnimatedSprite>("AnimatedSprite").FlipV = true;
		}
		else
		{
			GetNode<AnimatedSprite>("AnimatedSprite").FlipV = false;
			GetNode<AnimatedSprite>("AnimatedSprite").FlipH = false;
		}
	}
	
	public override void _PhysicsProcess(float delta)
	{
		//GD.Print(this.Position);
		Velocity.x = SPEED * delta * direction;
		Translate(Velocity);
	}
	private void _on_VisibilityNotifier2D_screen_exited()
	{
		QueueFree();
	}
}



