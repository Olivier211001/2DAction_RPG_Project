using Godot;
using System;

public class EndingScene : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Player.life = 10;
		cible.count = 0;
		Player.Level = 1;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	private void _on_MainMenu_pressed()
	{
		GetTree().ChangeScene("res://menu.tscn");
	}
	private void _on_Restart_pressed()
	{
		GetTree().ChangeScene("res://Level1.tscn");
	}
	private void _on_Quit_Game_pressed()
	{
		GetTree().Quit();
	}
}









