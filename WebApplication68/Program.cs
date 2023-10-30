var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOutputCache();
var app = builder.Build();

app.UseOutputCache();

app.MapGet("/", () => "Hello World!");

// Does not work
app.MapGet("/errorwithcache", () =>
{
    throw new ArgumentException();
}).CacheOutput();

// Works as expected
app.MapGet("/errorwithoutcache", () =>
{
    throw new ArgumentException();
});

app.Run();
