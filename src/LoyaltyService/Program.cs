using AnyTravel.LoyaltyService.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILoyaltyRepository, InMemoryLoyaltyRepository>();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/api/loyalty/{customerId}", async (string customerId, ILoyaltyRepository repo) =>
{
    var account = await repo.GetAccountAsync(customerId);
    return Results.Ok(account);
});

app.MapPost("/api/loyalty/{customerId}/points", async (string customerId, int points, ILoyaltyRepository repo) =>
{
    if (points <= 0)
    {
        return Results.BadRequest(new { message = "points must be positive" });
    }

    var account = await repo.AddPointsAsync(customerId, points);
    return Results.Ok(account);
});

app.Run();

public partial class Program { }
