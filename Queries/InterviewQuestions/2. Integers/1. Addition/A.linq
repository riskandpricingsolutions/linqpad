<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<int>(8,Add(5,3));
	MyExtensions.AreEqual<int>(4,Add(5,-1));
}

// Question: Wrtie code to perform signed integer addition
public int Add(int a, int b) 
{
	int numDigits = (sizeof(int) * 4)-1;
	
	int carry=0;
	int result = 0;
	
	for(int i=0; i < numDigits; i++)
	{
		int ai = (a >> i) & 1;
		int bi = (b >> i) & 1;
		
		// ri is a 1 if one or three of the 
		// variables {ai,bi, carry} is a 1 otherwise
		// it is a zero. We use XOR 
		int ri = ai ^ bi ^ carry;
		
		// the carry if any two of the three input are 1
		carry = (carry & ai) | (carry & bi) | (ai & bi);
		
		// Shift ri into position i and add to result
		result |= (ri << i);
	}
	
	return result;
}