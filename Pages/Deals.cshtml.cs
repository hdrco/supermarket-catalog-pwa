using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;
namespace SupermarketCatalog.Pages;
public class DealsModel(AppDbContext db) : PageModel
{
    public List<Deal> Deals { get; set; } = [];
    public string Lang => Request.Query["lang"].FirstOrDefault() ?? Request.Cookies["lang"].FirstOrDefault() ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";
    public async Task OnGetAsync() => Deals = await db.Deals.Include(x => x.Store).Where(x => x.ExpiresAt > DateTime.UtcNow).OrderByDescending(x => x.Discount).ToListAsync();
    public string Title(Deal d) => Lang switch { "en" => d.TitleEn, "ar" => d.TitleAr, _ => d.Title };
}