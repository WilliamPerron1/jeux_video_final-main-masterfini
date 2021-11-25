using Godot;
using System;

public class lvl2 : Node2D
{
	Control Pause;
	Button Quit;
	Button Resume;
	AudioStreamPlayer Volume;
	Label fps;
	Button v;
  

	public override void _Ready()
	{
		Volume = GetNode<AudioStreamPlayer>("song");
		Pause = GetNode<Control>("CanvasLayer/Pause");
		Pause.Visible = false;
		v = GetNode<Button>("HUD/volume");
		fps = GetNode<Label>("HUD/fps");
		fps.Visible = false;
	}
	
	public override void _PhysicsProcess(float delta)
	{
		fps.Text= "fps:"+Engine.GetFramesPerSecond().ToString();
		
		if (Input.IsActionJustPressed("pause")) {
				
				GetTree().Paused = true;
				Pause.Visible = true;
			} 
			
		if(Input.IsActionJustPressed("debug")){
			if(fps.Visible == false){
				fps.Visible = true;
			}else{
				fps.Visible = false;
			}
			
		}
		if(Input.IsActionJustPressed("skip")){
			
			GetTree().ChangeScene("res://endgame.tscn");
		}     
	}
	
	private void _on_Resume_pressed()
	{
		GetTree().Paused = false;
		Pause.Visible = false;
	}


	private void _on_Restart_pressed()
	{
		GetTree().ChangeScene("res://world.tscn");
		GetTree().Paused = false;
		Pause.Visible = false;
	}


	private void _on_Quit_pressed()
	{
		GetTree().ChangeScene("res://Menu.tscn");
		GetTree().Paused = false;
		Pause.Visible = false;
		
	}
	
	private void _on_volume_pressed()
	{
		if(Volume.Playing == true){
			Volume.Playing = false;
			v.Text = "volume off";
		}else{
			Volume.Playing = true;
			v.Text = "volume on";
			
		}
	}
	
	
}















