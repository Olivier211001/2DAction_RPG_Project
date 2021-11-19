using Godot;
using System;

public class Interface  : Control
{
   
   	bool p = false;

	ColorRect menuPause;   
	public override void _Ready()
	{
		menuPause = GetNode<ColorRect>("PauseOverlay");
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey)
			if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.P)
			{
				if(GetTree().Paused == false)
				{
					GetTree().Paused = true;
					menuPause.Visible = true;
				}
				else
				{
					GetTree().Paused = false;
					menuPause.Visible = false;
				}
			}

	}
	private void _on_MainMenu_pressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeScene("res://menu.tscn");
	}
	private void _on_Quit_pressed()
	{
		GetTree().Quit();
	}
}









