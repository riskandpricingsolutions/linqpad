<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<sbyte>(0b00001000, MaskOne(3));
	MyExtensions.AreEqual<sbyte>(unchecked((sbyte)0b11110111), MaskTwo(3));
	MyExtensions.AreEqual<sbyte>(unchecked((sbyte)0b11111000), MaskThree(3));
	MyExtensions.AreEqual<sbyte>(unchecked((sbyte)0b00000111), MaskFour(3));
	MyExtensions.AreEqual<sbyte>(unchecked((sbyte)0b00111000), MaskFive(3,5));
	MyExtensions.AreEqual<sbyte>(unchecked((sbyte)0b11000111), MaskSix(3,5));
	MyExtensions.AreEqual<sbyte>(-2, Subtract(3,5));
}

// Question: 
//		Implement this function to return a mask of all
// 		zeroes except a single 1 in bit location i
public static sbyte MaskOne(int i) => (sbyte)(1 << i);

// Question: 
//		Implement this function to return a mask of all
// 		one except a single zero in bit location i
public static sbyte MaskTwo(int i) => (sbyte)(~(1 << i));

// Question: 
//		Implement this function to return a mask of all
// 		ones except for zeros in the n least significant bits
public static sbyte MaskThree(int n) => (sbyte)(~0 << n);

// Question: 
//		Implement this function to return a mask of all
// 		zeroes except for ones in the n least significant bits
public static sbyte MaskFour(int n) => (sbyte)((1 << n)-1);

// Question: 
//		Implement this function to return a mask of all
// 		0s except for digits i through j which contain 1s
public static sbyte MaskFive(int i, int j) => (sbyte)(((1 << j-i+1) - 1) << i);

// Question: 
//		Implement this function to return a mask of all
// 		1s except for digits i through j which contain 0s
public static sbyte MaskSix(int i, int j) => (sbyte)~(((1 << j - i+1) - 1) << i);

// Question: 
//		Implement integer subtraction without using the - key
public static sbyte Subtract(sbyte a, sbyte b) => (sbyte)(a + ~b +1);