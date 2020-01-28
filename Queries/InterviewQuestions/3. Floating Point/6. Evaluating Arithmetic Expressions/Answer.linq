<Query Kind="Program" />

void Main()
{
	double a = Evaluate("( ( 3 + 4 ) * 10 )");
}

// Question: Write code to proces arithmetic expressions

public static string[] operators = new string[]{"+","-", "*", "/"};

public double Evaluate(string expression)
{
	Stack<double> values = new Stack<double>();
	Stack<string> ops = new Stack<string>();
	
	string[] tokens = expression.Split(' ');
	
	foreach (var token in tokens)
	{
		if (operators.Contains(token))
			ops.Push(token);
		else if (token.Equals(")"))
		{
			double arg1 = values.Pop();
			double arg2 = values.Pop();
			
			switch(ops.Pop())
			{
				case "+": 
					values.Push(arg1+arg2);
					break;
				case "-":
					values.Push(arg1 - arg2);
					break;
				case "*":
					values.Push(arg1 * arg2);
					break;
				case "/":
					values.Push(arg1 / arg2);
					break;
			}
		}
		else if (token.Equals("("))
		{
			// Do Nothing
		}
		else
		{
			values.Push(double.Parse(token));
		}
	}
	
	return values.Pop();
}
