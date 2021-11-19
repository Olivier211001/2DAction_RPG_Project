using Godot;
using System;

public class OptionsPause : Node2D
{	
	
	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://Level1.tscn");
	}
}
