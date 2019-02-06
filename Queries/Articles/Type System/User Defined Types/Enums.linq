<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

[Flags]
public enum Location { None = 0, Left = 1, Right = 2, Top = 4, Bottom = 8 }

void Main()
{
	Location vertical = Location.Top | Location.Bottom;
	Location horizontal = Location.Left| Location.Right;
	
	// Because we use the Flags attribute this give us "Top, Bottom"
	// Without the Flags enum we would get the integer 12
	WriteLine(vertical);

	// Both output true
	WriteLine((Location.Top & vertical) != 0);
	WriteLine((Location.Bottom & vertical) != 0);
	
	WriteLine(vertical ^ Location.Top);
	WriteLine(horizontal ^ Location.Left);
}

