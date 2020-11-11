<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>


// Last Element 
WriteLine(new [] {1,2,3}[^1]);

// Second last element
WriteLine(new [] {1,2,3}[^2]);

// First two elements
WriteLine(new [] {1,2,3}[..2]);

// [2,3]
WriteLine(new [] {1,2,3}[1..3]);

// Last two elements
WriteLine(new [] {1,2,3}[^2..]);