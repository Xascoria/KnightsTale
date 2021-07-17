using Godot;
using System;

public class Keys : Node2D
{
	private KinematicBody2D player = null;
	private Vector2 relative_dist = new Vector2();

	public override void _Ready()
	{
		
	}

	public void SetPlayer(KinematicBody2D player)
	{
		this.player = player;
		this.relative_dist = this.GlobalPosition - player.GlobalPosition;
	}

	public override void _Process(float delta)
	{
		base._Process(delta);

		this.GlobalPosition = player.GlobalPosition + relative_dist;
	}
}
