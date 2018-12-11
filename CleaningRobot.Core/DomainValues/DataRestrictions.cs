namespace CleaningRobot.Core
{
	public static class DataRestrictions
	{
		public static readonly int CommandsCountMinValue = 0;
		public static readonly int CommandsCountMaxValue = 10000;

		public static readonly int XMinValue = -100000;
		public static readonly int XMaxValue = 100000;

		public static readonly int YMinValue = -100000;
		public static readonly int YMaxValue = 100000;

		public static readonly int MinStepsCount = 1;
		public static readonly int MaxStepsCount = 99000;
	}
}
