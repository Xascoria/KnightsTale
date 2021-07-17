using Godot;
using System;

public class Player : KinematicBody2D
{
	private static float speed = 4;
	private bool control_enabled = true;

	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);

		Vector2 dir = new Vector2();
		if (Input.IsKeyPressed((int) KeyList.W)){
			dir += new Vector2(0,-speed);
		}
		if (Input.IsKeyPressed((int) KeyList.S)){
			dir += new Vector2(0,speed);
		}
		if (Input.IsKeyPressed((int) KeyList.A)){
			dir += new Vector2(-speed,0);
		}
		if (Input.IsKeyPressed((int) KeyList.D)){
			dir += new Vector2(speed,0);
		}

		if (control_enabled)
		{
			MoveAndCollide(new Vector2(dir.x, 0));
			MoveAndCollide(new Vector2(0, dir.y));
		}
	}

	public void SetControlEnabled(bool ctr) {
		control_enabled = ctr;
	}

}
