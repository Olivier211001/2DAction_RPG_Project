using Godot;
using System;

public class Interface  : Control
{
	private Label vectorX;

	private Label vectorY;
   	private bool p = false;

	private ColorRect menuPause;   
	public override void _Ready()
	{
		menuPause = GetNode<ColorRect>("PauseOverlay");
		vectorX = GetNode<Label>("speed");
		vectorY = GetNode<Label>("vectorY");
	}

	public override void _PhysicsProcess(float delta)
	{
		string sx = Player.speedX.ToString();
		string sy = Player.speedY.ToString();
		vectorX.Text = sx;
		vectorY.Text = sy; 
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









