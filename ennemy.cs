using Godot;
using System;

public class ennemy : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	const int gravity =10;
	Vector2 velocity = new Vector2(0,0);
	Vector2 UP = new Vector2(0, -1);
	const int speed = 32;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//currentSprite = GetNode<Sprite>("Sprite");
		//animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		//animPlayer.play("run");
		
	}
	
	public override void _PhysicsProcess(float delta){
		move_character();
	}
	
	public void move_character(){
		velocity.x = -speed;
		velocity.y += gravity;
		
		velocity = MoveAndSlide(velocity, UP);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
