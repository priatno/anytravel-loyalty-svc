using AnyTravel.LoyaltyService.Models;

namespace AnyTravel.LoyaltyService.Repositories;

public interface ILoyaltyRepository
{
    Task<LoyaltyAccount?> GetAccountAsync(string customerId);
    Task<LoyaltyAccount> AddPointsAsync(string customerId, int points);
}
