using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages;

public class DealModel(AppDbContext db) : PageModel
{
    public Deal? Deal { get; set; }

    public string Lang => Request.Query["lang"].FirstOrDefault() ?? Request.Cookies["lang"] ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";

    public async Task OnGetAsync(int id)
    {
        Deal = await db.Deals
            .Include(x => x.Store)
            .FirstOrDefaultAsync(x => x.Id == id && x.ExpiresAt > DateTime.UtcNow);
    }

    public string Title() => Lang switch
    {
        "en" => string.IsNullOrWhiteSpace(Deal?.TitleEn) ? Deal?.Title ?? "" : Deal.TitleEn,
        "ar" => string.IsNullOrWhiteSpace(Deal?.TitleAr) ? Deal?.Title ?? "" : Deal.TitleAr,
        _ => string.IsNullOrWhiteSpace(Deal?.Title) ? Deal?.TitleEn ?? "" : Deal.Title
    };
}
