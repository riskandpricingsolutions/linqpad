<Query Kind="Program" />

// Question: Implement IEnumerator<int> so that it 
//           produces a sequence of integers from 0 to 3
public class MyEnumerator 
{

}

void Main()
{
	IEnumerator<int> enumerator = new MyEnumerator();
	
	var results1 = new List<int>();
	while (enumerator.MoveNext())
		results1.Add(enumerator.Current);
	MyExtensions.AreEqual(0,results1.First());
	MyExtensions.AreEqual(3,results1.Last());
	
	enumerator.Reset();
	results1.Clear();
	while (enumerator.MoveNext())
		results1.Add(enumerator.Current);
	MyExtensions.AreEqual(0, results1.First());
	MyExtensions.AreEqual(3, results1.Last());
}