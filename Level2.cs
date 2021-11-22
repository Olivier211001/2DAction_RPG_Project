using Godot;
using System;

public class Level2 : YSort
{

	Label explication;
	CollisionShape2D a;
	bool notAgain = false;
	public override void _Ready()
	{
		explication = GetNode<Label>("terre/Label");
		a = GetNode<CollisionShape2D>("terre/ExplicationCible/CollisionShape2D");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	
	private void _on_ExplicationCible_area_entered(Area2D area)
	{
		if(area.IsInGroup("player") && !notAgain)
		{
			explication.Visible = true;
			notAgain = true;
		}
	}
}





