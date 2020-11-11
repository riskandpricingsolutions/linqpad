<Query Kind="Program" />

void Main()
{

	int n = 4;
	int count = 0;
	int count1 = 0;
	
	for (int i = 0; i < n; i++)
	{
		for (int j = i; j <n; j++)
		{
			count1++;
			for (int k = i; k <=j;k++)
			{
				count++;
			}
		}
			
	}
	
	count1.Dump();
	count.Dump();
}

// You can define other methods, fields, classes and namespaces here
