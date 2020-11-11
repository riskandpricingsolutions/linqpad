<Query Kind="Statements">
  <NuGetReference>Microsoft.IdentityModel.Tokens</NuGetReference>
  <NuGetReference>System.IdentityModel.Tokens.Jwt</NuGetReference>
  <NuGetReference>System.Security.Cryptography.X509Certificates</NuGetReference>
  <Namespace>Microsoft.IdentityModel.Tokens</Namespace>
  <Namespace>System.Security</Namespace>
  <Namespace>System.Security.Claims</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.IdentityModel.Tokens.Jwt</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

// Load the X509 certificate and extract is public and private keys. 
X509Certificate2 certificate = new X509Certificate2(
	fileName:@"C:\Users\rps\WebSec\PubPrivateCert.pfx",
	password:"Passw0rd");

RSA rsaPublicKey = certificate.GetRSAPublicKey();
RSA rsaPrivateKey = certificate.GetRSAPrivateKey();

// Take a piece of data that we want to sign and convert it 
// to a byte array
string message = "Hello World";
byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);

// Encrupt the message bytes using the public key
byte[] encryptedBytes = rsaPublicKey.Encrypt(messageBytes,RSAEncryptionPadding.Pkcs1);

// Try and look at the encrypted bytes and we get garbage.		
string resBytes = System.Text.Encoding.UTF8.GetString(encryptedBytes);

// Now decrypt the encripted bytes using the private key
byte[] decryptedBytes = rsaPrivateKey.Decrypt(encryptedBytes,RSAEncryptionPadding.Pkcs1);
string resBytes2 = System.Text.Encoding.UTF8.GetString(decryptedBytes);