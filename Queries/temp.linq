<Query Kind="Program">
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

void Main()
{
	// Load the X509 certificate and extract is public and private keys. 
	X509Certificate2 certificate = new X509Certificate2(
		fileName:@"C:\Users\rps\WebSec\RootCAWithPrivate.pfx",
		password:"Lovely");
	
	RSA rsaPublicKey = certificate.GetRSAPublicKey();
	RSA rsaPrivateKey = certificate.GetRSAPrivateKey();
	
	// Take a piece of data that we want to sign and convert it 
	// to a byte array
	string message = "Hello World";
	byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
	
	// Sign the message bytes
	byte[] signedMessageBytes = rsaPrivateKey.SignData(
		messageBytes,HashAlgorithmName.SHA256,RSASignaturePadding.Pkcs1);
	
	// Verify the message bytes using the signed bytes.
	// As the messageBytes are untam
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
	
	signedMessageBytes.Dump();
	
	
	
	
	
	
	// Asymmetric security key backed by X509Certificate2
	//X509SecurityKey key = new X509SecurityKey(certificate);
	//
	////Defines the SecurityKey, algorithm and digest for digital signatures.
	//SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.RsaSha256Signature);
	//
	//List<Claim> claims = new List<System.Security.Claims.Claim>
	//{
	//	new Claim("App","HelloWorld")
	//};
	//
	
	
	//JwtSecurityToken token = new JwtSecurityToken(
	//	"SomeIssuer",
	//	"SomeAudience",
	//	claims:claims,
	//	expires:DateTime.Now.AddDays(1),
	//	signingCredentials:credentials);
		
	//string tokenStirng = new JwtSecurityTokenHandler().WriteToken(token);
	//	
	//tokenStirng.Dump();
	
}

// Define other methods, classes and namespaces here
