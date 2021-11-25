using Godot;
using System;

public class end : Area2D
{
	int point =3;
	public override void _Ready()
	{
		
	}

	private void _on_end_body_entered(Area2D body)
	{
		if(body.IsInGroup("abd") && point == 7){
			GetTree().ChangeScene("res://endgame.tscn");
				
		}
	}
	private void _on_ennemy1_is_dead()
	{
		point++;
	}


	private void _on_ennemy2_is_dead()
	{
		point++;
	}


	private void _on_ennemy3_is_dead()
	{
		point++;
	}


	private void _on_ennemy4_is_dead()
	{
		point++;
	}
}






