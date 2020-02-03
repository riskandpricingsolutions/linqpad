<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	Trie t = new Trie();
	
	t.Insert("sel");
	
	WriteLine(t.Search("hell"));
	WriteLine(t.Search(""));
	WriteLine(t.Search("sel"));
	
	WriteLine(t.StartsWith("s"));
}

class Trie
{
	private Node _root = new Node();
	
	public Trie() => _root.IsWord = true;

	
	public void Insert(string word)
	{
		Node parent = _root;
		
		for (int keyIdx = 0; keyIdx < word.Length; keyIdx++)
		{
			int childIdx = word[keyIdx] - 'a';
			Node childNode = parent.Children[childIdx];
			
			if (childNode == null)
			{
				childNode = new Node();
				parent.Children[childIdx] = childNode;
			}
			
			if (keyIdx == word.Length-1)
				childNode.IsWord = true;
				
			parent = childNode;
		}
	}

	public bool Search(string word)
	{
		Node parent = _root;

		for (int keyIdx = 0; keyIdx < word.Length; keyIdx++)
		{
			int childIdx = word[keyIdx] - 'a';
			Node childNode = parent.Children[childIdx];
			
			if (childNode == null) return false;
			else parent = childNode;
		}
		
		return parent.IsWord;
	}

	public bool StartsWith(string word)
	{
		Node parent = _root;

		for (int keyIdx = 0; keyIdx < word.Length; keyIdx++)
		{
			int childIdx = word[keyIdx] - 'a';
			Node childNode = parent.Children[childIdx];

			if (childNode == null) return false;
			else parent = childNode;
		}

		return parent != null;
	}


}

class Node
{
	public Node[] Children = new Node[26];
	public bool IsWord = false;
}