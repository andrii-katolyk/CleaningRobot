using CleaningRobot.Core;
using System;

namespace CleaningRobot
{
	class Program
	{
		static void Main(string[] args)
		{
			var commandManager = new CommandManager();

			Console.WriteLine("Input Robot parameters:");

			while (!commandManager.IsCommandsSetComplete)
			{
				Console.Write("=> ");
				commandManager.AddInputParameters(Console.ReadLine());
			}

			Console.WriteLine("Robot starts cleaning the Office...");

			var reporter = new OfficeCleaningReporter();

			var robot = new Robot(commandManager.CleanOfficeCommand, reporter);

			robot.CleanOffice();

			Console.WriteLine(robot.GetCleaningReport());

			Console.ReadLine();
		}
	}
}
