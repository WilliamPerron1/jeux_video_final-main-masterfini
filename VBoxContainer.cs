using Godot;
using System;

public class VBoxContainer : Godot.VBoxContainer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	
	public override void _PhysicsProcess(float delta){
		if(Input.IsActionJustPressed("skip")){
			
			GetTree().ChangeScene("res://menu.tscn");
		} 
	}
	
	public override void _Ready()
	{
		
	}
	private void _on_Menu_pressed()
	{
		GetTree().ChangeScene("res://Menu.tscn");
	}


	private void _on_Quitter_pressed()
	{
		GetTree().Quit();
	}
	
	


}






