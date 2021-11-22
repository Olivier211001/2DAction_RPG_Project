using Godot;
using System;

public class door : KinematicBody2D
{
  
	AnimatedSprite doorAnim;

	int checkCible;

	public override void _Ready()
	{
		doorAnim = GetNode<AnimatedSprite>("AnimatedSprite");
	}


	public override void _PhysicsProcess(float delta)
	{
		if(cible.count == 6)
		{
			doorAnim.Play("dooropen");
		}
		else if(cible.count > 6)
		{
			doorAnim.Play("open");
		}
		else
		{
			doorAnim.Play("close");
		}
	}
	private void _on_AnimatedSprite_animation_finished()
	{
		if(doorAnim.Animation == "dooropen")
		{
			cible.count ++;
			doorAnim.Play("open");
		}
	}
}



