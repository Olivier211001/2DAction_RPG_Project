using Godot;
using System;

public class menu : Node2D
{
	private PackedScene ARROW;
	private Position2D position;
	private Position2D position2;
	private Position2D position3;
	private AudioStreamPlayer music;
	private Button musciButton;
	private float  musicPosition = 0;
	public override void _Ready()
	{
		ARROW = (PackedScene)ResourceLoader.Load("res://arrow.tscn");
		position = GetNode<Position2D>("Position2D");
		position2 = GetNode<Position2D>("2");
		position3 = GetNode<Position2D>("3");
		music = GetNode<AudioStreamPlayer>("menusong");
		musciButton = GetNode<Button>("volume");
	}
	private void _on_Start_Game_pressed()
	{
		GetTree().ChangeScene("res://Level1.tscn");
	}
	private void _on_Start_Game_mouse_entered()
	{
		createArrow();
	}
	
	private void _on_Options_pressed()
	{
		GetTree().ChangeScene("res://Options.tscn");
	}
	private void _on_Options_mouse_entered()
	{
		createArrow();
	}
	private void _on_Exit_pressed()
	{
		GetTree().Quit();
	}
	private void _on_Exit_mouse_entered()
	{
		createArrow();
	}
	private void createArrow()
	{
		GD.Print("create arrow");
		var arrow = ARROW.Instance();
		var arrow2 = ARROW.Instance();
		var arrow3 = ARROW.Instance();
		GetParent().AddChild(arrow);
		GetParent().AddChild(arrow2);
		GetParent().AddChild(arrow3);
		var pos = position.GlobalPosition;
		var pos2 = position2.GlobalPosition;
		var pos3 = position3.GlobalPosition;
		
		((Area2D)(arrow)).Position = pos;
		((Area2D)(arrow2)).Position = pos2;
		((Area2D)(arrow3)).Position = pos3;
		((arrow)(arrow)).setArrowDirection(1);
		((arrow)(arrow2)).setArrowDirection(1);
		((arrow)(arrow3)).setArrowDirection(1);
	}
	
	private void _on_Button_pressed()
	{
		if(music.Playing == true)
		{
			musicPosition = music.GetPlaybackPosition();
			music.Stop();
			musciButton.Text = "Volume Off";
		}
		else
		{
			music.Play(musicPosition);
			musciButton.Text = "Volume On";
		}
	}
}
























