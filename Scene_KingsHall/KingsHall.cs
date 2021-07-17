using Godot;
using System;

public class KingsHall : Node2D
{
	private Player player;
	private Keys keys;
	private KinematicBody2D big_knight;
	private Tween tween;
	private Timer timer;
	private Node2D dialogs_parent;
	private PackedScene dialog_ref = GD.Load<PackedScene>("res://Scene_Dialog/DialogBox2.tscn");
	private DialogBox2 current_dialog1 = null;
	private NameType name_type;
	private Area2D level_exit;
	private int cur_phase = -1;
	//Huxley Ealhstan Bannermane III

	private Vector2 king_dial_pos = new Vector2(680,100);
	public override void _Ready()
	{
		player = GetNode<Player>("YSort/Player");
		keys = GetNode<Keys>("Keys");
		big_knight = GetNode<KinematicBody2D>("YSort/BigKnight");
		tween = GetNode<Tween>("Tween");
		timer = GetNode<Timer>("Timer");
		dialogs_parent = GetNode<Node2D>("Dialogs");
		name_type = GetNode<NameType>("Triggers/NameType");
		level_exit = GetNode<Area2D>("Triggers/LevelExit");

		keys.SetPlayer(player);

		cur_phase = 0;
		//cur_phase = 12;
		AdvancePhase();
	}

	public void AdvancePhase()
	{
		switch(cur_phase)
		{
			case 0:
			{
				name_type.Visible = false;
				level_exit.Monitorable = false;
				player.SetControlEnabled(false);
				keys.Visible = false;
				tween.InterpolateProperty(big_knight, "position", big_knight.Position, big_knight.Position + new Vector2(0,-384), 6);
				tween.Start();
			}
			break;
			case 1:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 2:
			{
				DialogBox2 dial = CreateDialog(king_dial_pos, "You're here...", 3, 7, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 3:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 4:
			{
				current_dialog1.QueueFree();

				DialogBox2 dial = CreateDialog(king_dial_pos, "My bravest and most honored knight, Huxley Ealhstan Bannermane III.", 4, 18, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 5:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 6:
			{
				current_dialog1.QueueFree();
				DialogBox2 dial = CreateDialog(king_dial_pos, "The news of you slaying the Dragon of Mount Shawshank has reached me this morning.", 6, 14, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}	
			break;
			case 7:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 8:
			{
				current_dialog1.QueueFree();
				DialogBox2 dial = CreateDialog(king_dial_pos, "You have done well in service to the crown.", 3, 15, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 9:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 10:
			{
				current_dialog1.QueueFree();
				DialogBox2 dial = CreateDialog(king_dial_pos, "In the name of the crown, I hereby granted you my youngest daughter, Princess Nara's hand in marriage.", 7, 15, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 11:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 12:
			{
				current_dialog1.QueueFree();
				DialogBox2 dial = CreateDialog(new Vector2(680,486), "Thank you, your highness. Mere words cannot express my gratitude right now.", 4, 19, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 13:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 14:
			{
				current_dialog1.QueueFree();
				DialogBox2 dial = CreateDialog(king_dial_pos, "Get some rest for now. We'll discuss the ceremonies in more details later on.", 5, 15, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 15:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 16:
			{
				current_dialog1.QueueFree();
				player.SetControlEnabled(true);
				keys.Visible = true;
			}
			break;
			case 17:
			{
				Area2D first_trigger = GetNode<Area2D>("Triggers/FirstTrigger");
				first_trigger.Monitorable = false;
				player.SetControlEnabled(false);
				keys.Visible = false;

				DialogBox2 dial = CreateDialog(king_dial_pos, "Oh, right, I called you here as well.", 3, 15, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;

			}
			break;
			case 18:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 19:
			{
				current_dialog1.QueueFree();
				DialogBox2 dial = CreateDialog(king_dial_pos, "Um...", 2, 5, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(5);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 20:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 21:
			{
				current_dialog1.QueueFree();
				DialogBox2 dial = CreateDialog(king_dial_pos, "Sorry, but what was your name again?", 3, 15, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 22:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 23:
			{
				player.SetControlEnabled(false);
				current_dialog1.QueueFree();
				name_type.Visible = true;
			}
			break;
			case 24:
			{
				name_type.QueueFree();

				DialogBox2 dial = CreateDialog(king_dial_pos, "Wow, that's a mouthful to say.", 3, 16, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 25:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 26:
			{
				current_dialog1.QueueFree();

				DialogBox2 dial = CreateDialog(king_dial_pos, "By the order of the crown, your name is now Bo.", 3, 18, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 27:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 28:
			{
				current_dialog1.QueueFree();

				DialogBox2 dial = CreateDialog(king_dial_pos, "Anyway, Bo. There's a noise complaint from the faraway village of Dultsfall.", 4, 18, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 29:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 30:
			{
				current_dialog1.QueueFree();

				DialogBox2 dial = CreateDialog(king_dial_pos, "It's about 6hrs by horse so if you go now you might made it there before sunset.", 5, 17, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 31:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 32:
			{
				current_dialog1.QueueFree();

				DialogBox2 dial = CreateDialog(king_dial_pos, "Now get out of here, your face is bothering me.", 3, 17, true, false);
				dial.Modulate = new Color(1,1,1,0);
				tween.InterpolateProperty(dial, "modulate:a", 0, 1, 0.3f);
				dial.StartLoadingText(16);
				tween.Start();

				current_dialog1 = dial;
			}
			break;
			case 33:
			{
				timer.WaitTime = 3;
				timer.Start();
			}
			break;
			case 34:
			{
				current_dialog1.QueueFree();
				player.SetControlEnabled(true);
				level_exit.Monitorable = true;
			}
			break;
			case 35:
			{
				GD.Print("level exit");
			}
			break;
			/**
			case 10:
			{
				
			}
			break;
			**/
		}
		cur_phase += 1;
	}

	//When the tween finished
	private void _on_Tween_tween_all_completed()
	{
		if (cur_phase == 1)
		{
			AdvancePhase();
		}
	}

	//When the timer finished
	private void _on_Timer_timeout()
	{
		//if (cur_phase == 2)
		//{
			AdvancePhase();
		//}
	}

	public void _on_Dialog_Finished_Loading(){
		//GD.Print("Dialog finished loading");
		AdvancePhase();
	}

	private DialogBox2 CreateDialog(Vector2 dial_pos, String text, int x, int y, bool a, bool b)
	{
		DialogBox2 dial = (DialogBox2) dialog_ref.Instance();
		dialogs_parent.AddChild(dial);
		dial.Position = dial_pos;
		dial.Constructor(text, x, y, a, b);
		dial.SetVisibleTextLength(0);
		dial.Connect(nameof(DialogBox2.DialogFinished),this, nameof(_on_Dialog_Finished_Loading));
		return dial;
	}

	private void _on_FirstTrigger_body_entered(object body)
	{
		AdvancePhase();
	}

	private void _on_NameType_NameChosen(String name)
	{
		GlobalValues.typed_in_name = name;
		AdvancePhase();
	}

	private void _on_LevelExit_area_entered(object area)
	{
		AdvancePhase();
	}


}










