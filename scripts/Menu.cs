using Godot;
using System;

public partial class Menu : Control
{
	private void _on_play_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/test.tscn");
	}

	private void _on_exit_pressed()
	{
		GetTree().Quit();
	}
}
