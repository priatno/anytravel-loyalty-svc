using AnyTravel.LoyaltyService.Repositories;
using Xunit;

namespace AnyTravel.LoyaltyService.Tests;

public class InMemoryLoyaltyRepositoryTests
{
    [Fact]
    public async Task AddPoints_AccumulatesBalanceForSameCustomer()
    {
        var repo = new InMemoryLoyaltyRepository();

        await repo.AddPointsAsync("cust-1", 100);
        var result = await repo.AddPointsAsync("cust-1", 50);

        Assert.Equal(150, result.PointsBalance);
    }

    [Fact]
    public async Task GetAccount_UnknownCustomer_ReturnsZeroBalance()
    {
        var repo = new InMemoryLoyaltyRepository();

        var result = await repo.GetAccountAsync("never-seen");

        Assert.NotNull(result);
        Assert.Equal(0, result!.PointsBalance);
    }
}
