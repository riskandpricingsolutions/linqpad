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

// Load the X509 certificate that contains both the public and private keys,
// protected by password
X509Certificate2 certificate = new X509Certificate2(
	fileName:@"C:\Users\rps\WebSec\PubPrivateCert.pfx",
	password:"Passw0rd");

// Load the certificate that only has a public key
X509Certificate2 publicCertificate = new X509Certificate2(
fileName: @"C:\Users\rps\WebSec\Public.crt");


// Create a key from the public/private certificate
// and use it to create some signing credentials
X509SecurityKey privateKey = new X509SecurityKey(certificate);
SigningCredentials signingCredentials = 
	new SigningCredentials(privateKey,SecurityAlgorithms.RsaSha256);

// Create a set of claims.
var claims = new List<Claim>()
{
	new Claim("application", "one"),
	new Claim("application", "two")
};

// Create a token that signs the claims
JwtSecurityToken token = new JwtSecurityToken(
	issuer: "RandomIssuer",
	audience: "RandomAudience",
	expires: DateTime.Now.AddDays(1),
	signingCredentials: signingCredentials,
	claims: claims);

// Create a token handler and use it to create a token string
 	var securityTokenHandler = new JwtSecurityTokenHandler();
string tokenString =securityTokenHandler.WriteToken(token);
tokenString.Dump();

// Two validate the token we just need the public certificate
var validationKey = new X509SecurityKey(publicCertificate);

// The validation parameters
var tokenValidationParameters = new TokenValidationParameters
{
	ValidateIssuer = true,
	ValidateAudience = true,
	ValidAudience = "RandomAudience",
	ValidIssuer = "RandomIssuer",
	IssuerSigningKey = validationKey,
	ValidateLifetime = true,
	ClockSkew = TimeSpan.FromSeconds(30)
};

// Validate the claim and get back the claims
var claimsPrinciple = securityTokenHandler.ValidateToken(
	tokenString,
	tokenValidationParameters,
	out SecurityToken outToken);	
	
outToken.Dump();

// Tamper with the token throws exception
tokenString = tokenString + "more";
var claimsPrinciple2 = securityTokenHandler.ValidateToken(
	tokenString,
	tokenValidationParameters, 
	out SecurityToken outToken2);