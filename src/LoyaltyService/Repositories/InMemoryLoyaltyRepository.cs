using System.Collections.Concurrent;
using AnyTravel.LoyaltyService.Models;

namespace AnyTravel.LoyaltyService.Repositories;

// Placeholder store for the workshop reference deployment. The production
// version of this service backs onto Aurora PostgreSQL — swapped out here to
// keep the demo self-contained.
public class InMemoryLoyaltyRepository : ILoyaltyRepository
{
    private readonly ConcurrentDictionary<string, int> _balances = new();

    public Task<LoyaltyAccount?> GetAccountAsync(string customerId)
    {
        var balance = _balances.GetValueOrDefault(customerId, 0);
        return Task.FromResult<LoyaltyAccount?>(new LoyaltyAccount(customerId, balance));
    }

    public Task<LoyaltyAccount> AddPointsAsync(string customerId, int points)
    {
        var newBalance = _balances.AddOrUpdate(customerId, points, (_, current) => current + points);
        return Task.FromResult(new LoyaltyAccount(customerId, newBalance));
    }
}
