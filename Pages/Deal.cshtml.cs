using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages;

public class DealModel(AppDbContext db) : PageModel
{
    public Deal? Deal { get; set; }
    public string Lang => Request.Query["lang"].FirstOrDefault() ?? Request.Cookies["lang"] ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";

    public async Task OnGetAsync(int id)
    {
        Deal = await db.Deals.FindAsync(id);
    }

    public string Title() => Lang switch
    {
        "en" => Deal?.TitleEn ?? "",
        "ar" => Deal?.TitleAr ?? "",
        _ => Deal?.Title ?? ""
    };
}