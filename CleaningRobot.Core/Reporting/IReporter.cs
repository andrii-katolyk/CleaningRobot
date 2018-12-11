namespace CleaningRobot.Core
{
	public interface IReporter
	{
		string GetReport();

		void LogRobotPosition(Position workingPlace);
	}
}
