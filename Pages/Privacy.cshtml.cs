using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SupermarketCatalog.Pages;

public class PrivacyModel : PageModel
{
    public string Lang => Request.Query["lang"].FirstOrDefault() ?? Request.Cookies["lang"] ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";
}