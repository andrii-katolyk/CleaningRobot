namespace CleaningRobot.Core
{
	public class Robot
	{
		private CleanOfficeCommand _cleanOfficeCommand { get; set; }
		private IReporter _reporter { get; set; }
		private Position _currentPosition { get; set; }

		public Robot(CleanOfficeCommand cleanOfficeCommand, IReporter reporter)
		{
			_cleanOfficeCommand = cleanOfficeCommand;
			_reporter = reporter;
			_currentPosition = cleanOfficeCommand.StartPosition;
		}

		public void CleanOffice()
		{
			if(_reporter != null)
			{
				_reporter.LogRobotPosition(_currentPosition);
			}

			foreach(var movementCommand in _cleanOfficeCommand.MovementCommands)
			{
				MoveToNextPlace(movementCommand);
				_reporter.LogRobotPosition(_currentPosition);
			}
		}

		public string GetCleaningReport()
		{
			var report = "=> Cleaned: 0";

			if(_reporter != null)
			{
				report =  _reporter.GetReport();
			}

			return report;
		}

		private void MoveToNextPlace(MovementCommand movement)
		{
			switch (movement.Direction)
			{
				case Direction.East:
					_currentPosition.X += movement.StepsCount;
					break;
				case Direction.West:
					_currentPosition.X -= movement.StepsCount;
					break;
				case Direction.South:
					_currentPosition.Y -= movement.StepsCount;
					break;
				case Direction.North:
					_currentPosition.Y += movement.StepsCount;
					break;
			}
		}
	}
}
