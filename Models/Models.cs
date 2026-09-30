namespace SupermarketCatalog.Models;

using Microsoft.AspNetCore.Identity;

public class Deal
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string TitleAr { get; set; } = "";
    public string TitleEn { get; set; } = "";
    public string Description { get; set; } = "";
    public string DescriptionAr { get; set; } = "";
    public string DescriptionEn { get; set; } = "";
    
    public decimal Price { get; set; }
    public decimal OldPrice { get; set; }
    public decimal Discount { get; set; }
    
    public string? ImageUrl { get; set; }
    public string? Category { get; set; }
    public string? CategoryAr { get; set; }
    
    public int StoreId { get; set; }
    public Store? Store { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }
    
    public int Quantity { get; set; } = 0
    public bool IsActive { get; set; } = true;
    
    public List<UserBookmark> Bookmarks { get; set; } = [];
    
    public string GetTitle(string lang) => lang switch
    {
        "en" => TitleEn,
        "ar" => TitleAr,
        _ => Title
    };
    
    public string GetDescription(string lang) => lang switch
    {
        "en" => DescriptionEn,
        "ar" => DescriptionAr,
        _ => Description
    };
    
    public string GetCategory(string lang) => lang switch
    {
        "en" => Category ?? "",
        "ar" => CategoryAr ?? "",
        _ => Category ?? ""
    };
}

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string NameAr { get; set; } = "";
    public string NameEn { get; set; } = "";
    
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string WhatsAppNumber { get; set; } = "";
    
    public string? LogoUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? Description { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    
    public string? Address { get; set; }
    public string? AddressAr { get; set; }
    
    public string? Website { get; set; }
    public string? FacebookUrl { get; set; }
    public string? InstagramUrl { get; set; }
    
    public double? Rating { get; set; } = 0;
    public int ReviewCount { get; set; } = 0;
    
    public bool IsVerified { get; set; } = false;
    public bool IsActive { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public string? OwnerId { get; set; }
    public StoreUser? Owner { get; set; }
    
    public List<Deal> Deals { get; set; } = [];
    public List<StoreReview> Reviews { get; set; } = [];
    
    public string GetName(string lang) => lang switch
    {
        "en" => NameEn,
        "ar" => NameAr,
        _ => Name
    };
    
    public string GetDescription(string lang) => lang switch
    {
        "en" => DescriptionEn ?? "",
        "ar" => DescriptionAr ?? "",
        _ => Description ?? ""
    };
}

public class StoreReview
{
    public int Id { get; set; }
    public int StoreId { get; set; }
    public Store? Store { get; set; }
    
    public string UserId { get; set; } = "";
    public StoreUser? User { get; set; }
    
    public int Rating { get; set; }
    public string Comment { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class UserBookmark
{
    public int Id { get; set; }
    public int DealId { get; set; }
    public Deal? Deal { get; set; }
    
    public string UserId { get; set; } = "";
    public StoreUser? User { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class StoreUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfileImageUrl { get; set; }
    
    public int? StoreId { get; set; }
    public Store? Store { get; set; }
    
    public bool IsStoreOwner { get; set; } = false;
    public bool IsAdmin { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public List<UserBookmark> Bookmarks { get; set; } = [];
    public List<StoreReview> Reviews { get; set; } = [];
    
    public string GetFullName() => $"{FirstName} {LastName}".Trim();
}
