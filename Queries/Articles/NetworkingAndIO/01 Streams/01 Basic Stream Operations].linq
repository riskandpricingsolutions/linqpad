<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

byte[] backingStore = new byte[] {1,2,3,4,5,6};

Stream s = new MemoryStream(backingStore);

WriteLine($"Length {s.Length}");
WriteLine($"Position {s.Position}");

// The old school way to read the entire contents of a stream into a byte[] which
// we assume is of sufficient size
byte[] destination = new byte[100];

// Keep track of how many bytes we have read
int bytesReadOnLastRead=-1;
int totalBytesRead = 0;

// Break when either the totalBytesRead equals the length 
// of the destination array or the streams Read method returns
// 0 indicating there are no more bytes on the stream
while ( totalBytesRead < destination.Length && bytesReadOnLastRead !=0)
{
	bytesReadOnLastRead = 
	 s.Read(destination,totalBytesRead,destination.Length-totalBytesRead);
	totalBytesRead += bytesReadOnLastRead;
}

destination.Dump();