using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleaningRobot.Test
{
	[TestClass]
	public class CommandManagerTest
	{
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
	}
}
