using System;
using CleaningRobot.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleaningRobot.Test
{
	[TestClass]
	public class CommandManagerTest
	{
		[TestMethod]
		public void CommandManager_AddZeroCommands_CommandsSetIsComplete()
		{
			CommandManager manager = new CommandManager();

			manager.AddInputParameters("0");
			manager.AddInputParameters("10 22");
			
			Assert.IsTrue(manager.IsCommandsSetComplete);
		}

		[TestMethod]
		public void CommandManager_AddZeroCommandsCount_AddOneCommand_CommandsSetIsComplete()
		{
			CommandManager manager = new CommandManager();

			manager.AddInputParameters("0");
			manager.AddInputParameters("10 22");
			manager.AddInputParameters("N 1");

			Assert.IsTrue(manager.IsCommandsSetComplete);
		}

		[TestMethod]
		public void CommandManager_AddTwoCommands_CommandsSetIsComplete()
		{
			CommandManager manager = new CommandManager();

			manager.AddInputParameters("2");
			manager.AddInputParameters("10 22");
			manager.AddInputParameters("E 2");
			manager.AddInputParameters("N 1");

			Assert.IsTrue(manager.IsCommandsSetComplete);
		}

		[TestMethod]
		public void CommandManager_AddTenThousendsCommands_CommandsSetIsComplete()
		{
			CommandManager manager = new CommandManager();

			manager.AddInputParameters("10000");
			manager.AddInputParameters("10 22");

			for (var i = 0; i <= 10000; i++)
			{
				manager.AddInputParameters("N 1");
			}
			
			Assert.IsTrue(manager.IsCommandsSetComplete);
		}

		[TestMethod]
		public void CommandManager_AddFiveCommandsCount_AddTwo_CommandsSetIsNotComplete()
		{
			CommandManager manager = new CommandManager();

			manager.AddInputParameters("5");
			manager.AddInputParameters("10 22");
			manager.AddInputParameters("E 2");
			manager.AddInputParameters("N 1");

			Assert.IsFalse(manager.IsCommandsSetComplete);
		}
	}
}
