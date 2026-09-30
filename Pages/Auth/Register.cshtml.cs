using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages.Auth;

public class RegisterModel(AppDbContext db) : PageModel
{
    [BindProperty]
    public Store Store { get; set; } = new();

    [BindProperty]
    public string Password { get; set; } = "";

    public string Lang => Request.Query["lang"].FirstOrDefault() ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";

    public async Task<IActionResult> OnPostAsync()
    {
        db.Stores.Add(Store);
        await db.SaveChangesAsync();
        return RedirectToPage("/");
    }
}