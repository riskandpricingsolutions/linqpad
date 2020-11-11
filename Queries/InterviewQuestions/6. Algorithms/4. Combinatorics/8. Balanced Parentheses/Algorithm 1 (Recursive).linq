<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
}

public void BalancedParentheses( string parentheseString, int opCnt, int clCnt, int n, List<string> results)
{
	if (opCnt == n && clCnt == n)
	{
		results.Add(parentheseString);
		return;
	}
	
	if (opCnt < n )
		BalancedParentheses(parentheseString + '(',opCnt+1, clCnt,n, results);
		
	if (clCnt < opCnt )
	{
		BalancedParentheses(parentheseString + ')',opCnt, clCnt+1,n, results);
	}
	
}
