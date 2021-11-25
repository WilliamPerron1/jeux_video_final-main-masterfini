using Godot;
using System;

public class HUD : CanvasLayer
{
	Label label;
	public int p=0;
	
	
	public int GetP(){
		return p;
	}
	
	public override void _Ready()
	{
		label = GetNode<Label>("Point");
		
		label.Set("text", p.ToString());
		
	}
	
	private void _on_ennemy1_is_dead()
	{
		p++;
		label.Set("text", p.ToString());
	// Replace with function body.
	}


	private void _on_ennemy2_is_dead()
	{
		p++;
		label.Set("text", p.ToString());
	// Replace with function body.
	}


	private void _on_ennemy3_is_dead()
	{
		p++;
		label.Set("text", p.ToString());
	// Replace with function body.
	}



}






