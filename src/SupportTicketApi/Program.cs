var builder = WebApplication.CreateBuilder(args);

// --- application services (registered as features are added) ---
// --- end application services ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();

/// <summary>Exposed so integration tests can bootstrap the real pipeline.</summary>
public partial class Program
{
}
