using Godot;
using System;

public class nextLvl : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	int point;
	
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	private void _on_nextLvl_body_entered(Area2D body)
	{
		
		if(body.IsInGroup("player") && point ==3){
			GetTree().ChangeScene("res://lvl2.tscn");
				
		}
		
		
	}
	
	private void _on_ennemy1_is_dead()
	{
	// Replace with function body.
		point++;
	}


	private void _on_ennemy2_is_dead()
	{
	// Replace with function body.
		point++;
	}


	private void _on_ennemy3_is_dead()
	{
	// Replace with function body.
		point++;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}






