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
	fileName: @"C:\Users\rps\WebSec\PubPrivateCert.pfx",
	password: "Passw0rd");

RSA rsaPublicKey = certificate.GetRSAPublicKey();
RSA rsaPrivateKey = certificate.GetRSAPrivateKey();

// Take a piece of data that we want to sign and convert it 
// to a byte array
string message = "Hello World";
byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);

// Sign the message bytes using the private key
byte[] signedMessageBytes = rsaPrivateKey.SignData(
	messageBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

// Verify the message bytes using the signed bytes.
// and the public key
// As the messageBytes are untampered
bool result = rsaPublicKey.VerifyData(
	messageBytes,
	signedMessageBytes,
	HashAlgorithmName.SHA256,
	RSASignaturePadding.Pkcs1);

// Tamper with the bytes
messageBytes[0] = 45;

// Now the verification will fail
bool result2 = rsaPublicKey.VerifyData(
	messageBytes,
	signedMessageBytes,
	HashAlgorithmName.SHA256,
	RSASignaturePadding.Pkcs1);