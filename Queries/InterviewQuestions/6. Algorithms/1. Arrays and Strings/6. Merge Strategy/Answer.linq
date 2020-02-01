<Query Kind="Program" />

void Main()
{

}

// Question: Given an array of integers and an integer k, you need to find the total 
//  number of continuous subarrays whose sum equals to k.
public static int Solution(int[] a) => throw new NotImplementedException(// Function to find minimum computation 

static int minComputation(int size, int files[])
{
	
	// create a min heap 
	PriorityQueue<Integer> pq
		= new PriorityQueue<>();

	for (int i = 0; i < size; i++)
	{

		// add sizes to priorityQueue 
		pq.add(files[i]);
	}

	// variable to count total computations 
	int count = 0;

	while (pq.size() > 1)
	{

		// pop two smallest size element 
		// from the min heap 
		int temp = pq.poll() + pq.poll();

		// add the current computations 
		// with the previous one's 
		count += temp;

		// add new combined file size 
		// to priority queue or min heap 
		pq.add(temp);
	}

	return count;
}