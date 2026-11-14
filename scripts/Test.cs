using Godot;

public partial class Test : Node
{
	// Заранее загружаем сцену паузы
	private PackedScene _pauseScene = GD.Load<PackedScene>("res://scenes/pause.tscn");
	private Control _pauseInstance;

	public override void _UnhandledInput(InputEvent @event)
	{
		// Проверяем нажатие клавиши Esc (ui_cancel)
		if (@event.IsActionPressed("ui_cancel"))
		{
			if (!GetTree().Paused)
			{
				PauseGame();
			}
			else
			{
				ResumeGame();
			}
			
			// Говорим движку, что мы обработали ввод, чтобы он не шел дальше
			GetViewport().SetInputAsHandled();
		}
	}

	private void PauseGame()
	{
		// Ставим дерево на паузу
		GetTree().Paused = true;
		
		// Создаем экземпляр сцены паузы и добавляем в корень
		_pauseInstance = _pauseScene.Instantiate<Control>();
		GetTree().Root.AddChild(_pauseInstance);
	}

	private void ResumeGame()
	{
		// Снимаем паузу
		GetTree().Paused = false;
		
		// Удаляем окно паузы, если оно существует
		if (IsInstanceValid(_pauseInstance))
		{
			_pauseInstance.QueueFree();
			_pauseInstance = null;
		}
	}
}
