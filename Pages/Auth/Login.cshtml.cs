using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages.Auth;

public class LoginModel(SignInManager<StoreUser> signInManager) : PageModel
{
    [BindProperty]
    public string Email { get; set; } = "";

    [BindProperty]
    public string Password { get; set; } = "";

    [BindProperty]
    public bool RememberMe { get; set; }

    public string Lang => Request.Query["lang"].FirstOrDefault() ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        var result = await signInManager.PasswordSignInAsync(Email, Password, RememberMe, lockoutOnFailure: false);
        if (result.Succeeded)
            return RedirectToPage("/Admin/Index");

        ModelState.AddModelError("", "Invalid login attempt");
        return Page();
    }
}