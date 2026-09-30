using Microsoft.AspNetCore.Identity;

namespace SupermarketCatalog.Models;

public class StoreUser : IdentityUser
{
    public string StoreName { get; set; } = "";
    public string? LogoUrl { get; set; }
    public string? Description { get; set; }
    public DateTime SubscriptionExpiry { get; set; }
    public string SubscriptionPlan { get; set; } = "free";
    public int MonthlyDealLimit { get; set; } = 5;
    public int ActiveDealsCount { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}