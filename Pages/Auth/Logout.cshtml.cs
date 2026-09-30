using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages.Auth;

[Authorize]
public class LogoutModel(SignInManager<StoreUser> signInManager) : PageModel
{
    public async Task<IActionResult> OnGetAsync()
    {
        await signInManager.SignOutAsync();
        return RedirectToPage("/");
    }
}