using Godot;
using System;

public class NameType : Node2D
{
	private Label warning_label;
	private LineEdit line_edit;
	private Timer end_timer;
	[Signal]
	public delegate void NameChosen(String name);
	private bool name_accepted = false;
	public override void _Ready()
	{
		warning_label = GetNode<Label>("WarningLabel");
		line_edit = GetNode<LineEdit>("LineEdit");
		end_timer = GetNode<Timer>("Timer");

		warning_label.Text = "";
	}

	//Setting the warning labels
	private void _on_EnterButton_pressed()
	{
		if (name_accepted) return;

		String le_text = line_edit.Text;
		if (le_text.Length < 8)
		{
			warning_label.Text = "Name must be at least 8 characters long.";
		} 
		else 
		{
			bool has_number = false;
			bool has_symbol = false;
			bool has_upper = false;
			bool has_lower = false;
			bool has_space = false;
			foreach (char chr in le_text)
			{
				if (Char.IsDigit(chr))
				{
					has_number = true;
				} 
				else if (!Char.IsLetterOrDigit(chr))
				{
					has_symbol = true;
				}
				if (Char.IsUpper(chr))
				{
					has_upper = true;
				}
				else if (Char.IsLower(chr))
				{
					has_lower = true;
				}
				if (chr == ' ')
				{
					has_space = true;
				}
			}
			if (!has_number)
			{
				warning_label.Text = "Username must have at least one digit in it.";
			}
			else if (!has_symbol)
			{
				warning_label.Text = "Username must have at least one non-letter symbol in it.";
			}
			else if (!(has_upper && has_lower))
			{
				if (!has_upper && !has_lower)
				{
					warning_label.Text = "Username must have at least one letter in it.";
				}
				else if (!has_upper)
				{
					warning_label.Text = "Password must have at least one capital letter in it.";
				}
				else if (!has_lower)
				{
					warning_label.Text = "Password must have at least one lower letter in it.";
				}
			}
			else if (has_space)
			{
				warning_label.Text = "Username cannot contains space.";
			} 
			else if (le_text.Length < 18)
			{
				warning_label.Text = "Username must be at least 18 characters long.";
			}
			else if (le_text.Length > 30)
			{
				warning_label.Text = "Password cannot be longer than 30 characters.";
			}
			else 
			{
				warning_label.Text = "Password accepted!";
				end_timer.Start();
				name_accepted = true;
			}
		}
	}

	private void _on_Timer_timeout()
	{
		EmitSignal(nameof(NameChosen), line_edit.Text);
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event is InputEventKey)
		{
			InputEventKey key_eve = (InputEventKey) @event;
			if (key_eve.IsPressed() && key_eve.Scancode == (int) KeyList.Enter)
			{
				_on_EnterButton_pressed();
			}
		}
	}

}




