using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketCatalog.Data;

namespace SupermarketCatalog.Pages.Admin;

[Authorize]
public class SubscriptionModel(AppDbContext db) : PageModel
{
    public void OnGet()
    {
    }
}