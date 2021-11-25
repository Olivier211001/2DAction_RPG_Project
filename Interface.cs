using Godot;
using System;

public class Interface  : Control
{
	private Label vectorX;

	private Label vectorY;
   	private bool p = false;

	private ColorRect menuPause;   

	private Label position;

	private Label affiche1;
	private Label affiche2;

	private Label affiche3;
	private Label affiche4;

	private Label velo;

	private bool geekData = false;

	public override void _Ready()
	{
		menuPause = GetNode<ColorRect>("PauseOverlay");
		vectorX = GetNode<Label>("speed");
		vectorY = GetNode<Label>("vectorY");
		position = GetNode<Label>("position");
		velo = GetNode<Label>("Velocity");
		affiche1 = GetNode<Label>("label2");
		affiche2 = GetNode<Label>("Label3");
		affiche3 = GetNode<Label>("Label4");
		affiche4 = GetNode<Label>("Label5");
	}

	public override void _PhysicsProcess(float delta)
	{
		string sx = Player.speedX.ToString();
		string sy = Player.speedY.ToString();
		string p = Player.pos.ToString();
		string v = Player.VP.ToString();
		vectorX.Text = sx;
		vectorY.Text = sy; 
		position.Text = p;
		velo.Text = v;
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
			if (@event is InputEventKey geekKey)
				if (geekKey.Pressed && geekKey.Scancode == (int)KeyList.G)
				{
					if(geekData == false)
					{
						geekData = true;
						vectorX.Visible = true;
						vectorY.Visible = true;
						position.Visible = true;
						velo.Visible = true;
						affiche1.Visible = true;
						affiche2.Visible = true;
						affiche3.Visible = true;
						affiche4.Visible = true;
					}
					else
					{
						geekData = false;
						vectorX.Visible = false;
						vectorY.Visible = false;
						position.Visible = false;
						velo.Visible = false;
						affiche1.Visible = false;
						affiche2.Visible = false;
						affiche3.Visible = false;
						affiche4.Visible = false;
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









