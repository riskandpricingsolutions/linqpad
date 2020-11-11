<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
	var r = ChangeCase("A1d".ToCharArray());
	r.Dump();
}

public List<char[]> ChangeCase( char[] inputString)
{
	List<char[]> temp = new List<char[]>();
	temp.Add(inputString);
	
	for (int i = 0; i < inputString.Length; i++)
	{
		char c = inputString[i];
		int tempCount = temp.Count;
		
		if (char.IsDigit(c)) continue;
		
		for (int j = 0; j < tempCount; j++)
		{
			var s = temp[j];
			var n1 = (char[])s.Clone();
			var n2 = (char[])s.Clone();
			n1[i] = Char.ToUpper(c);
			n2[i] = Char.ToLower(c);
			temp.Add(n1);
			temp.Add(n2);
		}
		temp.RemoveRange(0,tempCount);
	}
	
	return temp;
}
