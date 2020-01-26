<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual("345.0",ChangeBase("345.0",10,10));
	MyExtensions.AreEqual("11111.0",ChangeBase("31.0",10,2));
	MyExtensions.AreEqual("ff.0",ChangeBase("255.0",10,16));
	MyExtensions.AreEqual("345.45",ChangeBase("345.45",10,10));
	MyExtensions.AreEqual("345.45",ChangeBase("345.45",10,10));
	MyExtensions.AreEqual("0.1",ChangeBase("0.5",10,2));
	MyExtensions.AreEqual("0.5",ChangeBase("0.1",2,10));
}

// Question: Write Parse Float
public double ParseFloat(string s)
{
	var parts = input.Split('.');
	var integralPart = ConvertIntegralPart(parts[0], sourceBase, targetBase);
	var fractionalPart = ConvertFractionalPart(parts[1], sourceBase, targetBase);
}
