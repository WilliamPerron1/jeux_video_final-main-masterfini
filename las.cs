using Godot;
using System;

public class las : VBoxContainer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	private void _on_Recommencer_pressed()
	{
		GetTree().ChangeScene("res://world.tscn");
	}


	private void _on_menu_pressed()
	{
		GetTree().ChangeScene("res://Menu.tscn");
	}


	private void _on_quitter_pressed()
	{
		GetTree().Quit();
	}

}



