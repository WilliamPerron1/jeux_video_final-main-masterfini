using Godot;
using System;

public class Menu : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Button>("VBoxContainer/StartButton").GrabFocus(); 

	}
	
	public override void _PhysicsProcess(float delta){
		if(Input.IsActionJustPressed("skip")){
			
			GetTree().ChangeScene("res://world.tscn");
		} 
	}
	
	private void _on_StartButton_pressed()
	{
		GetTree().ChangeScene("res://world.tscn");
	}
	private void _on_QuitButton_pressed()
	{
		GetTree().Quit();
	}
	
	private void _on_SettingButton_pressed()
	{
		GetTree().ChangeScene("res://setting.tscn");
	}
	
	 
	
	


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}












