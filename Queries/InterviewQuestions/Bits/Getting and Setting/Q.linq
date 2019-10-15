<Query Kind="Program" />

void Main()
{
	Convert.ToString(5,2).Dump();
	
	// GetBit
	MyExtensions.AreEqual<bool>(true,GetBit(5,2));
	MyExtensions.AreEqual<bool>(false,GetBit(5,1));

	// SetBit
	MyExtensions.AreEqual<int>(7, SetBit(3, 2));
	
	// ClearBit
	MyExtensions.AreEqual<int>(5, ClearBit(7, 1));

	// ClearFromMsbToI
	MyExtensions.AreEqual<int>(15, ClearFromMsbToI(-1, 5));

	// SetFromMsbToI
	MyExtensions.AreEqual<int>(-4, SetFromMsbToI(0, 2));

	// ClearFromLsbToI
	MyExtensions.AreEqual<int>(-4, ClearFromLsbToI(-1, 2));

	// SetFromLsbToI
	MyExtensions.AreEqual<int>(15, SetFromLsbToI(0, 4));

}
// Question: Return true or false reflecting whether or not
// --------- bit i is set to 0 or 1
public bool GetBit(int n, int i) => throw new NotImplementedException();


// Question: Set bit i to 1
// --------- 
public int SetBit(int n, int i) => throw new NotImplementedException();


// Question: Clear bit i to 0
// --------- 
public int ClearBit(int n, int i)
{
	throw new NotImplementedException();
}

// Question: Clear all bits from the msb to the bit in 
// --------- in index i inclusive
public int ClearFromMsbToI(int n, int i)
{
	throw new NotImplementedException();
}

// Question: Set all bits from the msb to the bit 
// --------- in index i inclusive
public int SetFromMsbToI(int n, int i)
{
	throw new NotImplementedException();
}

// Question: Clear all bits from the lsb to the bit in 
// --------- in index i inclusive
public int ClearFromLsbToI(int n, int i)
{
	throw new NotImplementedException();
}

// Question: Set all bits from the lsb to the bit 
// --------- in index i inclusive
public int SetFromLsbToI(int n, int i)
{
	throw new NotImplementedException();
}