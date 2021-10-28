using Godot;
using System;

public class arrow : Area2D
{
	
	const int SPEED = 400;
	public Vector2 Velocity;

	private int direction = 1;

	public override void _Ready()
	{
		
	}

	private void setArrowDirection(int dir)
	{
		
	}
	
	public override void _PhysicsProcess(float delta)
	{
		//GD.Print(this.Position);
		Velocity.x = SPEED * delta;
		Translate(Velocity);
	}
	private void _on_VisibilityNotifier2D_screen_exited()
	{
		QueueFree();
	}
}



