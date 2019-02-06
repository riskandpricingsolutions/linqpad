<Query Kind="Program" />

void Main()
{
	SimpleStruct ss;
	ss.X = 5;

	object so = ss;

	ss.X = 4;
	uint val = ss.X;

	((SimpleStruct)so).SetValue(3);
	val = ((SimpleStruct)so).X;

	((ISet)so).SetValue(3);
	val = ((SimpleStruct)so).X;
}

public interface ISet
{
	void SetValue(uint val_);
}

public struct SimpleStruct : ISet
{
	public uint X;

	public void SetValue(uint val_)
	{
		X = val_;
	}
}