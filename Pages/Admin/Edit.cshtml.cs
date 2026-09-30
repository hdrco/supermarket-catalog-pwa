using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages.Admin;

public class EditModel(AppDbContext db) : PageModel
{
    [BindProperty]
    public Deal? Deal { get; set; }

    public async Task OnGetAsync(int id)
    {
        Deal = await db.Deals.FindAsync(id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        db.Deals.Update(Deal!);
        await db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}