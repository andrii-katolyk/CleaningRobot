using System.Collections.Generic;

namespace CleaningRobot.Core
{
	public class CleanOfficeCommand
	{
		public Position StartPosition { get; set; }

		public List<MovementCommand> MovementCommands { get; set; }
	}
}
