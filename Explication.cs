using Godot;
using System;

public class Explication : Control
{
	private bool already = false;

	private ColorRect exp; 
	public override void _Ready()
	{
		exp = GetNode<ColorRect>("screen");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private void _on_ExplicationCible_area_entered(Area2D area)
	{
		if(area.IsInGroup("player") && already == false)
		{
			exp.Visible = true;
			GetTree().Paused = true;
		}
	}
	
	private void _on_Button_pressed()
	{
		GetTree().Paused = false;
		exp.Visible = false;
	}
}





