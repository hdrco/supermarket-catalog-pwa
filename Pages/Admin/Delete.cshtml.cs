using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketCatalog.Data;

namespace SupermarketCatalog.Pages.Admin;

public class DeleteModel(AppDbContext db) : PageModel
{
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var deal = await db.Deals.FindAsync(id);
        if (deal != null)
        {
            db.Deals.Remove(deal);
            await db.SaveChangesAsync();
        }
        return RedirectToPage("Index");
    }
}