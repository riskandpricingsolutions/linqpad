<Query Kind="Program" />

void Main()
{

	Random rand = new Random();
	int n = rand.Next(300000) + 1;
	int missing = rand.Next(n + 1);
	List<BitInteger> array = Question.initialize(n, missing);
	Console.WriteLine("The array contains all numbers but one from 0 to " + n + ", except for " + missing);

	int result = Question.findMissing(array);
	if (result != missing)
	{
		Console.WriteLine("Error in the algorithm!\n" + "The missing number is " + missing + ", but the algorithm reported " + result);
	}
	else
	{
		Console.WriteLine("The missing number is " + result);
	}
}

public class Question
{
	/* Create a random array of numbers from 0 to n, but skip 'missing' */
	public static List<BitInteger> initialize(int n, int missing)
	{
		Random random = new Random();
		BitInteger.INTEGER_SIZE = Convert.ToString(n,2).Length;
		List<BitInteger> array = new List<BitInteger>();

		for (int i = 1; i <= n; i++)
		{
			array.Add(new BitInteger(i == missing ? 0 : i));
		}

		// Shuffle the array once.
		for (int i = 0; i < n; i++)
		{
			int rand = i + (int)(random.Next() * (n - i));
			array[i].swapValues(array[rand]);
		}

		return array;
	}


	public static int findMissing(List<BitInteger> array)
	{
		return findMissing(array, BitInteger.INTEGER_SIZE - 1);
	}

	private static int findMissing(List<BitInteger> input, int column)
	{
		if (column < 0)
		{ // Base case and error condition
			return 0;
		}
		List<BitInteger> oneBits = new List<BitInteger>(input.Count / 2);
		List<BitInteger> zeroBits = new List<BitInteger>(input.Count / 2);
		foreach (BitInteger t in input)
		{	
			if (t.fetch(column) == 0)
			{
				zeroBits.Add(t);
			}
			else
			{
				oneBits.Add(t);
			}
		}
		if (zeroBits.Count <= oneBits.Count)
		{
			int v = findMissing(zeroBits, column - 1);
			Console.WriteLine("0");
			return (v << 1) | 0;
		}
		else
		{
			int v = findMissing(oneBits, column - 1);
			Console.WriteLine("1");
			return (v << 1) | 1;
		}
	}

	public static void main(String[] args)
	{

	}
}

public class BitInteger
{
	public static int INTEGER_SIZE;
	private bool[] bits;
	public BitInteger()
	{
		bits = new bool[INTEGER_SIZE];
	}
	/* Creates a number equal to given value. Takes time proportional 
	 * to INTEGER_SIZE. */
	public BitInteger(int value)
	{
		bits = new bool[INTEGER_SIZE];
		for (int j = 0; j < INTEGER_SIZE; j++)
		{
			if (((value >> j) & 1) == 1) bits[INTEGER_SIZE - 1 - j] = true;
			else bits[INTEGER_SIZE - 1 - j] = false;
		}
	}

	/** Returns k-th most-significant bit. */
	public int fetch(int k)
	{
		if (bits[k]) return 1;
		else return 0;
	}

	/** Sets k-th most-significant bit. */
	public void set(int k, int bitValue)
	{
		if (bitValue == 0) bits[k] = false;
		else bits[k] = true;
	}

	/** Sets k-th most-significant bit. */
	public void set(int k, char bitValue)
	{
		if (bitValue == '0') bits[k] = false;
		else bits[k] = true;
	}

	/** Sets k-th most-significant bit. */
	public void set(int k, bool bitValue)
	{
		bits[k] = bitValue;
	}

	public void swapValues(BitInteger number)
	{
		for (int i = 0; i < INTEGER_SIZE; i++)
		{
			int temp = number.fetch(i);
			number.set(i, this.fetch(i));
			this.set(i, temp);
		}
	}

	public int toInt()
	{
		int number = 0;
		for (int j = INTEGER_SIZE - 1; j >= 0; j--)
		{
			number = number | fetch(j);
			if (j > 0)
			{
				number = number << 1;
			}
		}
		return number;
	}
}