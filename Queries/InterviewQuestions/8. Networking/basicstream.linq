<Query Kind="Statements">
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.IO.Compression</Namespace>
</Query>

// A buffer for the memory stream. Streams
// only work on the level of bytes 
var buffer = new byte[16];

using (Stream s = new MemoryStream(buffer))
{
	// We want to write two char to a stream. We first
	// need to use an encoding to convert the chars
	// to bytes
	char[] ab = { 'a', 'b' };
	byte[] encodedBytes = Encoding.UTF8.GetBytes(ab);
	s.Write(encodedBytes, 0, encodedBytes.Length);

	// On the other side we use the encoding convert
	// the raw bytes back to characters. 
	s.Position = 0;
	byte[] destBytes = new byte[256];
	s.Read(destBytes, 0, encodedBytes.Length);
	char[] destChars = Encoding.UTF8.GetChars(destBytes, 0, encodedBytes.Length);
}

  