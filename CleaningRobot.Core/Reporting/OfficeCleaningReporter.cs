using System.Collections.Generic;

namespace CleaningRobot.Core
{
	public class OfficeCleaningReporter : IReporter
	{
		private HashSet<Position> _cleanedWorkingPlaces { get; set; }
		
		public OfficeCleaningReporter()
		{
			_cleanedWorkingPlaces = new HashSet<Position>();
		}

		public string GetReport()
		{
			return $"=> Cleaned: {_cleanedWorkingPlaces.Count}";
		}

		public int GetCleanedWorkingPlacesCount()
		{
			return _cleanedWorkingPlaces.Count;
		}

		public void LogRobotPosition(Position workingPlace)
		{
			if(workingPlace != null)
			{
				_cleanedWorkingPlaces.Add(workingPlace);
			}
		}
	}
}
