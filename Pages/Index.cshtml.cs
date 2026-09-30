using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages;

public class IndexModel(AppDbContext db) : PageModel
{
    public List<Deal> Deals { get; set; } = [];
    public List<Store> Stores { get; set; } = [];

    public string Lang => Request.Query["lang"].FirstOrDefault() ?? Request.Cookies["lang"] ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";

    public async Task OnGetAsync()
    {
        Deals = await db.Deals
            .Include(x => x.Store)
            .Where(x => x.ExpiresAt > DateTime.UtcNow && x.IsActive)
            .OrderByDescending(x => x.Discount)
            .Take(8)
            .ToListAsync();

        Stores = await db.Stores
            .Include(x => x.Deals)
            .Where(x => x.IsActive)
            .OrderByDescending(x => x.Rating)
            .Take(6)
            .ToListAsync();
    }

    public string GetDealTitle(Deal deal) => deal.GetTitle(Lang);
    public string GetStoreName(Store? store) => store == null ? "" : store.GetName(Lang);
    public string GetLanguageHref(string lang) => $"/?lang={lang}";
}
