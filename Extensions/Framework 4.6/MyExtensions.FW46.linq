<Query Kind="Program">
  <NuGetReference>log4net</NuGetReference>
  <Namespace>log4net.Repository.Hierarchy</Namespace>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Layout</Namespace>
  <Namespace>log4net.Appender</Namespace>
  <Namespace>log4net.Core</Namespace>
</Query>

void Main()
{
	// Write code to test your extensions here. Press F5 to compile and run.
}

public static class MyExtensions
{
	public static void SetupLog4Net()
	{
		Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
		ILog logger = LogManager.GetLogger("Main");

		if (!hierarchy.Configured)
		{
			PatternLayout patternLayout = new PatternLayout();
			patternLayout.ConversionPattern = "%time [%thread]  %message%newline";
			patternLayout.ActivateOptions();
			ConsoleAppender roller = new ConsoleAppender();
			roller.Layout = patternLayout;
			roller.ActivateOptions();
			hierarchy.Root.AddAppender(roller);
			hierarchy.Root.Level = Level.Info;
			hierarchy.Configured = true;
		}
	}	
}

// You can also define non-static classes, enums, etc.