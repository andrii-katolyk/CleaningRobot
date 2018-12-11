using System.Linq;

namespace CleaningRobot.Core
{
	public class Robot
	{
		public Position CurrentPosition { get; private set; }

		private CleanOfficeCommand _cleanOfficeCommand { get; set; }
		private IReporter _reporter { get; set; }
		
		public Robot(CleanOfficeCommand cleanOfficeCommand, IReporter reporter)
		{
			_cleanOfficeCommand = cleanOfficeCommand;
			_reporter = reporter;
			CurrentPosition = cleanOfficeCommand.StartPosition;
		}

		public void CleanOffice()
		{
			if (_cleanOfficeCommand.MovementCommands.Any())
			{
				_reporter?.LogRobotPosition(CurrentPosition);
			}

			foreach(var movementCommand in _cleanOfficeCommand.MovementCommands)
			{
				for (int step = 0; step < movementCommand.StepsCount; step++)
				{
					CleanNextPlace(movementCommand.Direction);
				}
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

		private void CleanNextPlace(Direction direction)
		{
			switch (direction)
			{
				case Direction.East:
					CurrentPosition = new Position { X = CurrentPosition.X + 1, Y = CurrentPosition.Y };
					break;
				case Direction.West:
					CurrentPosition = new Position { X = CurrentPosition.X - 1, Y = CurrentPosition.Y };
					break;
				case Direction.South:
					CurrentPosition = new Position { X = CurrentPosition.X, Y = CurrentPosition.Y - 1 };
					break;
				case Direction.North:
					CurrentPosition = new Position { X = CurrentPosition.X, Y = CurrentPosition.Y + 1};
					break;
			}
			_reporter?.LogRobotPosition(CurrentPosition);
		}
	}
}