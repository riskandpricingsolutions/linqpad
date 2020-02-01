<Query Kind="Program" />

void Main()
{
	
}


public class Trie<TV> 
{
	private static int radix = 128;
	private Node<TV> root;
	
	private Node<TV> Get(Node<TV> x, String key, int d)
	{
		if (x== null) return null;
		
		if (d==key.Length) return x;
		
		return Get(x.next[key[d]],key,d+1)
	}
	
	public TV Get(String key)
	{
		Node<TV> x = Get(root, key,0);
		if  (x==null) throw new ArgumentException();
		return x.value;
	}
	
	private Node<TV> Put(Node<TV> x, string key, TV value, int d)
	{
		if (x==null) x = new Node<TV>();
		if (d==key.Length)
		{
			x.value = value;
			return x;
		}
		
		x.next[key[d]] = Put(x.next[key[d]],key,value,d+1);
		return x;
	}
	
	public void Put(string key, TV value) => root = Put(root,key,value,0)
}

public class Node<TV>
{
	public TV value;
	public Node<TV>[] next = new Node<TV>[128];
}

