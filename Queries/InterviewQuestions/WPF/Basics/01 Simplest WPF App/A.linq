<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Windows</Namespace>
</Query>

// Question: Write the simplest possible WPF Main method. Do not use Application

// 2. A Win32 Window has to run inside a thread whose COM apartment
//    state is ApartmentState.STA
[STAThread]
public static void Main(String[] args)
{	
	// 1. The Window is just a Win32 Window. The OS does not
	// know the difference between a Window with Win32 content
	// and a window with WPF content
	Window window = new Window();
	window.Show();
	
	// 3 To make our STA Thread a UI Thread it needs an associated
	//   message loop. The message loop is setup by calling dispatcher.run. 
	//   The message loop sits inside a loop pull messages from a message queue
	//   and dispatching them
	
	// 4. Any WPF Object whose type extends DispatcherObject has thread affinity. It
	// must be created on a UI thread and can only be safely accessed from the UI 
	// thread that created it. If other threads want to access such an object they
	// must ask for its dispatcher
	System.Windows.Threading.Dispatcher.Run();	
}