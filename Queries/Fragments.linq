<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	int res = SubArraySum(new[] { 1, 1, 1},2);
}

public int SubArraySum(int[] nums, int k)
{
	int count = 0;
	for (int start = 0; start < nums.Length; start++)
	{
		for( int end = start+1; end <= nums.Length; end++)
		{
			int sum = 0;
			for(int i=start; i <end;i++)
			{
				sum+= nums[i];
			}
			
			if (sum == k)
				count++;
		}
	}
	
	return count;
}
