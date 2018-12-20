<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Question: Implement Task.Run such that it implements the given Action on a new thread
public static Task<T> Run<T>(Func<T> f)
{
	TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
	Thread t = new Thread(() =>
	{
		tcs.SetResult(f());
	});
	
	return tcs.Task;
}