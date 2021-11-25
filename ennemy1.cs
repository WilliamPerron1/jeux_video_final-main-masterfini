using Godot;
using System;

public class ennemy1 : KinematicBody2D
{
	
	[Signal]
	public delegate void is_dead();
	
	[Signal]
	public delegate void player_dead();
	
	private int gravity =10;
	Vector2 UP = new Vector2(0, -1);
	Vector2 velocity = new Vector2(0, 0);
	private int speed = 20;
	private int direction =-1;
	bool dead = false;
	
	Sprite currentSprite;
	AnimationPlayer animPlayer;
	AnimationTree animTree;
	RayCast2D floor_checker1, floor_checker2;
	CollisionShape2D collision; 
	CanvasLayer label;
	
	int point = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentSprite = GetNode<Sprite>("Sprite");
		animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animTree = GetNode<AnimationTree>("AnimationTree");
		floor_checker1 = GetNode<RayCast2D>("floor_checker1");
		floor_checker2 = GetNode<RayCast2D>("floor_checker2");
		collision = GetNode<CollisionShape2D>("CollisionShape2D");
		 
		label = GetNode<CanvasLayer>("../HUD");
		animPlayer.Play("run");
		
		if(direction == 1){
			currentSprite.FlipH = true;
		}
		
	}
	
	public override void _PhysicsProcess(float delta){
		if(dead){
			
		}else{
			move_character();
		}
		
		
	}
	
	public void move_character(){
		
		if(IsOnWall()|| !floor_checker1.IsColliding()||!floor_checker2.IsColliding() && IsOnFloor()){
			direction = direction*-1;
			if(currentSprite.FlipH == true){
				currentSprite.FlipH = false;
			}else{
				currentSprite.FlipH = true;
			}
		}
		
		velocity.x = speed*direction;
		velocity.y += gravity;
		velocity = MoveAndSlide(velocity, UP);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private void _on_Area2D_area_entered(Area2D area)
	{
		//EmitSignal("point");
	// Replace with function body.
	
		if(area.IsInGroup("sword")){ 
			EmitSignal(nameof(is_dead));
			QueueFree();
		}
		
		if(area.IsInGroup("player")){ 
			EmitSignal(nameof(player_dead));
		}
	}
}





