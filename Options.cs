using Godot;
using System;

public class Options : Node2D
{	
	
	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://menu.tscn");
	}
}



