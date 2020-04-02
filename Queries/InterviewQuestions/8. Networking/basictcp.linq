<Query Kind="Program">
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

void Main()
{
	new Thread(TcpServer).Start();       // Run server method concurrently.
	Thread.Sleep(500);                // Give server time to start.
	Client();
}


static void Client()
{
	using (TcpClient client = new TcpClient("localhost", 13000) )
	{
		using (NetworkStream n = client.GetStream())
		{
			string msg = "hello";
			BinaryWriter w = new BinaryWriter(n);
			Console.WriteLine($"Client Sending: {msg}");
			w.Write(msg);
			w.Flush();
			
			Console.WriteLine($"Client Received: {new BinaryReader(n).ReadString()}");
		}
	}
}

static void TcpServer()
{
	TcpListener listener = new TcpListener(IPAddress.Any, 13000);
	listener.Start();

	while (true)
	{
		Console.WriteLine("Wating for a connection");
		
		using (TcpClient c = listener.AcceptTcpClient())
		{
			using NetworkStream n = c.GetStream();
			string msg = new BinaryReader(n).ReadString();
			
			Console.WriteLine($"Server Received: {msg}");
			
			BinaryWriter w = new BinaryWriter(n);
			Console.WriteLine($"Server Writing: {msg} world");
			w.Write(msg + " world");
			w.Flush(); 
		}
	}
}