<Query Kind="Program" />

void Main()
{
	int[] sizes = new int[] {100,250,1000};
	
	minComputation(sizes);
}



static int minComputation(int[] files)
{

	// create a min heap 
	MinPriorityQueue pq
		= new MinPriorityQueue();

	for (int i = 0; i < files.Length; i++)
	{

		// add sizes to priorityQueue 
		pq.Insert(files[i]);
	}

	// variable to count total computations 
	int count = 0;

	while (pq.Size > 1)
	{

		// pop two smallest size element 
		// from the min heap 
		int temp = pq.DelMin() + pq.DelMin();

		// add the current computations 
		// with the previous one's 
		count += temp;

		// add new combined file size 
		// to priority queue or min heap 
		pq.Insert(temp);
	}

	return count;
}



public class MinPriorityQueue
{
	private List<int> list = new List<int>();
	public int Min 
	{
		get 
		{
			if (list.Count <1) throw new InvalidOperationException();
			return list[0];
		}
	}
	
	public void Insert(int key)
	{
		int index = list.BinarySearch(key);
		
		if (index >=0) list.Insert(index,key);
		else list.Insert(~index,key);	
	}
	
	public int Size => list.Count;
	
	public int DelMin()
	{
		if (list.Count < 1) throw new NotImplementedException();
		
		int smallest = list[0];
		list.RemoveAt(0);
		return smallest;
	}
}

// Define other methods and classes here
