using System;
using System.Collections.Generic;
using CleaningRobot.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleaningRobot.Test
{
	[TestClass]
	public class RobotTest
	{
		private CleanOfficeCommand _cleaningCommand;

		[TestInitialize]
		public void TestInitialize()
		{
			_cleaningCommand = new CleanOfficeCommand();
			_cleaningCommand.StartPosition = new Position { X = 10, Y = 22 };
			_cleaningCommand.MovementCommands = new List<MovementCommand>();
			_cleaningCommand.MovementCommands.Add(new MovementCommand { Direction = Direction.East, StepsCount = 2 });
			_cleaningCommand.MovementCommands.Add(new MovementCommand { Direction = Direction.North, StepsCount = 1 });
		}

		[TestMethod]
		public void CreateRobot_CleanOffice_CheckEndPosition()
		{
			Robot robot = new Robot(_cleaningCommand, null);

			robot.CleanOffice();

			Assert.AreEqual(robot.CurrentPosition, new Position { X = 12, Y = 23 });
		}

		[TestMethod]
		public void CreateRobot_AddReporting_CleanOffice_CleanedPlacesEqualThree()
		{
			var reporter = new OfficeCleaningReporter();

			Robot robot = new Robot(_cleaningCommand, reporter);

			robot.CleanOffice();

			var cleanedPlaces = reporter.GetCleanedWorkingPlacesCount();

			Assert.AreEqual(4, cleanedPlaces);
		}

		[TestMethod]
		public void CreateRobotWithCommandManager_CleanOffice_CleanedPlacesCountIsCorrect()
		{
			CommandManager manager = new CommandManager();
			manager.AddInputParameters("4");
			manager.AddInputParameters("0 0");
			manager.AddInputParameters("N 5");
			manager.AddInputParameters("E 5");
			manager.AddInputParameters("S 5");
			manager.AddInputParameters("W 5");

			var reporter = new OfficeCleaningReporter();

			var robot = new Robot(manager.CleanOfficeCommand, reporter);
			robot.CleanOffice();

			var placesCount = reporter.GetCleanedWorkingPlacesCount();

			Assert.AreEqual(20, placesCount);
		}

		[TestMethod]
		public void CreateRobot_AddMaxCountOfCommands_CleanedPlacesCountIsCorrect()
		{
			CommandManager manager = new CommandManager();
			manager.AddInputParameters("10000");
			manager.AddInputParameters("-100000 0");

			for(int i=0; i < 10000; i++)
			{
				manager.AddInputParameters("E 10");
			}
			
			var reporter = new OfficeCleaningReporter();

			var robot = new Robot(manager.CleanOfficeCommand, reporter);
			robot.CleanOffice();

			var placesCount = reporter.GetCleanedWorkingPlacesCount();

			Assert.AreEqual(100001, placesCount);
		}

		[TestMethod]
		public void CreateRobot_SendOutOfTheBounds_RobotIsNotMovingOutOfTheBounds()
		{
			CommandManager manager = new CommandManager();
			manager.AddInputParameters("1");
			manager.AddInputParameters("-99999 0");
			manager.AddInputParameters("W 2");
			
			var reporter = new OfficeCleaningReporter();

			var robot = new Robot(manager.CleanOfficeCommand, reporter);
			robot.CleanOffice();

			var placesCount = reporter.GetCleanedWorkingPlacesCount();

			Assert.AreEqual(2, placesCount);
		}
	}
}
