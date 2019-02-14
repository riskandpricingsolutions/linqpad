<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// Initializing list
	List<int> i1 = new List<int>();  // Empty 
	List<int> i2 = new List<int>(new int[] { 1, 2, 3 }); // collection initialization
	List<int> i3 = new List<int>() { 1, 2, 3}; // Initalization list
	
	// List with initializer
	List<int> ints = new List<int>() {1,2,3};
	
	// Add 
	i1.Add(2);
	WriteLine(i1); // {2}
	i1.AddRange(new[] { 3, 4});
	WriteLine(i1); // {2,3,4}
	
	// Insert
	i1.Insert(0,1);
	WriteLine(i1); // {1, 2,3,4}
	i1.Insert(1,5);
	WriteLine(i1); // {1,5,2,3,4};
	i1.InsertRange(1, new[] { 6, 6}); 
	WriteLine(i1); // {1,6,6,5,2,3,4};
	i1.Insert(i1.Count,20);
	WriteLine(i1);
	WriteLine(i1); // {1,6,6,5,2,3,4,20};
	
	// Removal 
	i1.RemoveAll(i=> i==6);
	WriteLine(i1); // {1,5,2,3,4,20};
	i1.Remove(2);
	WriteLine(i1); // {1,5,3,4,20};
	i1.RemoveAt(1);
	WriteLine(i1); // {1,3,4,20};
	i1.RemoveRange(1,2);
	WriteLine(i1); // {1,20};
	
	// Copying
	int[] a1 = i1.ToArray();
	WriteLine(a1); // {1,20}
	int[] a2 = new int[2];
	i1.CopyTo(a2);
	WriteLine(a2); // {1,20}
	int[] a3 = new int[6];
	i1.CopyTo(a3,2);
	WriteLine(a3); // {0,0,1,20,0,0}
	
	// Readonly
	IReadOnlyCollection<int> roc =i1.AsReadOnly();
	WriteLine(object.ReferenceEquals(roc,i1)); // false
	
	//Reverse 
	i1.Reverse();
	WriteLine(i1);// {20,1}
	
	// Conversion
	var i4 = i1.ConvertAll(i=> i*i);
	WriteLine(object.ReferenceEquals(i4,i1)); // false
	WriteLine(i4); // {400,1}
	
	// ToDo: Searching and sorting - work similarly to arrays
	
	
	
}