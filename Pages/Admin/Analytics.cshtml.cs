using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketCatalog.Data;

namespace SupermarketCatalog.Pages.Admin;

public class AnalyticsModel(AppDbContext db) : PageModel
{
    public int DealCount { get; set; }

    public void OnGet()
    {
        DealCount = db.Deals.Count();
    }
}