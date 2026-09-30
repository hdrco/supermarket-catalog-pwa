using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SupermarketCatalog.Pages.Auth;

public class LoginModel : PageModel
{
    public string Lang => Request.Query["lang"].FirstOrDefault() ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";

    public IActionResult OnPost()
    {
        return RedirectToPage("/");
    }
}