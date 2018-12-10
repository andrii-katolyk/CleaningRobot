using System;
using System.Collections.Generic;

namespace CleaningRobot.Core
{
	public class CommandManager
	{
		public bool IsCommandsSetComplete { get; set; }

		private int _inputedParametersCount { get; set; }
		private int _commandsCount { get; set; }
		private CleanOfficeCommand _cleanOfficeCommand { get; set; }
		
		public void AddInputParameters(string parameter)
		{
			if(_inputedParametersCount == 0)
			{
				_commandsCount = Convert.ToInt32(parameter);
				IsCommandsSetComplete =
					_commandsCount == 0;
			}
			else if(_inputedParametersCount == 1)
			{
				var inputPosition = parameter.Split(' ');
				var startPosition = new Position
				{
					X = Convert.ToInt32(inputPosition[0]),
					Y = Convert.ToInt32(inputPosition[1])
				};
				_cleanOfficeCommand = new CleanOfficeCommand
				{
					StartPosition = startPosition
				};
			}
			else
			{
				if(_cleanOfficeCommand != null)
				{
					var inputCommand = parameter.Split(' ');

					var movementCommand = new MovementCommand
					{
						Direction = GetDirection(inputCommand[0]),
						StepsCount = Convert.ToInt32(inputCommand[1])
					};

					if(_cleanOfficeCommand.MovementCommands == null)
					{
						_cleanOfficeCommand.MovementCommands = new List<MovementCommand>();
					}

					_cleanOfficeCommand.MovementCommands.Add(movementCommand);

					IsCommandsSetComplete = _commandsCount == 0 ||
						_cleanOfficeCommand.MovementCommands.Count >= _commandsCount;
				}
			}

			_inputedParametersCount++;
		}

		private Direction GetDirection(string directionCode)
		{
			var direction = Direction.Default;

			switch(directionCode)
			{
				case "E":
					direction = Direction.East;
					break;
				case "W":
					direction = Direction.West;
					break;
				case "S":
					direction = Direction.South;
					break;
				case "N":
					direction = Direction.North;
					break;
			}

			return direction;
		}

		public CleanOfficeCommand GetCleanOfficeCommand()
		{
			return _cleanOfficeCommand;
		}
	}
}
