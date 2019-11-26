<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();

	// Question: Give examples of all the following
	
	// 1. Where
	Observable.Range(0,10)
		.Where(x=>x%2==0)
		.Subscribe(o => logger.Info($"OnNext({o})"),()=>logger.Info("OnCompleted()"));
	

	// 2. Distinct
	WriteLine();
	Subject<int> s = new Subject<int>();
	s.Distinct()
	 .Subscribe(o => logger.Info($"OnNext({o})"),() => logger.Info("OnCompleted()"));
	s.OnNext(1);
	s.OnNext(1);
	s.OnNext(2);
	s.OnNext(1);
	s.OnCompleted();

	// 3. DistinctUntilChanged
	WriteLine();
	Subject<int> s2 = new Subject<int>();
	s2.DistinctUntilChanged()
	 .Subscribe(o => logger.Info($"OnNext({o})"),() => logger.Info("OnCompleted()"));
	s2.OnNext(1);
	s2.OnNext(1);
	s2.OnNext(2);
	s2.OnNext(1);
	s2.OnCompleted();

	// 4. IgnoreElements
	WriteLine();
	Observable.Range(0, 10)
	.IgnoreElements()
	.Subscribe(o => logger.Info($"OnNext({o})"),() => logger.Info("OnCompleted()"));

	// 5. Skip
	WriteLine();
	Observable.Range(0, 10)
		.Skip(7)
		.Subscribe(o => logger.Info($"OnNext({o})"),() => logger.Info("OnCompleted()"));

	// 6. Take
	WriteLine();
	Observable.Range(0, 10)
		.Take(2)
		.Subscribe(o => logger.Info($"OnNext({o})"),() => logger.Info("OnCompleted()"));

	// 7 SkipWhile
	WriteLine();
	Observable.Range(0, 10)
		.SkipWhile(i => i<8)
		.Subscribe(o => logger.Info($"OnNext({o})"),() => logger.Info("OnCompleted()"));

	// 8 TakeWhile
	WriteLine();
	Observable.Range(0, 10)
		.TakeWhile(i => i < 2)
		.Subscribe(o => logger.Info($"OnNext({o})"),() => logger.Info("OnCompleted()"));

	// 9. SkipUntil a value is produced by another source
	WriteLine();
	Subject<int> s3 = new Subject<int>();
	Subject<int> s4 = new Subject<int>();
	s4
		.SkipUntil(s3)
		.Subscribe(o => logger.Info($"OnNext({o})"),() => logger.Info("OnCompleted()"));
	s4.OnNext(10);
	s3.OnNext(-1);
	s4.OnNext(12);

	// 10. TakeUntil
	WriteLine();
	Subject<int> s5 = new Subject<int>();
	Subject<int> s6 = new Subject<int>();
	s5
		.TakeUntil(s6)
		.Subscribe(o => logger.Info($"OnNext({o})"),() => logger.Info("OnCompleted()"));
	s5.OnNext(10);
	s6.OnNext(-1);
	s5.OnNext(12);


}