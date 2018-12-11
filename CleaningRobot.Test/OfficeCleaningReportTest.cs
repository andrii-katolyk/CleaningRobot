using CleaningRobot.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleaningRobot.Test
{
	[TestClass]
	public class OfficeCleaningReportTest
	{
		[TestMethod]
		public void CreateReport_GetReport_ShouldBeNotNullAndNotEmpty()
		{
			OfficeCleaningReporter reporter = new OfficeCleaningReporter();

			string report = reporter.GetReport();

			Assert.IsNotNull(report);
			Assert.IsFalse(string.IsNullOrEmpty(report));
		}

		[TestMethod]
		public void CreateReport_AddUniquePositions_CleanedPlacesCountIsEqualToPositionsCount()
		{
			OfficeCleaningReporter reporter = new OfficeCleaningReporter();

			reporter.LogRobotPosition(new Position { X = 0, Y = 0 });
			reporter.LogRobotPosition(new Position { X = 1, Y = 0 });
			reporter.LogRobotPosition(new Position { X = 1, Y = 1 });

			var uniquePlaces = reporter.GetCleanedWorkingPlacesCount();

			Assert.AreEqual(3, uniquePlaces);
		}

		[TestMethod]
		public void CreateReport_AddPositions_ReturnedOnlyUniquePlacesCount()
		{
			OfficeCleaningReporter reporter = new OfficeCleaningReporter();

			reporter.LogRobotPosition(new Position { X = 0, Y = 0 });
			reporter.LogRobotPosition(new Position { X = 1, Y = 0 });
			reporter.LogRobotPosition(new Position { X = 1, Y = 1 });
			reporter.LogRobotPosition(new Position { X = 1, Y = 0 });

			var uniquePlaces = reporter.GetCleanedWorkingPlacesCount();

			Assert.AreEqual(3, uniquePlaces);
		}
	}
}
