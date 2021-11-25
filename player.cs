using Godot;
using System;

public class player : KinematicBody2D
{
	Vector2 UP = new Vector2(0, -1);
	const int GRAVITY = 25;
	const int MAXFALLSPEED = 400;
	const int MAXSPEED = 150;
	const int JUMPFORCE = 500;

	const int ACCEL = 10;

	bool facing_right = true;

	Vector2 motion = new Vector2();


	Label label;
	Sprite currentSprite;
	AnimationPlayer animPlayer;
	AnimationTree aT;
	CollisionShape2D gauche;
	CollisionShape2D droite;
	AudioStreamPlayer song;
	Label vector;
	Label state;
	
	int point=0;
		// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentSprite = GetNode<Sprite>("Sprite");
		animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		aT = GetNode<AnimationTree>("AnimationTree");
		gauche = GetNode<CollisionShape2D>("Sprite/sword_hit/gauche");
		droite = GetNode<CollisionShape2D>("Sprite/sword_hit/droite");
		song = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		vector = GetNode<Label>("../HUD/vector");
		state = GetNode<Label>("../HUD/state");
		vector.Visible = false;
		state.Visible = false;
	}
	
	public Vector2 GetInput()
	{
	    var input_vector = Vector2.Zero;
	    input_vector.x = Input.GetActionStrength("ui_right") 
	                        - Input.GetActionStrength("ui_left");
	    input_vector = input_vector.Normalized();
	    return input_vector;
	}
	
	public void direction(bool d)
	{
		if(d == true)
		{
			currentSprite.FlipH = false;
		 }
		 else
		 {
			currentSprite.FlipH = true;
		 }
	}
	
	public override void _PhysicsProcess(float delta)
	{
		vector.Text= "vector motion:"+motion.ToString();
		
		if(Input.IsActionJustPressed("debug")){
			if(vector.Visible == false){
				vector.Visible = true;
			}else{
				vector.Visible = false;
			}
			
			if(state.Visible == false){
				state.Visible = true;
			
			}else{
				state.Visible = false;
			}
			
		} 
		
		
		
		
		var aS = (AnimationNodeStateMachinePlayback)aT.Get("parameters/playback");
		var input_vector = GetInput();
		motion.y += GRAVITY;

		if(motion.y > MAXFALLSPEED) {
			motion.y = MAXFALLSPEED;
		}
	
		 //motion.x = motion.Clamped(MAXSPEED).x;

		if (input_vector != Vector2.Zero) 
		{
			aT.Set("parameters/idle/blend_position", input_vector);
			aT.Set("parameters/run/blend_position", input_vector);
			aS.Travel("run");
			if(input_vector.x > 0)
			{
				motion.x += ACCEL;
				facing_right = true;
				direction(facing_right);
				if(motion.x > MAXSPEED){
				motion.x = MAXSPEED;
				}
				state.Text = "run right";
			}
			else
			{
				motion.x -= ACCEL;
				facing_right = false;
				direction(facing_right);
				
				if(motion.x < -MAXSPEED){
				motion.x = -MAXSPEED;
				}
				state.Text = "run left";
			}
	    } 
		else 
		{    
			
			aT.Set("parameters/attack/blend_position", motion);
			if (Input.IsActionJustReleased("attack")) {
				aS.Travel("attack");
				song.Play();
				if(facing_right == true){
					droite.Set("disabled", false);
				}else{
					gauche.Set("disabled", false);
				}
				state.Text = "attack";
			}
			else
			{
				aS.Travel("idle"); 
				droite.Set("disabled", true);
				gauche.Set("disabled", true);
				state.Text = "idle";
			}            
	        //motion = motion.LinearInterpolate(Vector2.Zero, 0.2f);
			motion.x =0;
			   
			
	    }
				
		if (IsOnFloor())
		{
			// On ne regarde qu'un seul fois et non le maintient de la touche    
			
			if (Input.IsActionJustPressed("ui_jump")) {
				motion.y = -JUMPFORCE;
				GD.Print($"motion.y = {motion.y}");
				Console.WriteLine($"motion.y = {motion.y}");
				
			}    
		}
		
		if (!IsOnFloor()) {
			aT.Set("parameters/jump/blend_position", motion);
			aT.Set("parameters/fall/blend_position", motion);
			if (motion.y < 0) {
				aS.Travel("jump");
				state.Text = "jump";
			}
			else if (motion.y > 0) {
			   aS.Travel("fall");
			   state.Text = "fall";
			}
			
		}        
		motion = MoveAndSlide(motion, UP);
	}
	
	private void _on_killzone_area_entered(Area2D area)
	{
		if(area.IsInGroup("vide")){
			GetTree().ChangeScene("res://mort.tscn");
		}
	}
	
	private void _on_Area2D_area_entered(Area2D area)
	{
		if(area.IsInGroup("vide")){
			GetTree().ChangeScene("res://mort.tscn");
		}
	}
	
	private void _on_ennemy1_player_dead()
	{
		GetTree().ChangeScene("res://mort.tscn");
	}
	
	private void _on_ennemy2_player_dead()
	{
		GetTree().ChangeScene("res://mort.tscn");
	}


	private void _on_ennemy3_player_dead()
	{
		GetTree().ChangeScene("res://mort.tscn");
	}
	
	private void _on_ennemy4_player_dead()
	{
		GetTree().ChangeScene("res://mort.tscn");
	}
	



}

































