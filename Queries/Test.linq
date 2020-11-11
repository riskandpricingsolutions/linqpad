<Query Kind="Program" />

void Main()
{
	var a = new[] {1,2,3};

	solution(new [] {-10,-7,-5,-1,0,10,1,2,3});
	
	
}

public int solution(int[] A)
{

	Array.Sort(A);
	int x = 1;

	int idx = 0;

	// Walk past any negative values
	while (A[idx++] <= 0) { }

	idx--;
	int firstPositiveIdx = idx;
	// We want to find the first value where 
	// A[idx] != idx-firstPositiveIdx

	while (true)
	{
		if (A[idx] != (idx - firstPositiveIdx+1))
			return A[idx-1]+1;
		idx++;
	}
}

// You can define other methods, fields, classes and namespaces here
