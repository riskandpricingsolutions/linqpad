<Query Kind="Program" />

void Main()
{
	Span<int> numbers = stackalloc int[5];
	for (int i = 0; i < numbers.Length; i++) numbers[i] = i;
		
	DoubleSpan(numbers);
	
	// 0,2,4,6,7,10
	numbers.Dump();
}

public void DoubleSpan(Span<int> s)
{
	for (int i = 0; i < s.Length; i++)
		s[i] *= 2;
}

// You can define other methods, fields, classes and namespaces here
