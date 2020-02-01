<Query Kind="Program" />

void Main()
{
	
	Graph g = new Graph(new int[] {4,5, 0,1, 1,3});
	DFS s = new DFS(g,0);
	
}

class DFS
{
	Boolean[] marked;
	public int count;
	public DFS(Graph g, int s)
	{
		marked = new bool[g.adj.Length];
		dfs(g,s);
	}
	
	public void dfs(Graph g, int v)
	{
		Console.WriteLine(v);
		marked[v]= true;
		count++;
		foreach (int w in g.adj[v])
		{
			if (!marked[w]) dfs(g,w);
		}
	}
}

class Graph{
	
	 public List<int>[] adj ;
	 public int edgeCount;
	
	public Graph(int vertexCount)
	{
		adj = new System.Collections.Generic.List<int>[vertexCount];
		for (int i = 0; i < vertexCount; i++)
			adj[i] = new System.Collections.Generic.List<int>();
	}
	
	public Graph(int[] init) : this(init[0])
	{
		edgeCount = init[1];
		
		for (int i = 2; i < init.Length; )
		{
			int v = init[i++];
			int w = init[i++];
			AddEdge(v,w);
		}
	}
	
	public void AddEdge(int v, int w)
	{
		adj[v].Add(w);
		adj[w].Add(v);
	}
}

class Node
{
	public Node(String name_) => name = name_;
	public String name;
	public IList<Node> children = new List<Node>();
}
