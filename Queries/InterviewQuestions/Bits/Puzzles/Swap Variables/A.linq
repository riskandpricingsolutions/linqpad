<Query Kind="Program" />

void Main()
{
	int a = 3;
	int b = -5;
	Swap(ref a, ref b);
	MyExtensions.AreEqual(3,b);
	MyExtensions.AreEqual(-5,a);	
}

// Question: Write code to swap to variables without using a third variable
// -------- 
public void Swap(ref int a, ref int b) 
{
	if (a == b) return ; // Special case
	
	a = a ^ b;
	b = a ^ b;
	a = a ^ b;
}
