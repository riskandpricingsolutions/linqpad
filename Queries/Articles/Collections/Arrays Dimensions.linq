<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	byte[,] a = new byte[3, 2]
	{
				{0, 1},
				{2, 3},
				{4, 5}
	};

	byte[,] b = new byte[2, 3]
	{
				{0, 1,2},
				{3, 4,5}
	};


	// Binary search
	WriteLine(Array.BinarySearch(new[] { 2, 4, 6, 8, 10},8)); // 3
	WriteLine(Array.BinarySearch(new[] { 10, 8, 6, 4, 2},8,new ReverseComparable<int>())); // 3

	// IndexOf
	WriteLine(Array.IndexOf(new[] { 2, 4, 4, 8, 10},4)); // 1 
	WriteLine(Array.LastIndexOf(new[] { 2, 4, 4, 8, 10},4)); // 2

	// FindIndex 
	WriteLine(Array.FindIndex(new[] { 2, 4, 4, 8, 10 }, x=> x/2 ==5)); // 4
	WriteLine(Array.FindLastIndex(new[] { 2, 4, 4, 8, 10 }, x=> x/2==2)); // 2
	
	WriteLine(Array.Find(new[] {"hello","world" }, x=> x.Contains('w'))); // world
	WriteLine(Array.FindLast(new[] {"one","two","three" }, x=> x.Contains('o'))); // two
	WriteLine(Array.FindAll(new[] {"one","two","three" }, x=> x.Contains('o')));

	// Sorts in place and does not generate a new array
	var unsorted = new[] { 4, 6, 1};
	Array.Sort(unsorted);
	WriteLine(unsorted);
	Array.Sort(unsorted,(x,y)=> y.CompareTo(x));
	WriteLine(unsorted);
	
	// reverse in place
	var reversable = new[] { 4, 2, 1};
	Array.Reverse(reversable);
	WriteLine(reversable);
	
	// Clone
	var clonable = new[] { 8, 9, 10};
	var cloned = clonable.Clone();
	WriteLine(Object.ReferenceEquals(clonable,cloned)); // false
	
	// CopyTo
	var cloned2 = new int[5];
	clonable.CopyTo(cloned2,2);
	WriteLine(cloned2); // {0,0,8,9,10}
	
	// Copy 
	var cloned3 = new int[2];
	Array.Copy(clonable,0,cloned3,0,2);
	WriteLine(cloned3); // {8,9}
	
	// Converting 
	var source =new[] { 8, 9, 10};
	var dest = Array.ConvertAll(source, x => x*x);
	WriteLine(Object.ReferenceEquals(source,dest)); // false
	WriteLine(dest); //{64,81,100}
}

public class ReverseComparable<T> : IComparer<T> where T : IComparable<T>
{
	public int Compare(T x, T y) => y.CompareTo(x);
}