<Query Kind="Program">
  <NuGetReference>log4net</NuGetReference>
  <NuGetReference>System.Diagnostics.StackTrace</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Appender</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>log4net.Layout</Namespace>
  <Namespace>log4net.Repository.Hierarchy</Namespace>
  <Namespace>static System.Console</Namespace>
  <RemoveNamespace>System.Collections</RemoveNamespace>
  <RemoveNamespace>System.Data</RemoveNamespace>
  <RemoveNamespace>System.IO</RemoveNamespace>
  <RemoveNamespace>System.Linq.Expressions</RemoveNamespace>
  <RemoveNamespace>System.Reflection</RemoveNamespace>
  <RemoveNamespace>System.Text</RemoveNamespace>
  <RemoveNamespace>System.Text.RegularExpressions</RemoveNamespace>
  <RemoveNamespace>System.Threading</RemoveNamespace>
  <RemoveNamespace>System.Transactions</RemoveNamespace>
  <RemoveNamespace>System.Xml</RemoveNamespace>
  <RemoveNamespace>System.Xml.Linq</RemoveNamespace>
  <RemoveNamespace>System.Xml.XPath</RemoveNamespace>
</Query>

void Main()
{
	// Write code to test your extensions here. Press F5 to compile and run.
}

public static class MyExtensions
{
	public static void SetupLog4Net(string conversionPattern)
	{
		Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository("Repository");
		ILog logger = LogManager.GetLogger(typeof(MyExtensions));

		if (!hierarchy.Configured)
		{
			PatternLayout patternLayout = new PatternLayout();
			patternLayout.ConversionPattern = $"[%thread] %message%newline";
			patternLayout.ActivateOptions();
			ConsoleAppender roller = new ConsoleAppender();
			roller.Layout = patternLayout;
			roller.ActivateOptions();
			hierarchy.Root.AddAppender(roller);
			hierarchy.Root.Level = Level.Info;
			hierarchy.Configured = true;
		}
	}

	public static void SetupLog4Net() => SetupLog4Net("[%thread]  %message%newline");

	public static string GetStackTraceString(int numFrames)
	{
		StackTrace t = new StackTrace();
		List<string> methods = t.GetFrames()
		.Skip(1)
		.Take(numFrames)
		.Select(x => x.GetMethod().Name)
		.ToList();

		return "Stack Trace\n" +
		"----------------------------------\n" + String.Join("\n", methods);
	}

	public static void AreEqual<T>(T expected, T actual,
		[System.Runtime.CompilerServices.CallerMemberNameAttribute] string memberName = "")
	{
		if (Object.Equals(expected, actual))
			Console.WriteLine($"{memberName} passed, expected {expected}, actual {actual}");
		else
			Console.WriteLine($"{memberName} failed, expected {expected}, actual {actual}");

	}

}

// You can also define non-static classes, enums, etc.


#region Advanced - How to multi-target

// The NET5 symbol can be useful when you want to run some queries under .NET 5 and others under .NET Core 3:

#if NET5
// Code that requires .NET 5 or later
#endif

#endregion