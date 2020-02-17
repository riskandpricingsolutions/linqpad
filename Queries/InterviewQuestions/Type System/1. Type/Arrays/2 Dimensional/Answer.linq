<Query Kind="Program" />

void Main()
{
	char[] x = new char[] {'A','B','C','B','D','A','B'};
	char[] y = new char[] {'B','D','C','A','B','A'};
	c(x,y,x.Length-1, y.Length-1).Dump();
	
}

// Define other methods and classes here
public int c(char[] x, char[] y, int i, int j)
{
	if (i<0 || j<0) return 0;
	
	if (x[i] == y[j]) return c(x,y,i-1,j-1)+1;
	
	return Math.Max(c(x,y,i,j-1),c(x,y,i-1,j));
}