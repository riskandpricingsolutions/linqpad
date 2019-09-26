<Query Kind="Statements" />

int[] s = new[] {2,3,4};

// 27 rather than 29
s.Aggregate ((x, y) => x+y*y).Dump();

// Fix with seed
s.Aggregate (0,(x, y) => x+y*y).Dump();

// For parallelisation we often specify a separate function
// for combining intermediate results. This function must be
// assocaite and commutative
s.AsParallel().Aggregate (()=>0,(a,e) => a+e*e,(a1,a2) => a1+a2,a=>a).Dump();