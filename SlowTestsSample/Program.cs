using SlowTestsSample.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.WebHost.UseKestrel();
builder.Services.AddHttpClient<SlowTestsController>();

var app = builder.Build();
app.MapControllers();
app.Run();

/// <summary>
/// Enabling public visibility for the usage in Tests.
/// </summary>
public partial class Program // NOSONAR: Move 'Program' into a named namespace.
{
}
