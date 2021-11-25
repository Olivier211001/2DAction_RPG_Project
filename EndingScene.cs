using Godot;
using System;

public class EndingScene : Node2D
{
	
	public override void _Ready()
	{
		Player.life = 10;
		cible.count = 0;
		Player.Level = 1;
	}

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









