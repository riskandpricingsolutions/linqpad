<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Namespace>System.Windows.Markup</Namespace>
</Query>

private static void Main(string[] args)
{
	using (var fs = new FileStream(@"C:\Users\rps\AppData\Local\MyLINQPad\linqpad\Queries\InterviewQuestions\WPF\Xaml\01\ObjectGraph.xaml",
		FileMode.Open, FileAccess.Read))
	{
		Option option = (Option)XamlReader.Load(fs);
		Console.WriteLine(option.Id);
	}
}

public class Option
{
	public string Id { get; set; }

}