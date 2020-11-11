<Query Kind="Program">
  <Namespace>Microsoft.AspNetCore.Builder</Namespace>
  <Namespace>Microsoft.AspNetCore.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Http</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	string message ="Hello";
	var webHost = new WebHostBuilder()
		.UseKestrel()
		.Configure(app =>
		{
			app.Run(async ctx =>
			{
				await ctx.Response.WriteAsync(message);
			});
		})
		.Build();

	webHost.Run();
}

// Define other methods, classes and namespaces here
