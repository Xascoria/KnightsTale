using Godot;
using System;

public class DialogBox2 : Node2D
{
	private int height = -1;
	private int length = -1;
	private int char_per_second = 1;
	private TileMap chatbox_map;
	private Label chat_label;
	private Tween tween;
	[Signal]
	public delegate void DialogFinished();

	private const String TILE_MIDDLE = "Middle";
	private const String TILE_BOTTOM_LEFT = "BottomLeft";
	private const String TILE_BOTTOM_RIGHT = "BottomRight";
	private const String TILE_TOP_LEFT = "TopLeft";
	private const String TILE_TOP_RIGHT = "TopRight";
	private const String TILE_SPEAK = "Speak";
	public override void _Ready()
	{
		chatbox_map = GetNode<TileMap>("TileMap");
		chat_label = GetNode<Label>("Label");
		tween = GetNode<Tween>("Tween");

		Constructor("Now get out of here, your face is bothering me.", 3, 17, true, false);
	}

	public void Constructor(String text, int height, int length, bool speak_upside_down, bool speak_on_right)
	{
		chatbox_map.Clear();
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < height; j++)
			{
				chatbox_map.SetCell(i,j,chatbox_map.TileSet.FindTileByName(TILE_MIDDLE));
			}
		}
		this.height = height;
		this.length = length;
		chatbox_map.SetCell(0,height-1,chatbox_map.TileSet.FindTileByName(TILE_BOTTOM_LEFT));
		chatbox_map.SetCell(length-1,height-1,chatbox_map.TileSet.FindTileByName(TILE_BOTTOM_RIGHT));
		chatbox_map.SetCell(0,0,chatbox_map.TileSet.FindTileByName(TILE_TOP_LEFT));
		chatbox_map.SetCell(length-1,0,chatbox_map.TileSet.FindTileByName(TILE_TOP_RIGHT));

		chat_label.Text = text;
		chat_label.RectSize = new Vector2(16*(length-1),height*16);

		int speak_x = 0;
		int speak_y = height;
		if (speak_upside_down)
		{
			speak_y = -1;
		}
		if (speak_on_right)
		{
			speak_x = length-2;
		}
		chatbox_map.SetCell(speak_x, speak_y, chatbox_map.TileSet.FindTileByName(TILE_SPEAK), speak_on_right, speak_upside_down);
	}

	public void SetVisibleTextLength(int new_vis_char)
	{
		chat_label.VisibleCharacters = new_vis_char;
	}

	public void StartLoadingText(int char_per_sec)
	{	
		this.char_per_second = char_per_sec;
		int str_with_no_space_len = chat_label.Text.Replace(" ","").Length;
		tween.InterpolateProperty(chat_label, "visible_characters", 0, str_with_no_space_len, str_with_no_space_len/((float) char_per_second));
		tween.Start();
	}

	private void _on_Tween_tween_all_completed()
	{
		EmitSignal(nameof(DialogFinished));
	}
}



