using Godot;

public partial class Pause : Control
{
	public override void _Ready()
	{
		// Находим обе кнопки внутри Panel
		var exitButton = GetNode<Button>("Panel/Exit");
		var continueButton = GetNode<Button>("Panel/Continue"); // Имя кнопки должно быть Continue

		// Подписываемся на их нажатия
		exitButton.Pressed += OnExitPressed;
		continueButton.Pressed += OnContinuePressed;
	}

	// Логика для кнопки Exit (выход в меню)
	private void OnExitPressed()
	{
		GetTree().Paused = false; // Снимаем паузу
		QueueFree();              // Удаляем окно паузы
		GetTree().ChangeSceneToFile("res://scenes/menu.tscn"); // Идем в меню
	}

	// Логика для кнопки Continue (продолжить игру)
	private void OnContinuePressed()
	{
		GetTree().Paused = false; // Снимаем паузу
		
		// Просто удаляем это окно паузы. Сцена test.tscn останется на месте,
		// так как мы её не меняли.
		QueueFree(); 
	}
}
