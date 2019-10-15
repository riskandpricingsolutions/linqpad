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

// Question: Fill in the following to deal with change of base of floating point.
//			E.g ChangeOfBase("3.5",10,2) = "11.1"
public string ChangeBase(string input, int sourceBase, int targetBase)
{
	throw new NotImplementedException();
}
