<Query Kind="Program" />

void Main()
{
	GetPrimes(11);
}

// Calculate the first 1000 prime numbers

public List<int> GetPrimes(int N)
{
	BitArray isPrime = new BitArray(N+1,true);
	isPrime[0] = false;
	isPrime[1] = false;

	for (int p = 2; p * p <= N; p++)
	{
		// If p is not prime we have already
		// dealt with multiples of it 
		if (isPrime[p] == true)
		{
			// Update all multiples of p 
			for (int i = p * p; i <= N; i += p)
				isPrime.Set(i, false);
		}
	}
	
	List<int> primes = new List<int>();
	for (int i = 2; i < isPrime.Length; i++)
	{
		if (isPrime.Get(i)) primes.Add(i);
	}
	return primes;
}

