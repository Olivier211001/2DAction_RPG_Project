using Godot;
using System;

public class Level2 : YSort
{

	private Label explication;
	private CollisionShape2D a;
	private bool notAgain = false;
	public override void _Ready()
	{
		explication = GetNode<Label>("terre/Label");
		a = GetNode<CollisionShape2D>("terre/ExplicationCible/CollisionShape2D");
	}

	private void _on_ExplicationCible_area_entered(Area2D area)
	{
		if(area.IsInGroup("player") && !notAgain)
		{
			explication.Visible = true;
			notAgain = true;
		}
	}
}





