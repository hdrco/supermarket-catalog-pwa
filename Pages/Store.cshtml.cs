using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;
namespace SupermarketCatalog.Pages;
public class StoreModel(AppDbContext db) : PageModel
{
    public Store? Store { get; set; }
    public List<Deal> Deals { get; set; } = [];
    public string Lang => Request.Query["lang"].FirstOrDefault() ?? Request.Cookies["lang"].FirstOrDefault() ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";
    public async Task OnGetAsync(int id)
    {
        Store = await db.Stores.FindAsync(id);
        if (Store is not null) Deals = await db.Deals.Where(x => x.StoreId == id && x.ExpiresAt > DateTime.UtcNow).OrderByDescending(x => x.Discount).ToListAsync();
    }
}