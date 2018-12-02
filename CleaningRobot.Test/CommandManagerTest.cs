using System;
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

			manager.AddInputCommand("0");
			manager.AddInputCommand("10 22");
			
			Assert.IsTrue(manager.IsCommandsSetComplete);
		}

		[TestMethod]
		public void CommandManager_AddZeroCommandsCount_AddOneCommand_CommandsSetIsComplete()
		{
			CommandManager manager = new CommandManager();

			manager.AddInputCommand("0");
			manager.AddInputCommand("10 22");
			manager.AddInputCommand("N 1");

			Assert.IsTrue(manager.IsCommandsSetComplete);
		}

		[TestMethod]
		public void CommandManager_AddTwoCommands_CommandsSetIsComplete()
		{
			CommandManager manager = new CommandManager();

			manager.AddInputCommand("2");
			manager.AddInputCommand("10 22");
			manager.AddInputCommand("E 2");
			manager.AddInputCommand("N 1");

			Assert.IsTrue(manager.IsCommandsSetComplete);
		}

		[TestMethod]
		public void CommandManager_AddTenThousendsCommands_CommandsSetIsComplete()
		{
			CommandManager manager = new CommandManager();

			manager.AddInputCommand("10000");
			manager.AddInputCommand("10 22");

			for (var i = 0; i <= 10000; i++)
			{
				manager.AddInputCommand("N 1");
			}
			
			Assert.IsTrue(manager.IsCommandsSetComplete);
		}

		[TestMethod]
		public void CommandManager_AddFiveCommandsCount_AddTwo_CommandsSetIsNotComplete()
		{
			CommandManager manager = new CommandManager();

			manager.AddInputCommand("5");
			manager.AddInputCommand("10 22");
			manager.AddInputCommand("E 2");
			manager.AddInputCommand("N 1");

			Assert.IsFalse(manager.IsCommandsSetComplete);
		}
	}
}
