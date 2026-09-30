using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Data;

public class AppDbContext : IdentityDbContext<StoreUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Deal> Deals => Set<Deal>();
    public DbSet<Store> Stores => Set<Store>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Deal>().HasIndex(x => x.ExpiresAt);
        builder.Entity<Deal>().HasIndex(x => x.StoreId);
    }
}

public static class Seed
{
    public static void Data(AppDbContext db)
    {
        if (db.Stores.Any()) return;

        var store = new Store
        {
            Name = "بازار تخفیف",
            NameAr = "سوق الخصومات",
            NameEn = "Discount Market",
            Email = "demo@example.com"
        };

        db.Stores.Add(store);
        db.SaveChanges();

        db.Deals.AddRange(
            new Deal
            {
                Title = "سیب تازه",
                TitleAr = "تفاح طازج",
                TitleEn = "Fresh Apples",
                Price = 12500,
                OldPrice = 25000,
                Discount = 50,
                ImageUrl = "https://images.unsplash.com/photo-1560806887-1e4cd0b6cbd6?w=800",
                StoreId = store.Id,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            },
            new Deal
            {
                Title = "شیر پرچرب",
                TitleAr = "حليب كامل الدسم",
                TitleEn = "Full-fat Milk",
                Price = 13500,
                OldPrice = 18000,
                Discount = 25,
                ImageUrl = "https://images.unsplash.com/photo-1563636619-e9143da7973b?w=800",
                StoreId = store.Id,
                ExpiresAt = DateTime.UtcNow.AddDays(5)
            },
            new Deal
            {
                Title = "مرغ تازه",
                TitleAr = "دجاج طازج",
                TitleEn = "Fresh Chicken",
                Price = 59500,
                OldPrice = 85000,
                Discount = 30,
                ImageUrl = "https://images.unsplash.com/photo-1604503468506-a8da13d82791?w=800",
                StoreId = store.Id,
                ExpiresAt = DateTime.UtcNow.AddDays(3)
            }
        );

        db.SaveChanges();
    }
}