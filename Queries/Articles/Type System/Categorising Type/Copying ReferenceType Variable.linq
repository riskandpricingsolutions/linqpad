<Query Kind="Program" />

void Main()
{
	CopyingReferenceStackVariabes()
}

public void CopyingReferenceStackVariabes()
{
	MyType x = new MyType();
	MyType y = x;
}

class MyType
{
	private uint _val = 1;
}