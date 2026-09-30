using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages.Admin;

public class ProfileModel(AppDbContext db) : PageModel
{
    public Store? Store { get; set; }

    public async Task OnGetAsync()
    {
        Store = await db.Stores.FindAsync(1);
    }
}