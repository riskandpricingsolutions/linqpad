<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

// When dealing with Strings we need to understand the difference between 
// ordinality and culture. Ordinal algorithms are simply based on 
// the unicode numeric values of the characters. Unicode has all the 
// uppercase english characters before all the lowercase english chars
// as per the old ASCII standard. 

// On each machine we have two cultures. The local culture and the invariant
// culture. The invariant culture is similar to American culture. Even though 
// the invariant culture is based on the american character set it is not 
// exactly the same. Unlike ASCII the invariant culture has the uppercase and
// lowercase values next to each other

// String.Equals support all options of StringComparison enum
WriteLine($"{string.Equals("animal", "Animal", StringComparison.Ordinal)}");
WriteLine($"{string.Equals("animal", "Animal", StringComparison.OrdinalIgnoreCase)}");
WriteLine($"{string.Equals("animal", "Animal", StringComparison.InvariantCulture)}");
WriteLine($"{string.Equals("animal", "Animal", StringComparison.InvariantCultureIgnoreCase)}");
WriteLine($"{string.Equals("animal", "Animal", StringComparison.CurrentCulture)}");
WriteLine($"{string.Equals("animal", "Animal", StringComparison.CurrentCultureIgnoreCase)}");

// Similarly for the instance method
WriteLine($"{"animal".Equals("Animal", StringComparison.Ordinal)}");
WriteLine($"{"animal".Equals("Animal", StringComparison.OrdinalIgnoreCase)}");
WriteLine($"{"animal".Equals("Animal", StringComparison.InvariantCulture)}");
WriteLine($"{"animal".Equals("Animal", StringComparison.InvariantCultureIgnoreCase)}");
WriteLine($"{"animal".Equals("Animal", StringComparison.CurrentCulture)}");
WriteLine($"{"animal".Equals("Animal", StringComparison.CurrentCultureIgnoreCase)}");

// == operator performs ordinal case sensitive comparison
WriteLine( "animal" == "Animal" );


// The ordinal value of 'a' is 97 and 'B' is 65 so the result is +31
WriteLine($"String.CompareOrdinal(\"animal\",\"bear\") = {String.CompareOrdinal("animal", "Bear")}");
WriteLine($"String.Compare(\"animal\",\"bear\", StringComparison.Ordinal) = {String.Compare("animal", "Bear", StringComparison.Ordinal)}");

// The ordinal value of 'a' is 97 and 'b' is 98 so the result is -1
WriteLine($"String.CompareOrdinal(\"animal\",\"bear\") = {String.CompareOrdinal("animal", "bear")}");

// Using the invariant culture we have something like aAbB
WriteLine($"String.Compare(\"animal\",\"Bear\") = {String.Compare("animal", "Bear")}");
WriteLine($"String.Compare(\"animal\",\"Animal\") = {String.Compare("animal", "Animal")}");
