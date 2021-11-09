using Godot;
using System;

public class Bee : KinematicBody2D
{
	private int touch = 0;
	AnimatedSprite beeAnim;

	Vector2 knockback = Vector2.Zero;

	bool KB = false;
	bool attack = false;
	public override void _Ready()
	{
		beeAnim = GetNode<AnimatedSprite>("AnimatedSprite");
	}
	public override void _PhysicsProcess(float delta)
	{
		knockback = knockback.MoveToward(Vector2.Zero, 200 * delta);
		knockback = MoveAndSlide(knockback);
		if(attack == false)
		{
			beeAnim.Play("idle");	
		}
	}
	private void _on_Killbee_area_entered(Area2D area)
	{
		if(area.IsInGroup("arrow"))
		{
			attack = true;
			beeAnim.Play("attack");
			knockback = Vector2.Right * 350;
			KB = true;
			area.QueueFree();
			touch ++;
			if(touch == 3)
			{
				QueueFree();
			}
		}
	}
	private void _on_AttackZone_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			attack = true;
			beeAnim.Play("attack");
		}
	}
	private void _on_AnimatedSprite_animation_finished()
	{
		 if(beeAnim.Animation == "attack")
		 {
			 attack = false;
			 if(KB == true)
			 {
				knockback = Vector2.Left * 450;
				KB = false;
			 }
		 }
	}
	private void _on_AttackZone_area_exited(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			attack = true;
			beeAnim.Play("attack");
		}
	}
}










