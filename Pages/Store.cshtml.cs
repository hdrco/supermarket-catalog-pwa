using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages;

public class StoreModel(AppDbContext db) : PageModel
{
    public Store? Store { get; set; }
    public List<Deal> Deals { get; set; } = [];
    public string Lang => Request.Query["lang"].FirstOrDefault() ?? Request.Cookies["lang"] ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";

    public async Task OnGetAsync(int id)
    {
        Store = await db.Stores.FindAsync(id);
        if (Store != null)
            Deals = await db.Deals.Where(x => x.StoreId == id && x.IsActive).ToListAsync();
    }
}