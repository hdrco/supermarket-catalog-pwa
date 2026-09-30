using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages;

public class IndexModel(AppDbContext db) : PageModel
{
    public List<Deal> Deals { get; set; } = [];

    public string Lang => Request.Query["lang"].FirstOrDefault() ?? Request.Cookies["lang"] ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";

    public async Task OnGetAsync()
    {
        Deals = await db.Deals
            .Include(x => x.Store)
            .Where(x => x.ExpiresAt > DateTime.UtcNow)
            .OrderByDescending(x => x.Discount)
            .Take(12)
            .ToListAsync();
    }

    public string Title(Deal deal) => Lang switch
    {
        "en" => string.IsNullOrWhiteSpace(deal.TitleEn) ? deal.Title : deal.TitleEn,
        "ar" => string.IsNullOrWhiteSpace(deal.TitleAr) ? deal.Title : deal.TitleAr,
        _ => string.IsNullOrWhiteSpace(deal.Title) ? deal.TitleEn : deal.Title
    };
}
