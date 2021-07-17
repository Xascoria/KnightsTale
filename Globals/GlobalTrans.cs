using Godot;
using System;

public class GlobalTrans : CanvasLayer
{
	private String next_scene = "";
	private Panel panel;
	private Tween tween;
	[Export]
	private NodePath panel_path;
	[Export]
	private NodePath tween_path;
	private const float transition_time = 1.0f;
	public override void _Ready()
	{
		panel = GetNode<Panel>(panel_path);
		tween = GetNode<Tween>(tween_path);
		panel.RectPosition = new Vector2(0, -720);

		//TriggerSceneTransition();
	}

	public void SetNextScene(String new_scene)
	{
		next_scene = new_scene;
	}

	private bool has_changed_scene = false;
	public void TriggerSceneTransition()
	{
		if (!has_changed_scene){
			tween.InterpolateProperty(panel, "rect_position", panel.RectPosition, new Vector2(0,0), transition_time/2);
			tween.Start();
		} 
	}

	private void _on_Tween_tween_all_completed()
	{
		if (!has_changed_scene)
		{
			GetTree().ChangeScene(next_scene);
			has_changed_scene = true;
			tween.InterpolateProperty(panel, "rect_position", panel.RectPosition, panel.RectPosition + new Vector2(0, 720), transition_time/2);
			tween.Start();
		}
		else
		{
			has_changed_scene = false;
			panel.RectPosition = new Vector2(0, -720);
		}
	}

}


