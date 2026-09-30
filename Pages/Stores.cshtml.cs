using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages;

public class StoresModel(AppDbContext db) : PageModel
{
    public List<Store> Stores { get; set; } = [];
    public string Lang => Request.Query["lang"].FirstOrDefault() ?? Request.Cookies["lang"] ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";

    public async Task OnGetAsync()
    {
        Stores = await db.Stores.Include(x => x.Deals).ToListAsync();
    }
}