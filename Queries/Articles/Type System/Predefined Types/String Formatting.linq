<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

WriteLine("hello".ToUpper());  // Hello

WriteLine("WORLD".ToLower());  // world

WriteLine(String.Join("|","Hello World".Split()));  // Hello|World


// Formatting with minimun width
WriteLine();
WriteLine($"{400.00,15:C}");
WriteLine($"{3.56,15:C}");
WriteLine($"{33.56,15:C}");

WriteLine();
WriteLine($"{11,-10} {12,-10}");
WriteLine($"{21,-10} {22,-10}");

