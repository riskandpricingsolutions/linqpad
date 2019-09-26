<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// Initialize a 3x2 array. That is to say it has
	// Three columns and two rows.
	int[,] threeByTwo = new int[3, 2]
	{
		{1,2},
		{3,4},
		{5,6}
	};

	int a32 = threeByTwo[2, 1];

	// If we define our matrix like this we need to do a bit
	// of mental gymnastics to think of it as a x,y co-ordinates
	double[,] matrix = new double[3, 3]
	{
		{1.0,4.0,7.0},
		{2.0,5.0,8.0},
		{3.0,6.0,9.0}
	};

	var p00 = matrix[0, 0];
	var p30 = matrix[2, 0];
	
	double[,] result = new double[3, 3];
	
	for(int x =0; x < 3; x++)
	{
		for (int y = 0; y < 3; y++)
		{
			double rad = 90 * Math.PI/180.0;
			double cosRad = Math.Cos(rad);
			double sinRad = Math.Sin(rad);
			
			double xp = Math.Round(((double)x * cosRad)-((double)y*sinRad));
			double yp = Math.Round(((double)x * sinRad)+((double)y*cosRad));
			
			WriteLine($"({x},{y}) = ({xp},{yp}) ");
		}
		
		
	}
	
	
}

// Define other methods and classes here